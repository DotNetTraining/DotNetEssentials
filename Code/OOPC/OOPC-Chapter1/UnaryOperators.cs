using System;
namespace OOPCChapter1
{
    public static class UnaryOperators
    {
        public static void UnaryPlus()
        {
            int value = 5;
            Console.WriteLine(+value);        // unary plus is identity: will print 5
            Console.WriteLine(++value);       // unary plus plus before a value is prefix increment: will print 6
            Console.WriteLine(value++);       // unary plus plus after a value is postfix increment: will print 6 but the value would be 7 after printing
            Console.WriteLine(value);
        }

        public static void UnaryMinus()
        {
            int value = 5;
            Console.WriteLine(-value);        // unary minus is negation: will print -5
            Console.WriteLine(--value);       // unary minus minus before a value is prefix decrement: will print 4
            Console.WriteLine(value--);       // unary minus minus after a value is postfix decrement: will print 4 but the value would be 3 after printing
            Console.WriteLine(value);
        }

        public static void UnaryExclamation()
        {
            /*
             * The logical negation operator (!) is a unary operator that negates its operand.
             * It is defined for bool and returns true if and only if its operand is false.
            */
            bool value = true;
            Console.WriteLine(!value);
            value = false;
            Console.WriteLine(!value);
        }

        public static void UnaryTilde()
        {
            /*
             * The ~ operator performs a bitwise complement operation on its operand, which has the effect of reversing each bit.
             * Bitwise complement operators are predefined for int, uint, long, and ulong.
             * NOTE: The ~ symbol also is used to declare finalizers. we will discuss about finalizers later in the course.
            */
            int[] values = { 0, 0x111, 0xfffff, 0x8888, 0x22000022 };
            foreach (int v in values)
            {
                Console.WriteLine("~0x{0:x8} = 0x{1:x8}", v, ~v);
            }
            /*
             * This will output:
             * ~0x00000000 = 0xffffffff
             * ~0x00000111 = 0xfffffeee
             * ~0x000fffff = 0xfff00000
             * ~0x00008888 = 0xffff7777
             * ~0x22000022 = 0xddffffdd
            */
        }
    }
}
