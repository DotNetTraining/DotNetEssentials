using System;
using System.Linq;

namespace OOPCChapter3{

    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
             * The following example illustrates this pattern. In this example, the TimePeriod class represents an interval of time. 
             * Internally, the class stores the time interval in seconds in a private field named seconds. 
             * A read-write property named Hours allows the customer to specify the time interval in hours. 
             * Both the get and the set accessors perform the necessary conversion between hours and seconds. 
             * In addition, the set accessor validates the data and throws an ArgumentOutOfRangeException if the number of hours is invalid.
            */
            TimePeriod t = new TimePeriod();
            // The property assignment causes the 'set' accessor to be called.
            t.Hours = 24;

            // Retrieving the property causes the 'get' accessor to be called.
            Console.WriteLine($"Time in hours: {t.Hours}");

            //OUTPUT:
            // The example displays the following output:
            //    Time in hours: 24

            /*
             * Expression body definitions C# 6.0
            */
            var person = new Person("Isabelle", "Butts");
            Console.WriteLine(person.Name);
            // The example displays the following output:
            //      Isabelle Butts

            /*
             * Expression body definitions C# 7.0
             * Notice the new String Intrapolation syntax.
            */
            var item = new SaleItem("Shoes", 19.95m);
            Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
            // The example displays output like the following:
            //       Shoes: sells for $19.95


            /*
             * Auto-implemented properties
             * Notice the object initialization syntax.
            */
            var item2 = new SaleItemV2 { Name = "Shoes", Price = 19.95m };
            Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
            // The example displays output like the following:
            //       Shoes: sells for $19.95

            /*
             * Properties in interfaces.
            */
            System.Console.Write("Enter number of employees: ");
            Employee.numberOfEmployees = int.Parse(System.Console.ReadLine());

            Employee e1 = new Employee();
            System.Console.Write("Enter the name of the new employee: ");
            e1.Name = System.Console.ReadLine();

            System.Console.WriteLine("The employee information:");
            System.Console.WriteLine("Employee number: {0}", e1.Counter);
            System.Console.WriteLine("Employee name: {0}", e1.Name);


            /*
             * Example: Implement a Lightweight Class with Auto-Implemented Properties
            */
            // Some simple data sources.   
            string[] names = {"Terry Adams","Fadi Fakhouri", "Hanying Feng",
                              "Cesar Garcia", "Debra Garcia"};
            string[] addresses = {"123 Main St.", "345 Cypress Ave.", "678 1st Ave",
                                  "12 108th St.", "89 E. 42nd St."};

            // Simple query to demonstrate object creation in select clause. - We will discuss LINQ in great detail in next chapter
            // Create Contact objects by using a constructor.   
            var query1 = from i in Enumerable.Range(0, 5)
                         select new Contact(names[i], addresses[i]);

            // List elements cannot be modified by client code.   
            var list = query1.ToList();
            foreach (var contact in list)
            {
                Console.WriteLine("{0}, {1}", contact.Name, contact.Address);
            }

            // Create Contact2 objects by using a static factory method.   
            var query2 = from i in Enumerable.Range(0, 5)
                         select Contact2.CreateContact(names[i], addresses[i]);

            // Console output is identical to query1.   
            var list2 = query2.ToList();

            // List elements cannot be modified by client code.   
            // CS0272:   
            // list2[0].Name = "Eugene Zabokritski";

            /*
             * Enumerating the attributes
            */

            BaseClass b = new BaseClass();
            DerivedClass d = new DerivedClass();

            // Display custom attributes for each class.  
            Console.WriteLine("Attributes on Base Class:");
            object[] attrs = b.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }

            Console.WriteLine("Attributes on Derived Class:");
            attrs = d.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }

            /*OUTPUT:
             * Attributes on Base Class:  
             * A1  
             * A2  
             * Attributes on Derived Class:  
             * A3  
             * A3  
             * A2 
            */

            /*
             * Getting Attributes MetaData
            */
            PrintAuthorInfo(typeof(AlgorithmEasy));
            PrintAuthorInfo(typeof(AlgorithmSimple));
            /*
             * OUTPUT
             * Author information for AlgorithmEasy
             *      Pradeep Singh, version 1.00
             * Author information for AlgorithmSimple
             *      Pradeep Singh, version 1.10
            */

            //Using attributes from .Net Framwork
            TraceMessage("This is a simple log");

            /*
             * Indexers
            */
            ClassStudents classStudents = new ClassStudents();
            Student bruceLeeIncorrect = new Student() { Id = 1, Name = "Bruce Lee", DateOfBirth = new DateTime(1904, 11, 27), FathersName = "Lee Hoi-chuen" };
            Student bruceLeeCorrect = new Student() { Id = 1, Name = "Bruce Lee", DateOfBirth = new DateTime(1940, 11, 27), FathersName = "Lee Hoi-chuen" };
            classStudents[bruceLeeIncorrect.Name] = bruceLeeIncorrect;
            classStudents[bruceLeeCorrect.Name] = bruceLeeCorrect;
            Console.WriteLine($"Students Count: {classStudents.StudentCount}");
            //Print out all details;
            Console.WriteLine($"Id: {bruceLeeCorrect.Id}\nName: {bruceLeeCorrect.Name}\nFathers Name: {bruceLeeCorrect.FathersName}\nDate Of Birth: {bruceLeeCorrect.DateOfBirth.ToString("D")}");

            //now we can also add attributes to Student
            bruceLeeCorrect["area"] = "Southern";
            //or even update the name
            bruceLeeCorrect["name"] = "Bruce (Lee Jun-fan) Lee";
            //add an attribute - original name
            bruceLeeCorrect["original_name"] = "Lee Jun-fan";
            //Print out all details again;
            Console.WriteLine($"\nNew Details\n*******************" +
                              $"\nId: {bruceLeeCorrect.Id}" +
                              $"\nName: {bruceLeeCorrect.Name}" +
                              $"\nFathers Name: {bruceLeeCorrect.FathersName}" +
                              $"\nDate Of Birth: {bruceLeeCorrect.DateOfBirth.ToString("D")}");

            //loop through all attributes
            foreach (var attribute in bruceLeeCorrect.Attributes)
            {
                Console.WriteLine($"Key: {attribute.Key}\t\tValue: {attribute.Value}");
            }

            //you can do something like this to get the original name of Bruce Lee - double indexer syntax
            string bruceLeeOriginalName = classStudents[bruceLeeCorrect.Name]["original_name"].ToString();
            Console.WriteLine("Original Name: {0}", bruceLeeOriginalName);

            //Delegates and Events
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Vehicle car = new Vehicle();
            VehicleStateChangeAction engineOn = ()=>
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Engine Switcehd On...\nEnjoy Your Trip!");
            };
            VehicleStateChangeAction engineOff = () =>
            { 
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Engine Switcehd Off...\nDon't forget to take your stuff along!"); 
            };
            VehicleStateChangeAction startedMoving = () =>
            { 
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Vehicle Started Moving...\nFasten your seat belts!"); 
            };
            VehicleStateChangeAction stopped = () =>
            { 
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Vehicle Stopped...\nTo save fuel, turn off the engine if you plan to stop longer than a minute."); 
            };

            //setup the delegates
            car.OnVehicleEngineOn = engineOn;
            car.OnVehicleEngineOff = engineOff;
            car.OnVehicleStartMoving = startedMoving;
            car.OnVehicleStopped = stopped;

            //alternatively you could have done something like this.
            /*
            car.OnVehicleEngineOn = () => { Console.WriteLine("Engine Switcehd On...\nEnjoy Your Trip!"); };
            car.OnVehicleEngineOff = () => { Console.WriteLine("Engine Switcehd Off...\nDon't forget to take your stuff along!"); };
            car.OnVehicleStartMoving = () => { Console.WriteLine("Vehicle Started Moving...\nFasten your seat belts!"); };
            car.OnVehicleStopped = () => { Console.WriteLine("Vehicle Stopped...\nTo save fuel, turn off the engine if you plan to stop longer than a minute."); };
            */

            //Now subscribe to the events
            car.VehicleSpeedChanged += vehicleSpeedChanged;
            car.EngineOn();
            for (int i = 0; i < 100; i++)
            {
                car.Accelerate();
            }
            for (int i = 0; i < 100; i++)
            {
                car.DeAccelerate();
            }
            car.EngineOff();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            //Insane code
            try
            {
                //try accelerating when the engine is off;
                car.Accelerate();
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            //Insane code
            try
            {
                car.EngineOn();
                //try deaccelerating when the car is not moving;
                car.DeAccelerate();
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            //ToDo: Assignment - Add more code to perform insane actions

            //Nullable Types
            NullableTypes nullableTypes = new NullableTypes();
            //Simple Example
            nullableTypes.BasicExample();
            //Null Coalescing Operator
            nullableTypes.NullCoalescingOperator();
            //safe casting
            nullableTypes.SafeCasting();
            //Identify Nullable Type
            nullableTypes.IdentifyNullableType();

            //Simple Exception Throwing and Handling
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n************************\nExceptions\n************************");
            double first = 98, second = 0;
            double result = 0;

            try
            {
                result = Exceptions.SafeDivision(first, second);
                Console.WriteLine("{0} divided by {1} = {2}", first, second, result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted divide by zero.");
            }

            //using try catch and finally
            Exceptions.CodeWithCleanup();

            //Custom Exceptions
            Exceptions.CustomExceptionExample();
        }

        private static void vehicleSpeedChanged(object sender, SpeedChangeEventArgs args)
        {
            if (args.IsSpeedOverLimit)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current Speed: {args.Speed}\nECU Message: {args.VehicleECUMessage}");
        }

        private static void PrintAuthorInfo(System.Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.  

            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author)attr;
                    System.Console.WriteLine("   {0}, version {1:f}", a.Name, a.Version);
                }
            }
        }

        public static void TraceMessage(string message,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("message: " + message);
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }
    }
}
