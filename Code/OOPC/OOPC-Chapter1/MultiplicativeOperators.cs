using System;
namespace OOPCChapter1
{
    public static class MultiplicativeOperators
    {
        public static void Asterisk()
        {
            /*
             * The multiplication operator (*), which computes the product of its operands.
             * Not to be confused with the dereference operator, which allows reading and writing to a pointer.
             * All numeric types have predefined multiplication operators.
            */
            Console.WriteLine(5 * 2);
            Console.WriteLine(-.5 * .2);
            Console.WriteLine(-.5m * .2m); // decimal type
        }

        public static void ForwardSlash()
        {
            /*
             * The division operator (/) divides its first operand by its second operand. All numeric types have predefined division operators.
             * User-defined types can overload the / operator (see operator). An overload of the / operator implicitly overloads the /= operator.
             * When you divide two integers, the result is always an integer. 
             * For example, the result of 7 / 3 is 2. To determine the remainder of 7 / 3, use the remainder operator (%). 
             * To obtain a quotient as a rational number or fraction, give the dividend or divisor type float or type double. 
             * You can assign the type implicitly if you express the dividend or divisor as a decimal by putting a digit to the right side of the decimal point,
             * as the following example shows.
            */
            Console.WriteLine("\nDividing 7 by 3.");
            // Integer quotient is 2, remainder is 1.
            Console.WriteLine("Integer quotient:           {0}", 7 / 3);
            Console.WriteLine("Negative integer quotient:  {0}", -7 / 3);
            Console.WriteLine("Remainder:                  {0}", 7 % 3);
            // Force a floating point quotient.
            float dividend = 7;
            Console.WriteLine("Floating point quotient:    {0}", dividend / 3);

            Console.WriteLine("\nDividing 8 by 5.");
            // Integer quotient is 1, remainder is 3.
            Console.WriteLine("Integer quotient:           {0}", 8 / 5);
            Console.WriteLine("Negative integer quotient:  {0}", 8 / -5);
            Console.WriteLine("Remainder:                  {0}", 8 % 5);
            // Force a floating point quotient.
            Console.WriteLine("Floating point quotient:    {0}", 8 / 5.0);
            // Output:
            //Dividing 7 by 3.
            //Integer quotient:           2
            //Negative integer quotient:  -2
            //Remainder:                  1
            //Floating point quotient:    2.33333333333333

            //Dividing 8 by 5.
            //Integer quotient:           1
            //Negative integer quotient:  -1
            //Remainder:                  3
            //Floating point quotient:    1.6
        }

        public static void PercentageOrModulo()
        {
            /*
             * The % operator computes the remainder after dividing its first operand by its second.
             * All numeric types have predefined remainder operators.
             * User-defined types can overload the % operator (see operator).
             * When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.
             * Note the round-off errors associated with the double type.
            */
            Console.WriteLine(5 % 2);       // int
            Console.WriteLine(-5 % 2);      // int
            Console.WriteLine(5.0 % 2.2);   // double
            Console.WriteLine(5.0m % 2.2m); // decimal
            Console.WriteLine(-5.2 % 2.0);  // double
            /*
             * Output:
             * 1
             * -1
             * 0.6
             * 0.6
             * -1.2
            */
        }
    }
}
