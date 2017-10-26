using System;
namespace OOPCChapter4
{
    public class LambdaExpressions
    {
        //simple delegate
        delegate int DoSomething(int number);
        public static void SimpleLambdaExample()
        {
            //you can assign an anonymous function to an instance of DoSomething
            DoSomething tenTimes = (number) => number * 10;
            Console.WriteLine($"Ten times 4 is {tenTimes(4)}");
            //You can also do something like this to print the table of a given number
            Action<int> simpleTableLambda = (int a) => { for (int i = 1; i <= 10; i++) Console.WriteLine($"{a} X {i} = {a * i}"); };
            simpleTableLambda(5);
            //Action is a Delegate that doesn't return a value, there are several overlaods of Action to add upto 16 parameters
            Action withoutParameters = () => {Console.WriteLine("I am Action without parameters!");};
            withoutParameters();
            Action<string, string> twoParameters = (name, title) => Console.WriteLine($"Hello {title} {name}"); //curly braces are not required if it's a one liner
            twoParameters("Julia", "Ms.");

            //Func<T> is a delegate that returns a value of type T
            Func<string> getGreeting = () => 
            {
                if (DateTime.Now.Hour < 12)
                    return "Good Morning!";
                else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 16)
                    return "Good Afternoon!";
                else if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 21)
                    return "Good Evening!";
                else
                    return "Good Night!";
            };
            System.Console.WriteLine($"{getGreeting()}");
            //There are several overloads of Func delgate, it supports upto 16 input parameters
            Func<int, int, bool> comparer = (number1, number2) => number1 == number2;   //return statement is not required if it's a one liner
            Console.WriteLine($"2 equals 3 is a {comparer(2, 3)} statement!");

        }
    }
}