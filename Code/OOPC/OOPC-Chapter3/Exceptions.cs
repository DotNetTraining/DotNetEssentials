using System;
using System.Text;
using System.Linq;
namespace OOPCChapter3
{
    public class Exceptions
    {
        public static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new System.DivideByZeroException();
            return x / y;
        }

        public static void CodeWithCleanup()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileInfo = null;

            try
            {
                fileInfo = new System.IO.FileInfo("myFile.txt");
                if (!fileInfo.Exists)
                    file = fileInfo.Create();
                else
                    file = fileInfo.OpenWrite();
                
                byte[] bytes = Encoding.ASCII.GetBytes("Hello!");
                file.Write(bytes, 0, bytes.Length);
            }
            catch (System.UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }

        public static void CustomExceptionExample()
        {
            try
            {
                ThrowCustomException();
            }
            catch (NameNotAllowedException ex)
            {
                Console.WriteLine($"Well that name is not allowed, why would you like to call them {ex.Name}?\nPlease choose another name!");
                ThrowCustomException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops something went wrong.\nMessage: {ex.Message}");
            }
        }

        static void ThrowCustomException()
        {
            string[] prohibitedNames = new string[] { "hitler", "nazi", "idiot", "stupid" };
            Console.WriteLine("What do you want to call the new kid: ");
            string name = Console.ReadLine();
            if (prohibitedNames.Count(x => x.ToLower() == name.ToLower()) > 0)
                throw new NameNotAllowedException(name);
            else
                Console.WriteLine($"That is a very good name, we would like to say hello to {name}");
        }

        public class NameNotAllowedException:Exception
        {
            public string Name { get; private set; }
            public NameNotAllowedException(string name):base()
            {
                this.Name = name;
            }

            public NameNotAllowedException(string name, string message):base(message)
            {
                this.Name = name;
            }

            public NameNotAllowedException(string name, string message, Exception innerException):base(message, innerException)
            {
                this.Name = name;
            }
        }
    }
}