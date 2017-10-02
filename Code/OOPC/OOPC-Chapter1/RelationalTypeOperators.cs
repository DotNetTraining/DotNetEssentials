using System;
namespace OOPCChapter1
{
    public static class RelationalTypeOperators
    {
        public static void LessThan()
        {
            /*
             * All numeric and enumeration types define a "less than" relational operator (<) that returns true if the first operand is less than the second, false otherwise.
             * User-defined types can overload the < operator. If < is overloaded, > must also be overloaded. 
             * When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.
            */
            Console.WriteLine(1 < 1.1);
            Console.WriteLine(1.1 < 1.1);
            /*
                Output:
                True
                False
            */
        }

        public static void GreaterThan()
        {
            /*
             * All numeric and enumeration types define a "greater than" relational operator (>) that returns true if the first operand is greater than the second, false otherwise.
             * User-defined types can overload the > operator.
            */
            Console.WriteLine(1.1 > 1);
            Console.WriteLine(1.1 > 1.1);
            /*
                Output:
                True
                False
            */
        }

        public static void LessThanEqualTo()
        {
            /*
             * All numeric and enumeration types define a "less than or equal" relational operator (<=) that returns true if the first operand is less than or equal to the second, false otherwise.
             * User-defined types can overload the <= operator. If <= is overloaded, >= must also be overloaded.
             * Operations on integral types are generally allowed on enumeration.
            */
            Console.WriteLine(1 <= 1.1);
            Console.WriteLine(1.1 <= 1.1);
            /*
                Output:
                True
                True
            */
        }

        public static void GreaterThanEqualTo()
        {
            /*
             * All numeric and enumeration types define a "greater than or equal" relational operator, >= that returns true if the first operand is greater than or equal to the second, false otherwise.
             * User-defined types can overload the >= operator.
             * If >= is overloaded, <= must also be overloaded. Operations on integral types are generally allowed on enumeration.
            */
            Console.WriteLine(1.1 >= 1);
            Console.WriteLine(1.1 >= 1.1);
            /*
                Output:
                True
                True
            */
        }

        public static void Is()
        {
            /*
             * Checks if an object is compatible with a given type, or (starting with C# 7) tests an expression against a pattern.
             * The is keyword evaluates type compatibility at runtime. It determines whether an object instance or the result of an expression can be converted to a specified type.
             * The is statement is true if:
             *      expr is an instance of the same type as type.
             *      expr is an instance of a type that derives from type. In other words, the result of expr can be upcast to an instance of type.
             *      expr has a compile-time type that is a base class of type, and expr has a runtime type that is type or is derived from type. The compile-time type of a variable is the variable's type as defined in its declaration. The runtime type of a variable is the type of the instance that is assigned to that variable.
             *      expr is an instance of a type that implements the type interface.
            */
            var cl1 = new Class1();
            Console.WriteLine(cl1 is IFormatProvider);
            Console.WriteLine(cl1 is Object);
            Console.WriteLine(cl1 is Class1);
            Console.WriteLine(cl1 is Class2);
            Console.WriteLine();

            var cl2 = new Class2();
            Console.WriteLine(cl2 is IFormatProvider);
            Console.WriteLine(cl2 is Class2);
            Console.WriteLine(cl2 is Class1);
            Console.WriteLine();

            Class1 cl = cl2;
            Console.WriteLine(cl is Class1);
            Console.WriteLine(cl is Class2);

            // The example displays the following output:
            //     True
            //     True
            //     True
            //     False
            //     
            //     True
            //     True
            //     True
            //     
            //     True
            //     True
        }

        public static void As()
        {
            /*
             * You can use the as operator to perform certain types of conversions between compatible reference types or nullable types.
             * The as operator is like a cast operation. However, if the conversion isn't possible, as returns null instead of raising an exception.
             * Note that the as operator performs only reference conversions, nullable conversions, and boxing conversions. 
             * The as operator can't perform other conversions, such as user-defined conversions, which should instead be performed by using cast expressions.
            */
            Derived d = new Derived();

            Base b = d as Base;
            if (b != null)
            {
                Console.WriteLine(b.ToString());
            }

            object[] objArray = new object[6];
            objArray[0] = new Class1();
            objArray[1] = new Class1();
            objArray[2] = "hello";
            objArray[3] = 123;
            objArray[4] = 123.4;
            objArray[5] = null;

            for (int i = 0; i < objArray.Length; ++i)
            {
                string s = objArray[i] as string;
                Console.Write("{0}:", i);
                if (s != null)
                {
                    Console.WriteLine("'" + s + "'");
                }
                else
                {
                    Console.WriteLine("not a string");
                }
            }
        }

        public class Class1 : IFormatProvider
        {
            public object GetFormat(Type t)
            {
                if (t.Equals(this.GetType()))
                    return this;
                return null;
            }
        }

        public class Class2 : Class1
        {
            public int Value { get; set; }
        }

        class Base
        {
            public override string ToString()
            {
                return "Base";
            }
        }
        class Derived : Base
        { }
    }
}
