using System;
namespace OOPCChapter3
{
    public class NullableTypes
    {
        public void BasicExample()
        {
            int? num1 = 10;
            int? num2 = null;
            if (num1 >= num2)
            {
                Console.WriteLine("num1 is greater than or equal to num2");
            }
            else
            {
                // This clause is selected, but num1 is not less than num2.
                Console.WriteLine("num1 >= num2 returned false (but num1 < num2 also is false)");
            }

            if (num1 < num2)
            {
                Console.WriteLine("num1 is less than num2");
            }
            else
            {
                // The else clause is selected again, but num1 is not greater than
                // or equal to num2.
                Console.WriteLine("num1 < num2 returned false (but num1 >= num2 also is false)");
            }

            if (num1 != num2)
            {
                // This comparison is true, num1 and num2 are not equal.
                Console.WriteLine("Finally, num1 != num2 returns true!");
            }

            // Change the value of num1, so that both num1 and num2 are null.
            num1 = null;
            if (num1 == num2)
            {
                // The equality comparison returns true when both operands are null.
                Console.WriteLine("num1 == num2 returns true when the value of each is null");
            }

            /* Output:
             * num1 >= num2 returned false (but num1 < num2 also is false)
             * num1 < num2 returned false (but num1 >= num2 also is false)
             * Finally, num1 != num2 returns true!
             * num1 == num2 returns true when the value of each is null
             */
        }

        public void NullCoalescingOperator()
        {
            //The ?? operator defines a default value that is returned when a nullable type is assigned to a non-nullable type.
            int? c = null;

            // d = c, unless c is null, in which case d = -1.
            int d = c ?? -1;

            //This operator can also be used with multiple nullable types. For example:
            int? e = null;
            int? f = null;

            // g = e or f, unless e and f are both null, in which case g = -1.
            int g = e ?? f ?? -1;
        }

        public void SafeCasting()
        {
            bool? test = null;
            // Other code that may or may not  
            // give a value to test.  
            if (!test.HasValue) //check for a value  
            {
                // Assume that IsInitialized  
                // returns either true or false.  
                test = IsInitialized();
            }
            if ((bool)test) //now this cast is safe
                // or simple like this
                //if(test??false)
            {
                Console.WriteLine("We have now safely extracted the result!");
            }
        }
        private bool IsInitialized()
        {
            Random random = new Random();
            int value = random.Next(20000);
            return value % 2 == 0;
        }

        public void IdentifyNullableType()
        {
            int? a = 10;
            bool? b = null;
            double? c = null;
            char? d = null;
            int nonNull = 22;
            checkAndProcess(a);
            checkAndProcess(b);
            checkAndProcess(c);
            checkAndProcess(d);
            checkAndProcess(nonNull);
        }

        private void checkAndProcess(object input)
        {
            if (input != null)
            {
                Type type = input.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    Console.WriteLine($"Nullable type found:\nValue: {input ?? "Null!"}");
                else
                    Console.WriteLine($"Value: {input}");
            }
            else
                Console.WriteLine("Value: Null");
        }


    }
}