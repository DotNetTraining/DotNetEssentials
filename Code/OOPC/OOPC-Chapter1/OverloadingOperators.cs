using System;
namespace OOPCChapter1
{
    /*
     * This example shows how you can use operator overloading to create a complex number class Complex that defines complex addition.
     * Don't worry too much about the concepts like Structs and classes - we will cover them in great detail later, right now we are focusing only on the operators.
     * You can use the same technique of overloading operators on classes and structs alike.
    */
    public struct Complex
    {
        public int real;
        public int imaginary;

        // Constructor.
        public Complex(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        // Specify which operator to overload (+), 
        // the types that can be added (two Complex objects),
        // and the return type (Complex).
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }

        // Override the ToString() method to display a complex number 
        // in the traditional format:
        public override string ToString()
        {
            return (System.String.Format("{0} + {1}i", real, imaginary));
        }
    }

    public static class OverloadingOperators
    {
        public static void TestOverload()
        {
            Complex num1 = new Complex(2, 3);
            Complex num2 = new Complex(3, 4);

            // Add two Complex objects by using the overloaded + operator.
            Complex sum = num1 + num2;

            // Print the numbers and the sum by using the overridden 
            // ToString method.
            System.Console.WriteLine("First complex number:  {0}", num1);
            System.Console.WriteLine("Second complex number: {0}", num2);
            System.Console.WriteLine("The sum of the two numbers: {0}", sum);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
