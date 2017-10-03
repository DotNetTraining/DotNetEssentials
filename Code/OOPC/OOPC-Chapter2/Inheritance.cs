using System;

namespace OOPCChapter2
{
    /*
     * The following example shows how the class relationships are expressed in C#.
     * The example also shows how WorkItem overrides the virtual method Object.ToString, and how the ChangeRequest class inherits the WorkItem implementation of the method.
     */
    // WorkItem implicitly inherits from the Object class.
    public class WorkItem
    {
        // Static field currentID stores the job ID of the last WorkItem that
        // has been created.
        private static int currentID;

        //Properties.
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }

        // Default constructor. If a derived class does not invoke a base-
        // class constructor explicitly, the default constructor is called
        // implicitly. 
        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description.";
            jobLength = new TimeSpan();
        }

        // Instance constructor that has three parameters.
        public WorkItem(string title, string desc, TimeSpan joblen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
        }

        // Static constructor to initialize the static member, currentID. This
        // constructor is called one time, automatically, before any instance
        // of WorkItem or ChangeRequest is created, or currentID is referenced.
        static WorkItem()
        {
            currentID = 0;
        }


        protected int GetNextID()
        {
            // currentID is a static field. It is incremented each time a new
            // instance of WorkItem is created.
            return ++currentID;
        }

        // Method Update enables you to update the title and job length of an
        // existing WorkItem object.
        public void Update(string title, TimeSpan joblen)
        {
            this.Title = title;
            this.jobLength = joblen;
        }

        // Virtual method override of the ToString method that is inherited
        // from System.Object.
        public override string ToString()
        {
            return String.Format("{0} - {1}", this.ID, this.Title);
        }
    }

    // ChangeRequest derives from WorkItem and adds a property (originalItemID) 
    // and two constructors.
    public class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }

        // Constructors. Because neither constructor calls a base-class 
        // constructor explicitly, the default constructor in the base class
        // is called implicitly. The base class must contain a default 
        // constructor.

        // Default constructor for the derived class.
        public ChangeRequest() { }

        // Instance constructor that has four parameters.
        public ChangeRequest(string title, string desc, TimeSpan jobLen,
                             int originalID)
        {
            // The following properties and the GetNexID method are inherited 
            // from WorkItem.
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = jobLen;

            // Property originalItemId is a member of ChangeRequest, but not 
            // of WorkItem.
            this.originalItemID = originalID;
        }
    }

    class TestInheritance
    {
        static void InheritanceUsage()
        {
            // Create an instance of WorkItem by using the constructor in the 
            // base class that takes three arguments.
            WorkItem item = new WorkItem("Fix Bugs",
                                         "Fix all bugs in my code branch",
                                         new TimeSpan(3, 4, 0, 0));

            // Create an instance of ChangeRequest by using the constructor in
            // the derived class that takes four arguments.
            ChangeRequest change = new ChangeRequest("Change Base Class Design",
                                                     "Add members to the class",
                                                     new TimeSpan(4, 0, 0),
                                                     1);

            // Use the ToString method defined in WorkItem.
            Console.WriteLine(item.ToString());

            // Use the inherited Update method to change the title of the 
            // ChangeRequest object.
            change.Update("Change the Design of the Base Class",
                new TimeSpan(4, 0, 0));

            // ChangeRequest inherits WorkItem's override of ToString.
            Console.WriteLine(change.ToString());
            /* Output:
                1 - Fix Bugs
                2 - Change the Design of the Base Class
            */
        }
    }

    /*
     * Abstract and Virtual Methods
     * When a base class declares a method as virtual, a derived class can override the method with its own implementation. 
     * If a base class declares a member as abstract, that method must be overridden in any non-abstract class that directly inherits from that class. 
     * If a derived class is itself abstract, it inherits abstract members without implementing them.
     * Abstract and virtual members are the basis for polymorphism, which is the second primary characteristic of object-oriented programming.
     * In this example, the Shape class contains the two coordinates x, y, and the Area() virtual method. Different shape classes such as Circle, Cylinder, and Sphere inherit the Shape class, and the surface area is calculated for each figure.
     * Each derived class has it own override implementation of Area().
     * Notice that the inherited classes Circle, Sphere, and Cylinder all use constructors that initialize the base class
    */
    public abstract class Shape
    {
        public const double PI = Math.PI;
        protected double x, y;
        public Shape()
        {
        }
        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        //The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class
        public abstract double Area();

        public virtual string ShapeType { get { return GetType().ToString(); } }
    }

    public class Circle : Shape
    {
        public Circle(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return PI * x * x;
        }

        public override string ShapeType
        {
            get
            {
                return "Circle with a C";
            }
        }
    }

    class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return 4 * PI * x * x;
        }

        public override string ShapeType
        {
            get
            {
                return "Sphere like a ball";
            }
        }
    }

    class Cylinder : Shape
    {
        public Cylinder(double r, double h) : base(r, h)
        {
        }

        public override double Area()
        {
            return 2 * PI * x * x + 2 * PI * x * y;
        }

        public override string ShapeType
        {
            get
            {
                return "Cylinder as a bottle";
            }
        }
    }

    public class AbstractVirtual
    {
        public static void ManipulateShapes()
        {
            double r = 3.0, h = 5.0;
            Shape c = new Circle(r);
            Shape s = new Sphere(r);
            Shape l = new Cylinder(r, h);
            // Display results:
            Console.WriteLine("Area of {1}   = {0:F2}", c.Area(), c.ShapeType);
            Console.WriteLine("Area of {1}   = {0:F2}", s.Area(), s.ShapeType);
            Console.WriteLine("Area of {1} = {0:F2}", l.Area(), l.ShapeType);

            /*
            Output:
            Area of Circle with a C   = 28.27
            Area of Sphere like a ball   = 113.10
            Area of Cylinder as a bottle = 150.80
            */
        }
    }
}