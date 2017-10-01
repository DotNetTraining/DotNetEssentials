using System;

namespace OOPCChapter1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            checkAge();
            Console.WriteLine("Finished!\nPress any key..!");
            Console.ReadKey();
        }

        static void printMultiplicationTable()
        {
            int number = 5;                                                 //Here 5 is an expression.
            for (int i = 1; i < 11; i++)
            {
                int value = number * i;
                Console.WriteLine("{0} X {1} = {2}", number, i, value);
            }
        }

        static void checkAge()
        {
            Console.Write("How old are you?: ");
            int age = Convert.ToInt32(Console.ReadLine());                  //Convert is a class in FCL for doing basic type conversions
            if (age < 18)
            {
                Console.Write("You are a minor!\nYou should go home!\nShould we send someone to drop you<y/n>: ");
                var response = Console.ReadLine();                          //notice the var keyword
                if (response.ToLower() == "y")                              //ToLower is a method in string data type
                    Console.WriteLine("Okay somebody will be here soon to send you home!");
                else
                {
                    Console.WriteLine("Fine, before you go here is the multiplication table of 5 for you!");
                    printMultiplicationTable();
                }
            }
            else
            {
                Console.WriteLine("Welcome!\nWhat kind of account do you have:");
                Console.WriteLine("\t1. Normal\t2. Executive\t3. Premium");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Here is your food menu!");
                        break;
                    case 2:
                        Console.Write("We hope you are having a good day!\nYou will enjoy the following today:");
                        break;
                    case 3:
                        Console.WriteLine("Sir! We are happy to have you today\nwe have a very special menu for you today:");
                        break;
                    default:
                        break;
                }
                displayMenu(option);
            }
        }

        static void displayMenu(int accountType)
        {
            if (accountType == 1)
                printNormalMenu();
            else if (accountType == 2)
                printExecutiveMenu();
            else if (accountType == 3)
                printPremiumMenu();
            else
                Console.WriteLine("This option is not a valid account type!");
        }

        static void printNormalMenu()
        {
            string[] items = new string[] { "Coke", "Regular Pizza", "Garlic Bread" };
            printFoodItems(1, items);
        }


        static void printExecutiveMenu()
        {
            string[] items = new string[] { "Apple Juice", "Thin crust Pizza", "Garlic Bread", "Pasta" };
            printFoodItems(2, items);
        }

        static void printPremiumMenu()
        {
            string[] items = new string[] { "Apple Juice", "Thin crust Pizza", "Garlic Bread", "Pasta" };
            printFoodItems(3, items);
        }

        static void printFoodItems(int stars, string[] foodItems)
        {
            foreach (var item in foodItems)
            {
                Console.WriteLine("{0} {1} {0}", getStars(stars), item);
            }
        }

        static string getStars(int stars)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < stars; i++)
                returnValue += "*";
            return returnValue;
        }
    }
}
