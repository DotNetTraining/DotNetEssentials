using System;
using System.Data;
using System.Data.SqlClient;
namespace OOPCChapter4
{
    #region [Full Example]
    public interface IPersistableObject
    {
        void Create();
        void Load(int id);
        void Load(IDataReader reader);
        void Save();
    }

    public abstract class PersistableObject : IPersistableObject
    {
        protected string LoadByIdCommandName { get; private set; }
        protected string SaveCommandName { get; private set; }
        private Func<IDataParameter[]> saveParametersPopulateCallback;

        public PersistableObject(string loadByIdCommandName, string saveCommandName, Func<IDataParameter[]> saveParametersPopulateCallback)
        {
            this.LoadByIdCommandName = loadByIdCommandName;
            this.SaveCommandName = saveCommandName;
            this.saveParametersPopulateCallback = saveParametersPopulateCallback;
        }

        #region [IPersistableObject]
        public abstract void Create();
        public abstract void Load(int id);
        public abstract void Load(IDataReader reader);
        public virtual void Save()
        {
            IDataParameter[] parameters;
            if (this.saveParametersPopulateCallback != null)
                parameters = saveParametersPopulateCallback();
            //Save code goes here
        }
        #endregion
    }

    public class User:PersistableObject
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public User():base("usp_LoadUserById", "usp_SaveUser", () => { return new IDataParameter[10]; })
        {
            
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Load(int id)
        {
            throw new NotImplementedException();
        }

        public override void Load(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override void Save() {base.Save();}
    }

    public abstract class BusinessEntityBase
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }

    public class BusinessEntity<T> : BusinessEntityBase where T: PersistableObject, new()
    {
        public IPersistableObject Object { get; protected set; }
        public BusinessEntity(User user):base()
        {
            Object = new T();
            Object.Create();
            CreatedBy = user.UserId;
            CreatedOn = DateTime.Now;
        }

        public BusinessEntity(int id):base()
        {
            Object = new T();
            Object.Load(id);
        }

        public BusinessEntity(IDataReader reader): base()
        {
            Object = new T();
            Object.Load(reader);
        }

        public void Save()
        {
            Object?.Save();
        }
    }

    public class Product:PersistableObject
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double PricePerUnit { get; set; }
        public Product():base("usp_LoadProductById", "usp_SaveProduct", () => { return new IDataParameter[10]; })
        {

        }

        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Load(int id)
        {
            throw new NotImplementedException();
        }

        public override void Load(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override void Save() => base.Save();
    }

    #endregion

    #region [Generic Interfaces]

    public interface ISwap<T> where T:struct
    {
        void Swap(ref T first, ref T other);
    }

    public class IntSwap:ISwap<int>
    {
        public void Swap(ref int first, ref int other)
        {
            //swap without a third variable;
            first += other;
            other = first - other;
            first = first - other;
        }
    }

    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PointSwap : ISwap<Point>
    {
        public void Swap(ref Point first, ref Point other)
        {
            Point temp = new Point(first.X, first.Y);
            first = other;
            other = temp;
        }
    }

    #endregion

    #region Generic Methods
    public class GenericSwapper
    {
        public void Swap<T>(ref T first, ref T other) where T:struct
        {
            T temp = first;
            first = other;
            other = first;
        }
    }
    #endregion

    #region Generic Delegates

    public class AdvancedSwapper:GenericSwapper
    {
        public delegate void SwapAction<T>(ref T first, ref T other);
        public void Swap<T>(ref T first, ref T other, SwapAction<T> action) where T: struct
        {
            if (action != null)
                action(ref first, ref other);
            else
                base.Swap(ref first, ref other);
        }
    }

    #endregion

    public class GenericsExample
    {
        public void SimpleExample()
        {
            User user = new User() { UserId = 22, FullName = "Test", UserName = "TestUser" };
            //This works
            BusinessEntity<Product> product = new BusinessEntity<Product>(user);
            //and so does this
            BusinessEntity<User> userLoaded = new BusinessEntity<User>(22);
            //This is the power of generics
        }

        public void GenericInterfacesExample()
        {
            int a = 22, b = 45;
            ISwap<int> swapper = new IntSwap();
            swapper.Swap(ref a, ref b);
            Console.WriteLine($"values of: [a = {a}], [b = {b}]");

            //The same way we can use it for Point Swapper as well, notice that the type and way of swapping has changed but the contract remains (i.e the swap method)
            ISwap<Point> pointSwapper = new PointSwap();
            Point first = new Point(22, 45), second = new Point(33, 48);
            pointSwapper.Swap(ref first, ref second);
            Console.WriteLine($"Points now are: [First: (X = {first.X}, Y = {first.Y})], [Second: (X = {second.X}, Y = {second.Y})]");
        }

        public void GenericMethodsExample()
        {
            GenericSwapper swapper = new GenericSwapper();
            int a = 22, b = 45;
            swapper.Swap(ref a, ref b);     //Notice we omitted the type parameter because it can be inferred by the compiler;
            //this is also valid
            //swapper.Swap<int>(ref a, ref b);

            Console.WriteLine($"values of: [a = {a}], [b = {b}]");

            //The same can now be used for any struct
            Point first = new Point(22, 45), second = new Point(33, 48);
            swapper.Swap(ref first, ref second);
            Console.WriteLine($"Points now are: [First: (X = {first.X}, Y = {first.Y})], [Second: (X = {second.X}, Y = {second.Y})]");
        }

        public void GenericDelegatesExample()
        {
            AdvancedSwapper.SwapAction<int> intSwapper = (ref int one, ref int two) =>
            {
                one += two;
                two = one - two;
                one = one - two;
            };

            AdvancedSwapper swapper = new AdvancedSwapper();
            int a = 22, b = 45;
            swapper.Swap(ref a, ref b, intSwapper);     //we will use memory efficient swapper for ints
            //this is also valid
            //swapper.Swap<int>(ref a, ref b);

            Console.WriteLine($"values of: [a = {a}], [b = {b}]");

            //The same can now be used for any struct
            Point first = new Point(22, 45), second = new Point(33, 48);
            swapper.Swap(ref first, ref second);        //this will default to general implementation
            Console.WriteLine($"Points now are: [First: (X = {first.X}, Y = {first.Y})], [Second: (X = {second.X}, Y = {second.Y})]");
        }
    }
}