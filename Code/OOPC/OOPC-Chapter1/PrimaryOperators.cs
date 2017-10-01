using System;
namespace OOPCChapter1
{
    
    public static class PrimaryOperators
    {
        class Console
        {
            public static void WriteLine(string s)
            {
                if (s == null)
                    System.Console.WriteLine("That was a null value!");
                else
                    System.Console.WriteLine("This is a fancy WriteLine method: {0}", s);
            }
        }
        
        public static void DotOperatorExample()
        {
            // The class Console in namespace System:
            System.Console.WriteLine("hello");
            //for class instances
            Simple s = new Simple();        //notice the new operator
            s.a = 6;   // assign to field a;
            s.b();     // invoke member function b;
            //The using directive makes some name qualification optional - for example we are "using" the system namespace, But when an identifier is ambiguous, it must be qualified:
            System.Console.WriteLine("hello"); //this calls the WriteLine method on System.Console static class
            Console.WriteLine("hello");   // whereas this calls the WriteLineMethod on the Console class defined above.
        }

        public static void NullConditionalMemberAccess()
        {
            string nullCustomerName=null;
            string nonNullCustomerName = "Non Null Customer";
            int? length = nullCustomerName?.Length;
            if (length.HasValue)
                System.Console.WriteLine(length);
            else
                Console.WriteLine("That was a null value");
            System.Console.WriteLine(nonNullCustomerName?.Length);
        }

        public static void NullConditionalIndexAccess()
        {
            System.Console.WriteLine("This would not print anything");
            int[] nullArray = null;
            System.Console.WriteLine("The first element: {0}", nullArray?[0]);
            System.Console.WriteLine("This would print the first element");
            int[] nonNullArray = new int[] { 10, 21, 45, 24 };
            System.Console.WriteLine("The first element: {0}", nonNullArray?[0]);
        }

        public static void Paranthesis()
        {
            //casting
            double doubleValue = 1234.5;
            int integerValue = (int)doubleValue;

            //precedence grouping
            int resultWithGrouping = 4 * (5 + 4);
            int resultWithoutGrouping = 4 * 5 + 4;

            //method invocation
            System.Console.WriteLine();
        }

        public static void SquareBrackets()
        {
            //Square brackets ([]) are used for arrays, indexers, and attributes. They can also be used with pointers.
            int[] fib; // fib is of type int[], "array of int".
            fib = new int[100]; // Create a 100-element int array.
            fib[0] = fib[1] = 1;
            //To access an element of an array, the index of the desired element is enclosed in brackets:
            for (int i = 2; i < 100; ++i)
                fib[i] = fib[i - 1] + fib[i - 2];
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            h["a"] = 123; // Note: using a string as the index.
            //You can use square brackets to index off a pointer: (notice we can define inner functions/methods after C# version 7)
            unsafe void pointerSquareBrackets()
            {
                int[] nums = { 0, 1, 2, 3, 4, 5 };
                fixed (int* p = nums)
                {
                    p[0] = p[1] = 1;
                    for (int i = 2; i < 100; ++i) p[i] = p[i - 1] + p[i - 2];
                }
            }
            pointerSquareBrackets();
            //Square brackets are also used to specify Attributes which we will cover later in the course
        }

        public static void PlusPlus()
        {
            double x;
            x = 1.5;
            //This will first increment the value and then print it: this is known as prefix increment
            System.Console.WriteLine(++x);
            x = 1.5;
            //this will first print the value and then increment it: this is known as postfix increment
            System.Console.WriteLine(x++);
            System.Console.WriteLine(x);
        }

        public static void MinusMinus()
        {
            double x;
            x = 1.5;
            //This will first decrement the value and then print it: this is known as prefix decrement
            System.Console.WriteLine(++x);
            x = 1.5;
            //this will first print the value and then decrement it: this is known as postfix decreement
            System.Console.WriteLine(x++);
            System.Console.WriteLine(x);
        }

        public static void New()
        {
            //Used to create objects and invoke constructors.
            // Create objects using default constructors:
            SampleStruct Location1 = new SampleStruct();
            SampleClass Employee1 = new SampleClass();

            // Display values:
            System.Console.WriteLine("Default values:");
            System.Console.WriteLine("   Struct members: {0}, {1}",
                   Location1.x, Location1.y);
            System.Console.WriteLine("   Class members: {0}, {1}",
                   Employee1.name, Employee1.id);

            // Create objects using parameterized constructors:
            SampleStruct Location2 = new SampleStruct(10, 20);
            SampleClass Employee2 = new SampleClass(1234, "Cristina Potra");

            // Display values:
            System.Console.WriteLine("Assigned values:");
            System.Console.WriteLine("   Struct members: {0}, {1}",
                   Location2.x, Location2.y);
            System.Console.WriteLine("   Class members: {0}, {1}",
                   Employee2.name, Employee2.id);

            //It is also used to create instances of anonymous types (more on anonymous types later):
            var anonymousObject = new { Name = "Unknown", Age = 24 };
                                                       }

        public static void TypeOf()
        {
            //Used to obtain the System.Type object for a type.
            System.Type type = typeof(int);
            //the below will do the same
            int i = 0;
            type = i.GetType();
            //GetType() can also be used on expressions
            int radius = 3;
            System.Console.WriteLine("Area = {0}", radius * radius * Math.PI);
            System.Console.WriteLine("The type is {0}",
                              (radius * radius * Math.PI).GetType()
            );
        }

        // Set maxIntValue to the maximum value for integers.
        static int maxIntValue = 2147483647;

        // Using a checked expression.
        static int CheckedMethod()
        {
            int z = 0;
            try
            {
                // The following line raises an exception because it is checked. More on exceptions later
                z = checked(maxIntValue + 10);
            }
            catch (System.OverflowException e)
            {
                // The following line displays information about the error.
                System.Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
            }
            // The value of z is still 0.
            return z;
        }

        // Using an unchecked expression.
        static int UncheckedMethod()
        {
            int z = 0;
            try
            {
                // The following calculation is unchecked (default behavaior) and will not 
                // raise an exception.
                z = maxIntValue + 10;
            }
            catch (System.OverflowException e)
            {
                // The following line will not be executed.
                Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
            }
            // Because of the undetected overflow, the sum of 2147483647 + 10 is 
            // returned as -2147483639.
            return z;
        }

        public static void Default()
        {
            //Default value expressions can be used with any managed type.
            var s = default(string);
            var d = default(dynamic);
            var i = default(int);
            var n = default(int?); // n is a Nullable int where HasValue is false.
        }

        public static void Delegate()
        {
            //If this doesn't make sense now don't worry we will cover this in great detail later.
            // Instantiate the delegate type using an anonymous method.
            Action<string> p = delegate (string j)
            {
                System.Console.WriteLine(j);
            };

            // Results from the anonymous delegate call.
            p("The delegate using the anonymous method is called.");

            // The delegate instantiation using a named method "DoWork".
            p = new Action<string>(DoWork);

            // Results from the old style delegate call.
            p("The delegate using the named method is called.");
        }

        // The method associated with the named delegate.
        static void DoWork(string k)
        {
            System.Console.WriteLine(k);
        }

        public static void SizeOf()
        {
            /*
             * sizeof can be used with following types
             *  sizeof(sbyte)   1
                sizeof(byte)    1
                sizeof(short)   2
                sizeof(ushort)  2
                sizeof(int)     4
                sizeof(uint)    4
                sizeof(long)    8
                sizeof(ulong)   8
                sizeof(char)    2 (Unicode)
                sizeof(float)   4
                sizeof(double)  8
                sizeof(decimal) 16
                sizeof(bool)    1
            */

            System.Console.WriteLine("The size of short is {0}.", sizeof(short));
            System.Console.WriteLine("The size of int is {0}.", sizeof(int));
            System.Console.WriteLine("The size of long is {0}.", sizeof(long));
        }

        public unsafe static void HyphenGreaterThan()
        {
            // compile with: /unsafe
            Point pt = new Point();
            Point* pp = &pt;
            pp->x = 123;
            pp->y = 456;
            System.Console.WriteLine("{0} {1}", pt.x, pt.y);
        }
    }

    class Simple
    {
        public int a;
        public void b()
        {
            Console.WriteLine("You invoked the b() method!");
        }
    }

    struct SampleStruct
    {
        public int x;
        public int y;

        public SampleStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct Point
    {
        public int x, y;
    }

    class SampleClass
    {
        public string name;
        public int id;

        public SampleClass() { }

        public SampleClass(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
