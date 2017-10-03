using System;

namespace OOPCChapter2
{
    class MainClass
    {
        const string STAR_LINES = "****************************";
        const string WELCOME_MESSAGE = "Welcome to Chapter 2!";
        public static void Main(string[] args)
        {
            Console.WriteLine("{0}\n{1}\n{0}", STAR_LINES, WELCOME_MESSAGE);
            Arrays.ImplicitlyTypedArraysInObjectInitializers();
        }
    }
}
