using System;
namespace OOPCChapter1
{
    public static class LogicalConditionalAndNull
    {
        public static void LogicalAnd()
        {
            /*
             * Binary & operators are predefined for the integral types and bool.
             * For integral types, & computes the logical bitwise AND of its operands.
             * For bool operands, & computes the logical AND of its operands; that is, the result is true if and only if both its operands are true.
             * The & operator evaluates both operators regardless of the first one's value.
            */
            // The following two statements perform logical ANDs.
            Console.WriteLine(true & false); 
            Console.WriteLine(true & true);  

            // The following line performs a bitwise AND of F8 (1111 1000) and
            // 3F (0011 1111).
            //    1111 1000
            //    0011 1111
            //    ---------
            //    0011 1000 or 38
            Console.WriteLine("0x{0:x}", 0xf8 & 0x3f); 
        }

        public static void LogicalXor()
        {
            /*
             * Binary ^ operators are predefined for the integral types and bool. For integral types, ^ computes the bitwise exclusive-OR of its operands.
             * For bool operands, ^ computes the logical exclusive-or of its operands; that is, the result is true if and only if exactly one of its operands is true.
             * User-defined types can overload the ^ operator.
             * Operations on integral types are generally allowed on enumeration.
            */
            // Logical exclusive-OR

            // When one operand is true and the other is false, exclusive-OR 
            // returns True.
            Console.WriteLine(true ^ false);
            // When both operands are false, exclusive-OR returns False.
            Console.WriteLine(false ^ false);
            // When both operands are true, exclusive-OR returns False.
            Console.WriteLine(true ^ true);


            // Bitwise exclusive-OR

            // Bitwise exclusive-OR of 0 and 1 returns 1.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x1, 2));
            // Bitwise exclusive-OR of 0 and 0 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x0, 2));
            // Bitwise exclusive-OR of 1 and 1 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x1 ^ 0x1, 2));

            // With more than one digit, perform the exclusive-OR column by column.
            //    10
            //    11
            //    --
            //    01
            // Bitwise exclusive-OR of 10 (2) and 11 (3) returns 01 (1).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x2 ^ 0x3, 2));

            // Bitwise exclusive-OR of 101 (5) and 011 (3) returns 110 (6).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x5 ^ 0x3, 2));

            // Bitwise exclusive-OR of 1111 (decimal 15, hexadecimal F) and 0101 (5)
            // returns 1010 (decimal 10, hexadecimal A).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf ^ 0x5, 2));

            // Finally, bitwise exclusive-OR of 11111000 (decimal 248, hexadecimal F8)
            // and 00111111 (decimal 63, hexadecimal 3F) returns 11000111, which is 
            // 199 in decimal, C7 in hexadecimal.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf8 ^ 0x3f, 2));

            /*
                Output:
                True
                False
                False
                Bitwise result: 1
                Bitwise result: 0
                Bitwise result: 0
                Bitwise result: 1
                Bitwise result: 110
                Bitwise result: 1010
                Bitwise result: 11000111
            */
        }

        public static void LogicalOr()
        {
            /*
             * Binary | operators are predefined for the integral types and bool.
             * For integral types, | computes the bitwise OR of its operands.
             * For bool operands, | computes the logical OR of its operands; that is, the result is false if and only if both its operands are false.
             * User-defined types can overload the | operator
            */
            Console.WriteLine(true | false);  // logical or
            Console.WriteLine(false | false); // logical or
            Console.WriteLine("0x{0:x}", 0xf8 | 0x3f);   // bitwise or

            /*
                Output:
                True
                False
                0xff
            */
        }

        public static void ConditionalAnd()
        {
            /*
             * The conditional-AND operator (&&) performs a logical-AND of its bool operands, but only evaluates its second operand if necessary.
            */

            // Each method displays a message and returns a Boolean value. 
            // Method1 returns false and Method2 returns true. When & is used,
            // both methods are called. 
            Console.WriteLine("Regular AND:");
            if (Method1() & Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");

            // When && is used, after Method1 returns false, Method2 is 
            // not called.
            Console.WriteLine("\nShort-circuit AND:");
            if (Method1() && Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");

            // Output:
            // Regular AND:
            // Method1 called.
            // Method2 called.
            // At least one of the methods returned false.

            // Short-circuit AND:
            // Method1 called.
            // At least one of the methods returned false.
        }

        static bool Method1()
        {
            Console.WriteLine("Method1 called.");
            return false;
        }

        static bool Method2()
        {
            Console.WriteLine("Method2 called.");
            return true;
        }

        public static void ConditionalOr()
        {
            /*
             * The conditional-OR operator (||) performs a logical-OR of its bool operands. 
             * If the first operand evaluates to true, the second operand isn't evaluated. 
             * If the first operand evaluates to false, the second operator determines whether the OR expression as a whole evaluates to true or false.
            */
            // Example #1 uses Method1 and Method2 to demonstrate 
            // short-circuit evaluation.

            Console.WriteLine("Regular OR:");
            // The | operator evaluates both operands, even though after 
            // Method1 returns true, you know that the OR expression is
            // true.
            Console.WriteLine("Result is {0}.\n", Method3() | Method4());

            Console.WriteLine("Short-circuit OR:");
            // Method2 is not called, because Method1 returns true.
            Console.WriteLine("Result is {0}.\n", Method3() || Method4());


            // In Example #2, method Divisible returns True if the
            // first argument is evenly divisible by the second, and False
            // otherwise. Using the | operator instead of the || operator
            // causes a divide-by-zero exception.

            // The following line displays True, because 42 is evenly 
            // divisible by 7.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 7));

            // The following line displays False, because 42 is not evenly
            // divisible by 5.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 5));

            // The following line displays False when method Divisible 
            // uses ||, because you cannot divide by 0.
            // If method Divisible uses | instead of ||, this line
            // causes an exception.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 0));

            /*
                Output:
                Regular OR:
                Method1 called.
                Method2 called.
                Result is True.

                Short-circuit OR:
                Method1 called.
                Result is True.

                Divisible returns True.
                Divisible returns False.
                Divisible returns False.
            */
        }

        // Method1 returns true.
        static bool Method3()
        {
            Console.WriteLine("Method1 called.");
            return true;
        }

        // Method2 returns false.
        static bool Method4()
        {
            Console.WriteLine("Method2 called.");
            return false;
        }


        static bool Divisible(int number, int divisor)
        {
            // If the OR expression uses ||, the division is not attempted
            // when the divisor equals 0.
            return !(divisor == 0 || number % divisor != 0);

            // If the OR expression uses |, the division is attempted when
            // the divisor equals 0, and causes a divide-by-zero exception.
            // Replace the return statement with the following line to
            // see the exception.
            //return !(divisor == 0 | number % divisor != 0);
        }

        public static void NullCoalescing()
        {
            /*
             * It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
             * A nullable type can represent a value from the type’s domain, or the value can be undefined (in which case the value is null). 
             * You can use the ?? operator’s syntactic expressiveness to return an appropriate value (the right hand operand) when the left operand has a nullible type whose value is null. 
             * If you try to assign a nullable value type to a non-nullable value type without using the ?? operator, you will generate a compile-time error.
             * If you use a cast, and the nullable value type is currently undefined, an InvalidOperationException exception will be thrown.
             * The result of a ?? operator is not considered to be a constant even if both its arguments are constants.
             * More on Nullable Value Types later.
            */
            int? GetNullableInt()
            {
                return null;
            }

            string GetStringValue()
            {
                return null;
            }
            int? x = null;

            // Set y to the value of x if x is NOT null; otherwise,
            // if x = null, set y to -1.
            int y = x ?? -1;

            // Assign i to return value of the method if the method's result
            // is NOT null; otherwise, if the result is null, set i to the
            // default value of int.
            int i = GetNullableInt() ?? default(int);

            string s = GetStringValue();
            // Display the value of s if s is NOT null; otherwise, 
            // display the string "Unspecified".
            Console.WriteLine(s ?? "Unspecified");
        }

        public static void Conditional()
        {
            /*
             * The conditional operator (?:) returns one of two values depending on the value of a Boolean expression. 
             * The condition must evaluate to true or false. If condition is true, first_expression is evaluated and becomes the result. 
             * If condition is false, second_expression is evaluated and becomes the result. Only one of the two expressions is evaluated.
             * Either the type of first_expression and second_expression must be the same, or an implicit conversion must exist from one type to the other.
             * You can express calculations that might otherwise require an if-else construction more concisely by using the conditional operator. 
             * For example, the following code uses first an if statement and then a conditional operator to classify an integer as positive or negative.
            */
            int input = Convert.ToInt32(Console.ReadLine());
            string classify;

            // if-else construction.  
            if (input > 0)
                classify = "positive";
            else
                classify = "negative";

            // ?: conditional operator.  
            classify = (input > 0) ? "positive" : "negative";

            //Sin calculation: NOTE the new inline functions feature of C#

            double sinc(double x)
            {
                return x != 0.0 ? Math.Sin(x) / x : 1.0;
            }

            Console.WriteLine(sinc(0.2));
            Console.WriteLine(sinc(0.1));
            Console.WriteLine(sinc(0.0));
        }
    }
}
