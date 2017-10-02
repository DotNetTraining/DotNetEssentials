using System;
namespace OOPCChapter1
{
    public static class EqualityOperators
    {
        public static void EqualTo()
        {
            /*
             * For predefined value types, the equality operator (==) returns true if the values of its operands are equal, false otherwise.
             * For reference types other than string, == returns true if its two operands refer to the same object. 
             * For the string type, == compares the values of the strings.
             * User-defined value types can overload the == operator.
             * So can user-defined reference types, although by default == behaves as described above for both predefined and user-defined reference types.
             * If == is overloaded, != must also be overloaded.
             * Operations on integral types are generally allowed on enumeration.
            */

            // Numeric equality: True
            Console.WriteLine((2 + 2) == 4);

            // Reference equality: different objects, 
            // same boxed value: False.
            object s = 1;
            object t = 1;
            Console.WriteLine(s == t);

            // Define some strings:
            string a = "hello";
            string b = String.Copy(a);
            string c = "hello";

            // Compare string values of a constant and an instance: True
            Console.WriteLine(a == b);

            // Compare string references; 
            // a is a constant but b is an instance: False.
            Console.WriteLine((object)a == (object)b);

            // Compare string references, both constants 
            // have the same value, so string interning
            // points to same reference: True.
            Console.WriteLine((object)a == (object)c);

            /*
                Output:
                True
                False
                True
                False
                True
            */
        }

        public static void NotEqualTo()
        {
            /*
             * The inequality operator (!=) returns false if its operands are equal, true otherwise.
             * Inequality operators are predefined for all types, including string and object. 
             * User-defined types can overload the != operator.
             * For predefined value types, the inequality operator (!=) returns true if the values of its operands are different, false otherwise. 
             * For reference types other than string, != returns true if its two operands refer to different objects. 
             * For the string type, != compares the values of the strings.
             * User-defined value types can overload the != operator. 
             * So can user-defined reference types, although by default != behaves as described above for both predefined and user-defined reference types. 
             * If != is overloaded, == must also be overloaded. 
             * Operations on integral types are generally allowed on enumeration.
            */

            // Numeric inequality:
            Console.WriteLine((2 + 2) != 4);

            // Reference equality: two objects, same boxed value
            object s = 1;
            object t = 1;
            Console.WriteLine(s != t);

            // String equality: same string value, same string objects
            string a = "hello";
            string b = "hello";

            // compare string values
            Console.WriteLine(a != b);

            // compare string references
            Console.WriteLine((object)a != (object)b);

            /*
                Output:
                False
                True
                False
                False
            */
        }
    }
}
