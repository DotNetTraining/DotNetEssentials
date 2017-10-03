using System;
namespace OOPCChapter2
{
    public static class ValueTypes
    {
        /*
         * The struct type is suitable for representing lightweight objects such as Point, Rectangle, and Color.
         * Although it is just as convenient to represent a point as a class with Auto-Implemented Properties, a struct might be more efficient in some scenarios.
         * For example, if you declare an array of 1000 Point objects, you will allocate additional memory for referencing each object; in this case, a struct would be less expensive.
         * Because the .NET Framework contains an object called Point, the struct in this example is named "CoOrds" instead.
        */

        public struct CoOrds
        {
            public int x, y;

            public CoOrds(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }

        public static void DeclareAndInitStruct()
        {
            /*
             * This example demonstrates struct initialization using both default and parameterized constructors.
            */
            // Initialize:   
            CoOrds coords1 = new CoOrds();
            CoOrds coords2 = new CoOrds(10, 10);

            // Display results:
            Console.Write("CoOrds 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            Console.Write("CoOrds 2: ");
            Console.WriteLine("x = {0}, y = {1}", coords2.x, coords2.y);

            /* Output:
                CoOrds 1: x = 0, y = 0
                CoOrds 2: x = 10, y = 10
            */
        }

        public static void ValueTypeFeatureStruct()
        {
            /*
             * This example demonstrates a feature that is unique to structs. 
             * It creates a CoOrds object without using the new operator. If you replace the word struct with the word class, the program will not compile.
            */
            // Declare an object:
            CoOrds coords1;

            // Initialize:
            coords1.x = 10;
            coords1.y = 20;

            // Display results:
            Console.Write("CoOrds 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);
        }

        /*
         * The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list.
         * Usually it is best to define an enum directly within a namespace so that all classes in the namespace can access it with equal convenience.
         * However, an enum can also be nested within a class or struct. 1
         * By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1.
         * For example, in the following enumeration, Sat is 0, Sun is 1, Mon is 2, and so forth.
        */

        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        public static void EnumBasic()
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);
            /* Output:
                Sun = 0
                Fri = 5
            */
        }


        /*
         * In the following example, the base-type option is used to declare an enum whose members are of type long. 
         * Notice that even though the underlying type of the enumeration is long, the enumeration members still must be explicitly converted to type long by using a cast.
        */

        enum Range : long { Max = 2147483648L, Min = 255L };
        public static void EnumBaseType()
        {
            long x = (long)Range.Max;
            long y = (long)Range.Min;
            Console.WriteLine("Max = {0}", x);
            Console.WriteLine("Min = {0}", y);

            /* Output:
                Max = 2147483648
                Min = 255
            */
        }

        /*
         * The following code example illustrates the use and effect of the FlagsAttribute attribute on an enum declaration.
         * FlagAttribute: Indicates that an enumeration can be treated as a bit field; that is, a set of flags. (more on attributes later)
         * We recommend reading about Hexa-Decimal notation (used below - visit https://en.wikipedia.org/wiki/Hexadecimal)
        */

        // Add the attribute Flags or FlagsAttribute.
        [Flags]
        public enum CarOptions
        {
            // The flag for SunRoof is 0001.
            SunRoof = 0x01,
            // The flag for Spoiler is 0010.
            Spoiler = 0x02,
            // The flag for FogLights is 0100.
            FogLights = 0x04,
            // The flag for TintedWindows is 1000.
            TintedWindows = 0x08,
        }

        public static void BitWiseFlagsEnum()
        {
            // The bitwise OR of 0001 and 0100 is 0101.
            CarOptions options = CarOptions.SunRoof | CarOptions.FogLights;

            // Because the Flags attribute is specified, Console.WriteLine displays
            // the name of each enum element that corresponds to a flag that has
            // the value 1 in variable options.
            Console.WriteLine(options);
            // The integer value of 0101 is 5.
            Console.WriteLine((int)options);

            /* Output:
                SunRoof, FogLights
                5
            */
        }
    }
}
