using System;
using System.Collections.Generic;
namespace OOPCChapter2
{
    /*
     * Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type.
     * When the CLR boxes a value type, it wraps the value inside a System.Object and stores it on the managed heap.
     * Unboxing extracts the value type from the object. Boxing is implicit; unboxing is explicit.
     * The concept of boxing and unboxing underlies the C# unified view of the type system in which a value of any type can be treated as an object.
     * In the following example, the integer variable i is boxed and assigned to object o.
    */
    public static class BoxingUnboxing
    {
        public static void BasicBoxingUnboxing()
        {
            int i = 123;
            // The following line boxes i.
            object o = i;
            //The object o can then be unboxed and assigned to integer variable i:
            o = 123;
            i = (int)o;  // unboxing
        }

        public static void MixedListBoxing()
        {
            // String.Concat example.
            // String.Concat has many versions. Rest the mouse pointer on 
            // Concat in the following statement to verify that the version
            // that is used here takes three object arguments. Both 42 and
            // true must be boxed.
            Console.WriteLine(String.Concat("Answer", 42, true));


            // List example.
            // Create a list of objects to hold a heterogeneous collection 
            // of elements.
            List<object> mixedList = new List<object>();

            // Add a string element to the list. 
            mixedList.Add("First Group:");

            // Add some integers to the list. 
            for (int j = 1; j < 5; j++)
            {
                // Rest the mouse pointer over j to verify that you are adding
                // an int to a list of objects. Each element j is boxed when 
                // you add j to mixedList.
                mixedList.Add(j);
            }

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            // Display the elements in the list. Declare the loop variable by 
            // using var, so that the compiler assigns its type.
            foreach (var item in mixedList)
            {
                // Rest the mouse pointer over item to verify that the elements
                // of mixedList are objects.
                Console.WriteLine(item);
            }

            // The following loop sums the squares of the first group of boxed
            // integers in mixedList. The list elements are objects, and cannot
            // be multiplied or added to the sum until they are unboxed. The
            // unboxing must be done explicitly.
            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // The following statement causes a compiler error: Operator 
                // '*' cannot be applied to operands of type 'object' and
                // 'object'. 
                //sum += mixedList[j] * mixedList[j]);

                // After the list elements are unboxed, the computation does 
                // not cause a compiler error.
                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            // The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            Console.WriteLine("Sum: " + sum);

            // Output:
            // Answer42True
            // First Group:
            // 1
            // 2
            // 3
            // 4
            // Second Group:
            // 5
            // 6
            // 7
            // 8
            // 9
            // Sum: 30
            
        }

        public static void Boxing()
        {
            /*
             * Boxing is used to store value types in the garbage-collected heap. 
             * Boxing is an implicit conversion of a value type to the type object or to any interface type implemented by this value type. 
             * Boxing a value type allocates an object instance on the heap and copies the value into the new object.
             * This example converts an integer variable i to an object o by using boxing.
             * Then, the value stored in the variable i is changed from 123 to 456.
             * The example shows that the original value type and the boxed object use separate memory locations, and therefore can store different values.
            */
            int i = 123;

            // Boxing copies the value of i into object o.
            object o = i;

            // Change the value of i.
            i = 456;

            // The change in i doesn't affect the value stored in o.
            System.Console.WriteLine("The value-type value = {0}", i);
            System.Console.WriteLine("The object-type value = {0}", o);

            /* Output:
                The value-type value = 456
                The object-type value = 123
            */
        }

        public static void UnBoxing()
        {
            /*
             * Unboxing is an explicit conversion from the type object to a value type or from an interface type to a value type that implements the interface. 
             * An unboxing operation consists of:
             *  * Checking the object instance to make sure that it is a boxed value of the given value type.
             *  * Copying the value from the instance into the value-type variable.
             * The following example demonstrates a case of invalid unboxing and the resulting InvalidCastException.
             * Using try and catch, an error message is displayed when the error occurs.
            */

            int i = 123;
            object o = i;  // implicit boxing

            try
            {
                int j = (short)o;  // attempt to unbox

                //If you change the above statement to:
                //int j = (int)o;
                //the below line will be executed. else the catch block will be executed.
                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }
        }
    }
}
