using System;
namespace OOPCChapter2
{
    public class Classes
    {
        /*
         * The terms class and object are sometimes used interchangeably, but in fact, classes describe the type of objects, while objects are usable instances of classes.
         * So, the act of creating an object is called instantiation. Using the blueprint analogy, a class is a blueprint, and an object is a building made from that blueprint.
         * Each class can have different class members that include properties that describe class data, methods that define class behavior, and events that provide communication between different classes and objects.
         * The below class example demonstrates a Class declaration with constructs like fields, properties, methods, constructors, finalizers and events.
         * We also use a finalizer using the destructors, there is another way called dispose patter that we will take a look at below.
         * Note: All the members in the below class are public, we will discuss access modifiers in the next example.
         * The below class is a sealed class so you connot inherit it to add new methods, we will also see the Extension methods just below.
        */

        public sealed class SimpleClass
        {
            /*
             * Properties and Fields
             * Fields and properties represent information that an object contains. Fields are like variables because they can be read or set directly.
             * To define a field:
            */
            //field of type string.
            string consumerName;   //Fields are generally declared private (if you don't specify any access modifier, members are private).

            //propery to expose the className value
            public string ConsumerName
            {
                get { return consumerName; }
                set
                {
                    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value.Trim()))
                        throw new NullReferenceException("ConsumerName cannot be null!");
                    consumerName = value;
                }
            }

            /*
             * A method is an action that an object can perform.
             * A class can have several implementations, or overloads, of the same method that differ in the number of parameters or parameter types.
             * To define a method of a class:
            */

            public void SomeMethod()
            {
                Console.WriteLine("You called the method without any parameter!");
            }

            public void SomeMethod(int someParam)
            {
                Console.WriteLine("You called the overload with integer parameter, the value is {0}.", someParam);
            }

            public void SomeMethod(string someParam)
            {
                Console.WriteLine("You called the overload with string parameter, the value is {0}.", someParam);
            }

            /*
             * Constructors are class methods that are executed automatically when an object of a given type is created.
             * Constructors usually initialize the data members of the new object. A constructor can run only once when a class is created.
             * Furthermore, the code in the constructor always runs before any other code in a class.
             * However, you can create multiple constructor overloads in the same way as for any other method.
             */

            public SimpleClass()
            {
                consumerName = "Consumer Name not initialized!";
            }

            public SimpleClass(string consumerName)
            {
                this.consumerName = consumerName;
            }

            /*
             * Finalizers
             * Finalizers are used to destruct instances of classes.
             * Finalizers cannot be defined in structs. They are only used with classes.
                * A class can only have one finalizer.
                * Finalizers cannot be inherited or overloaded.
                * Finalizers cannot be called. They are invoked automatically.
                * A finalizer does not take modifiers or have parameters.
            */
            ~SimpleClass()
            {
                Console.WriteLine("Destructor is being called!");
                consumerName = null;
            }
        }

    }
    /*
     * C# also supports extension methods that allow you to add methods to an existing class outside the actual definition of the class.
    */
    public static class ExtensionClass
    {
        public static void ExtensionMethod(this Classes.SimpleClass instance, string extensionParam)
        {
            Console.WriteLine("You called the extension method on the SimpleClass with ConsumerName {0}", instance.ConsumerName);
            Console.WriteLine("You passed the extensionParam value {0}", extensionParam);
        }

        public static void ExtensionTest()
        {
            //now we will try to call the extension method on an object of SimpleClass - we are calling this method from the same class in which we defined the extension method.
            //You can however call these extension methods from any class as long as:
            //  * The extension method is defined as public.
            //  * The namespace in which the extension method is defined is referenced in your code from where you are trying to access the extension method.
            //For more advanced and granular study of extension method refer to:
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
            Classes.SimpleClass simpleClass = new Classes.SimpleClass("ExtensionClass");
            simpleClass.ExtensionMethod("Test Extension Param");
            /*
             Output:
                You called the extension method on the SimpleClass with Consumername ExtensionClass
                You passed the extensionParam value Test Extension Param
            */
        }
    }

    /*
     * dispose pattern using IDisposable
     * You implement a Dispose method to release unmanaged resources used by your application. The .NET garbage collector does not allocate or release unmanaged memory.
     * The pattern for disposing an object, referred to as a dispose pattern, imposes order on the lifetime of an object. 
     * The dispose pattern is used only for objects that access unmanaged resources, such as file and pipe handles, registry handles, wait handles, or pointers to blocks of unmanaged memory.
     * This is because the garbage collector is very efficient at reclaiming unused managed objects, but it is unable to reclaim unmanaged objects.
    */

    class BaseClass : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~BaseClass()
        {
            Dispose(false);
        }
    }

    class DerivedClass : BaseClass
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;

            // Call the base class implementation.
            base.Dispose(disposing);
        }

        ~DerivedClass()
        {
            Dispose(false);
        }
    }

    /*
     * Access Modifiers
     * All types and type members have an accessibility level, which controls whether they can be used from other code in your assembly or other assemblies. 
     * You can use the following access modifiers to specify the accessibility of a type or member when you declare it:
        public
            The type or member can be accessed by any other code in the same assembly or another assembly that references it.
        private
            The type or member can be accessed only by code in the same class or struct.
        protected
            The type or member can be accessed only by code in the same class or struct, or in a class that is derived from that class.
        internal
            The type or member can be accessed by any code in the same assembly, but not from another assembly.
        protected internal
            The type or member can be accessed by any code in the assembly in which it is declared,
            or from within a derived class in another assembly.
            Access from another assembly must take place within a class declaration that derives from the class in which the protected internal element is declared,
            and it must take place through an instance of the derived class type.
     * Class and Struct Member Accessibility
     * Class members (including nested classes and structs) can be declared with any of the five types of access.
     * Struct members cannot be declared as protected because structs do not support inheritance.
     * The type of any member that is a field, property, or event must be at least as accessible as the member itself.
     * Similarly, the return type and the parameter types of any member that is a method, indexer, or delegate must be at least as accessible as the member itself.
     * For example, you cannot have a public method M that returns a class C unless C is also public.
     * Likewise, you cannot have a protected property of type A if A is declared as private.
    */
    // public class:
    public class Tricycle
    {
        // protected method:
        protected void Pedal() { }

        // private field:
        private int wheels = 3;

        // protected internal property:
        protected internal int Wheels
        {
            get { return wheels; }
        }

        internal void Repair()
        {
            Console.WriteLine("You will get it back in 3 hours!");
        }

        public void StartRiding()
        {
            Console.WriteLine("You have started riding the Tricycle!");
        }
    }

    public class TricycleTest
    {
        public static void TestAccess()
        {
            //you cannot access a protected member from this class, so if you uncomment the below 2 lines you will get a compilation error.
            //Tricycle cycle = new Tricycle();
            //cycle.Pedal();

            //You can however access the public, internal or protected internal members
            Tricycle tricycle1 = new Tricycle();
            int wheelCount = tricycle1.Wheels;
            tricycle1.Repair();
            tricycle1.StartRiding();

            //Assignment: Create two projects and add reference to the first project in your second project and then test the internal and protected internal methods, let us know what you find out.
        }
    }

    /*
     * Static Classes and Static Class Members
     * A static class is basically the same as a non-static class, but there is one difference: a static class cannot be instantiated. 
     * In other words, you cannot use the new keyword to create a variable of the class type. 
     * Because there is no instance variable, you access the members of a static class by using the class name itself.
     * A static class can be used as a convenient container for sets of methods that just operate on input parameters and do not have to get or set any internal instance fields. 
     * For example, in the .NET Framework Class Library, the static Math class contains methods that perform mathematical operations, without any requirement to store or retrieve data that is unique to a particular instance of the Math class.
    */
    public class StaticClassAccessExample
    {
        public static void AccessingStaticMembers()
        {
            double dub = -3.14;
            Console.WriteLine(Math.Abs(dub));
            Console.WriteLine(Math.Floor(dub));
            Console.WriteLine(Math.Round(Math.Abs(dub)));
            // Output:  
            // 3.14  
            // -4  
            // 3
        }
    }

    /*
     * As is the case with all class types, the type information for a static class is loaded by the .NET Framework common language runtime (CLR) when the program that references the class is loaded. 
     * The program cannot specify exactly when the class is loaded. However, it is guaranteed to be loaded and to have its fields initialized and its static constructor called before the class is referenced for the first time in your program. 
     * A static constructor is only called one time, and a static class remains in memory for the lifetime of the application domain in which your program resides.
     * the main features of a static class are:
        * Contains only static members.
        * Cannot be instantiated.
        * Is sealed.
        * Cannot contain Instance Constructors.
     * Creating a static class is therefore basically the same as creating a class that contains only static members and a private constructor.
     * A private constructor prevents the class from being instantiated. The advantage of using a static class is that the compiler can check to make sure that no instance members are accidentally added. 
     * The compiler will guarantee that instances of this class cannot be created.
     * Static classes are sealed and therefore cannot be inherited. They cannot inherit from any class except Object.
     * Static classes cannot contain an instance constructor; however, they can contain a static constructor.
     * Non-static classes should also define a static constructor if the class contains static members that require non-trivial initialization.
    */

    public static class TemperatureConverter
    {
        public static double CelsiusToFahrenheit(string temperatureCelsius)
        {
            // Convert argument to double for calculations.
            double celsius = Double.Parse(temperatureCelsius);

            // Convert Celsius to Fahrenheit.
            double fahrenheit = (celsius * 9 / 5) + 32;

            return fahrenheit;
        }

        public static double FahrenheitToCelsius(string temperatureFahrenheit)
        {
            // Convert argument to double for calculations.
            double fahrenheit = Double.Parse(temperatureFahrenheit);

            // Convert Fahrenheit to Celsius.
            double celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }

        /*
         * If you try to create an instance constructor or instance member (field, property, method etc.) on a static class you get a compilation error.
         * Try uncommenting the below contructor and property.
        */
        /*
        public double TempratureValue { get; set; }
        public string TempratureType { get; set; }
        public TemperatureConverter()
        {
            TempratureValue = 0;
            TempratureType = "Undefined";
        }
        */
    }

    public static class TempratureConverterTest
    {
        public static void TestConversion()
        {
            Console.WriteLine("Please select the convertor direction");
            Console.WriteLine("1. From Celsius to Fahrenheit.");
            Console.WriteLine("2. From Fahrenheit to Celsius.");
            Console.Write(":");

            string selection = Console.ReadLine();
            double F, C = 0;

            switch (selection)
            {
                case "1":
                    Console.Write("Please enter the Celsius temperature: ");
                    F = TemperatureConverter.CelsiusToFahrenheit(Console.ReadLine());
                    Console.WriteLine("Temperature in Fahrenheit: {0:F2}", F);
                    break;

                case "2":
                    Console.Write("Please enter the Fahrenheit temperature: ");
                    C = TemperatureConverter.FahrenheitToCelsius(Console.ReadLine());
                    Console.WriteLine("Temperature in Celsius: {0:F2}", C);
                    break;

                default:
                    Console.WriteLine("Please select a convertor.");
                    break;
            }
        }
    }
    /*
     * Static Members:
     * A non-static class can contain static methods, fields, properties, or events. 
     * The static member is callable on a class even when no instance of the class has been created. 
     * The static member is always accessed by the class name, not the instance name. 
     * Only one copy of a static member exists, regardless of how many instances of the class are created.
     * Static methods and properties cannot access non-static fields and events in their containing type, and they cannot access an instance variable of any object unless it is explicitly passed in a method parameter.
     * It is more typical to declare a non-static class with some static members, than to declare an entire class as static. 
     * Two common uses of static fields are to keep a count of the number of objects that have been instantiated, or to store a value that must be shared among all instances.
     * Static methods can be overloaded but not overridden, because they belong to the class, and not to any instance of the class.
    * Although a field cannot be declared as static const, a const field is essentially static in its behavior.
    * It belongs to the type, not to instances of the type. Therefore, const fields can be accessed by using the same ClassName.MemberName notation that is used for static fields. 
    * No object instance is required.
    * C# does not support static local variables (variables that are declared in method scope).
    */

    public class Audience
    {
        #region Static Members
        static int audienceCount;
        static Audience lastAdmittedAudience;

        public static int AudienceCount { get { return audienceCount; } }
        public static Audience LastAdmittedAudience { get { return lastAdmittedAudience; } }
        public static DateTime LastAdmissionTime { get; private set; }
        public static void AdmitAudience(string audienceName, string audienceAddress, string audienceIdentifier)
        {
            audienceCount++;
            lastAdmittedAudience = new Audience(audienceName, audienceAddress, audienceAddress);
            LastAdmissionTime = DateTime.Now;
        }

        static Audience()
        {
            AdmitAudience("Administrator", "Venue Address", "ADMIN");
        }

        #endregion

        #region Instance Members

        public string AudienceName { get; private set; }
        public string AudienceAddress { get; private set; }
        public string AudienceIdentifier { get; private set; }

        private Audience(string name, string address, string identifier)
        {
            AudienceName = name;
            AudienceAddress = address;
            AudienceIdentifier = String.Format("{0} - {1}", audienceCount, identifier);
        }

        #endregion

    }
}
