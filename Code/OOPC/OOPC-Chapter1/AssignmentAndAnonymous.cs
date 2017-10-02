using System;
using System.Linq;
namespace OOPCChapter1
{
    public static class AssignmentAndAnonymous
    {
        public static void Assignment()
        {
            /*
             * The assignment operator (=) stores the value of its right-hand operand in the storage location, property, or indexer denoted by its left-hand operand and returns the value as its result.
             * The operands must be of the same type (or the right-hand operand must be implicitly convertible to the type of the left-hand operand).
             * The assignment operator cannot be overloaded.
             * However, you can define implicit conversion operators for a type, which enable you to use the assignment operator with those types.
            */
            double x;
            int i;
            i = 5; // int to int assignment
            x = i; // implicit conversion from int to double
            i = (int)x; // needs cast
            Console.WriteLine("i is {0}, x is {1}", i, x);
            object obj = i;
            Console.WriteLine("boxed value = {0}, type is {1}",
                      obj, obj.GetType());
            i = (int)obj;
            Console.WriteLine("unboxed: {0}", i);

            /*
                Output:
                i is 5, x is 5
                boxed value = 5, type is System.Int32
                unboxed: 5
            */
        }

        public static void Lambda()
        {
            /*
             * The => token is called the lambda operator and is used in lambda expressions.
             * The => operator has the same precedence as the assignment operator (=) and is right-associative.
             * You can specify the type of the input variable explicitly or let the compiler infer it; in either case, the variable is strongly typed at compile time.
             * When you specify a type, you must enclose the type name and the variable name in parentheses.
            */
            //Simple delegate and lambda (more on delegates later)
            Delegate delegateEx;
            delegateEx = new Action<String>(x => Console.WriteLine(x));

            //LINQ using Lambda (LINQ - stands for 'L'anguage 'IN'tegrated 'Q'uery. C# support querying collections using Lambda and LINQ syntax.
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };  
            Console.WriteLine("Example that uses a lambda expression:");
            var shortDigits = digits.Where((digit, index) => digit.Length < index);
            foreach (var sD in shortDigits)
            {
                Console.WriteLine(sD);
            }

            // Output:  
            // Example that uses a lambda expression:  
            // five  
            // six  
            // seven  
            // eight  
            // nine
        }

        public static void Associativity()
        {
            
        }
    }
}
