using System;
namespace OOPCChapter1
{
    public static class AdditiveOperators
    {
        delegate void AddDelegate(int first, int other);
        public static void PlusBinary()
        {
            /*
             * Binary + operators are predefined for numeric and string types.
             * For numeric types, + computes the sum of its two operands.
             * When one or both operands are of type string, + concatenates the string representations of the operands.
             * Delegate types also provide a binary + operator, which performs delegate concatenation.
             * User-defined types can overload the unary + and binary + operators.
             * Operations on integral types are generally allowed on enumeration.
            */
            Console.WriteLine(+5);        // unary plus
            Console.WriteLine(5 + 5);     // addition
            Console.WriteLine(5 + .5);    // addition
            Console.WriteLine("5" + "5"); // string concatenation
            Console.WriteLine(5.0 + "5"); // string concatenation
            // note automatic conversion from double to string
            //Delgates
            AddDelegate delegateValue = (first, other) => { Console.WriteLine(first + other); };
            AddDelegate newAdd = (first, other) => { Console.WriteLine(first + other + 10); };
            delegateValue = delegateValue + newAdd;
            //alternatively you can also write:
            //delegateValue += newAdd;
            delegateValue(5, 10);
            /*
             * above statement would print: 15 and 25 in two lines.
            */

        }

        public static void MinusBinary()
        {
            /*
             * Binary - operators are predefined for all numeric and enumeration types to subtract the second operand from the first.
             * Delegate types also provide a binary - operator, which performs delegate removal.
             * User-defined types can overload the unary - and binary - operators.
            */
            int a = 5;
            Console.WriteLine(-a);
            Console.WriteLine(a - 1);
            Console.WriteLine(a - .5);
            /*
             * Output:
             * -5
             * 4
             * 4.5
            */
            AddDelegate delegateValue = (first, other) => { Console.WriteLine(first + other); };
            AddDelegate newAdd = (first, other) => { Console.WriteLine(first + other + 10); };
            delegateValue = delegateValue + newAdd;
            //alternatively you can also write:
            //delegateValue += newAdd;
            delegateValue(5, 10);
            /*
             * above statement would print: 15 and 25 in two lines.
            */
            delegateValue -= newAdd;
            /*
             * Don't be afraid of the warning in VS 2017!
             * The first part of warning only applies to removing lists of delegates.
             * In our code, we're removing a single delegate. 
             * The second part talks about ordering of delegates after a duplicate delegate was removed.
             * An event doesn't guarantee an order of execution for its subscribers, so it doesn't really affect us either - more on events later in the course.
            */
            delegateValue(5, 10);
            /*
             * above statement would now print only 15.
            */
        }
    }
}
