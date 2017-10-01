/*
 * Class: MainClass
 * Description: This program helps us in understanding the basic structure of a C# program and other basic building blocks
 * of a C# program like
 *      1. Variables
 *      2. Constants
 *      3. Operators (more advanced in class "BasicOperatorExample")
 *      4. Expressions
 *      5. Statements
 *      6. Conditionals
 *      7. Loops
 *      8. Methods
 * You will also learn about the naming conventions generally used in C# code.
*/
using System;

namespace OOPCChapter1
{
    class MainClass
    {
        /*
         * Constant definitions - generally you should define all the non changing values as 
         * constants (although you can use literals as well but that's not a recommended practice)
        */

        const string HELLO_WORLD = "Hello World!";
        const string CHECK_MORE = "Do you want to check more<y: yes/n: no>: ";
        const string FINISHED_MESSAGE = "Finished!\nPress any key..!";
        const string AGE_QUESTION = "How old are you?: ";
        const int AGE_LIMIT = 18;
        const string MINOR_MESSAGE_QUESTION = "You are a minor!\nYou should go home!\nShould we send someone to drop you<y/n>: ";
        const string YES_RESPONSE = "y";
        const string DROP_MESSAGE = "Okay somebody will be here soon to send you home!";
        const string MINOR_LEARNING_MESSAGE = "Fine, before you go here is the multiplication table of 5 for you!";
        const string ACCOUNT_TYPE_QUESTION = "Welcome!\nWhat kind of account do you have:";
        const string ACCOUNT_TYPES = "\t1. Normal\t2. Executive\t3. Premium";
        const int ACCOUNT_TYPE_NORMAL = 1;
        const int ACCOUNT_TYPE_EXECUTIVE = 2;
        const int ACCOUNT_TYPE_PREMIUM = 3;
        const string NORMAL_MESSAGE = "Here is your food menu!";
        const string EXECUTIVE_MESSAGE = "We hope you are having a good day!\nYou will enjoy the following today:";
        const string PREMIUM_MESSAGE = "Sir! We are happy to have you today\nwe have a very special menu for you today:";
        const string INVALID_OPTION_MESSAGE = "We are sorry but that's not a valid option!";
        const string STAR_SIGN = "*";
        const int NUMBER_FOR_MULTIPLICATION_TABLE = 5;
        const int LOWER_LIMIT_FOR_MULTIPLICATION_TABLE = 1;
        const int UPPER_LIMIT_FOR_MULTIPLICATION_TABLE = 11;

        public static void Main(string[] args)
        {
            Console.WriteLine(HELLO_WORLD);                              //You can call static methods from different classes by prefixing the class (Type) name with a dot (.) and then method name.
            bool getMore = true;
            while (getMore)                             //alternatively you can also write: while(getMore == true)
            {
                checkAge();                                                     //In the same class you can call the methods without an instance.
                Console.Write(CHECK_MORE);
                getMore = Console.ReadLine().ToLower() == YES_RESPONSE;      //"==" is a equality comparison operator, constants also facilitate re-use
            }
            Console.WriteLine(FINISHED_MESSAGE);
            Console.ReadKey();                                              //halt the program execution until a key press (NOTE: we are ignoring the key returned by the method)
        }

        static void checkAge()
        {
            Console.Write(AGE_QUESTION);
            int age = Convert.ToInt32(Console.ReadLine());                  //Convert is a class in FCL for doing basic type conversions
            if (age < AGE_LIMIT)
            {
                Console.Write(MINOR_MESSAGE_QUESTION);
                var response = Console.ReadLine();                          //notice the var keyword
                if (response.ToLower() == YES_RESPONSE)                              //ToLower is a method in string data type
                    Console.WriteLine(DROP_MESSAGE);
                else
                {
                    Console.WriteLine(MINOR_LEARNING_MESSAGE);
                    printMultiplicationTable();
                }
            }
            else
            {
                Console.WriteLine(ACCOUNT_TYPE_QUESTION);
                Console.WriteLine(ACCOUNT_TYPES);
                int option = Convert.ToInt32(Console.ReadLine());           //Switch is a conditional that can follow multiple branches.
                switch (option)
                {
                    case ACCOUNT_TYPE_NORMAL:                              //this path would be taken if the value of option is 1
                        Console.WriteLine(NORMAL_MESSAGE);
                        break;
                    case ACCOUNT_TYPE_EXECUTIVE:
                        Console.WriteLine(EXECUTIVE_MESSAGE);
                        break;
                    case ACCOUNT_TYPE_PREMIUM:
                        Console.WriteLine(PREMIUM_MESSAGE);
                        break;
                    default:                                                //this is the default path if none of the above conditions are met
                        Console.WriteLine();
                        break;
                }
                displayMenu(option);
            }
        }

        static void printMultiplicationTable()
        {
            for (int i = LOWER_LIMIT_FOR_MULTIPLICATION_TABLE; i < UPPER_LIMIT_FOR_MULTIPLICATION_TABLE; i++)
            {
                int value = NUMBER_FOR_MULTIPLICATION_TABLE * i; //assigning the value of number multiplied to counter to "value" variable of type "int" integer.
                //a statement can span across multiple lines
                Console.WriteLine("{0} X {1} = {2}"
                                  , NUMBER_FOR_MULTIPLICATION_TABLE
                                  , i, value); //note {0}, {1} and {2} in the string, C# allows us to define place holders and perform string intrapolation (formatting).
            }
        }

        static void displayMenu(int accountType)
        {
            if (accountType == ACCOUNT_TYPE_NORMAL)               //if is another conditional - generally it is binary (i.e. if/else but you can also use if/else if/else style to perform checks similar to "switch" conditional. If gives you more control than "switch".
                printNormalMenu();
            else if (accountType == ACCOUNT_TYPE_EXECUTIVE)          //else if checks the condition only when the if condition is not met (NOTE: as you can see we can line up multiple "else if"s.
                printExecutiveMenu();
            else if (accountType == ACCOUNT_TYPE_PREMIUM)
                printPremiumMenu();
            else
                Console.WriteLine(INVALID_OPTION_MESSAGE);
        }

        static void printNormalMenu()
        {
            //We are creating an array of strings to show in food menu - in a real world application this data might come from some database/service or other persistant source.
            string[] items = new string[] { "Coke", "Regular Pizza", "Garlic Bread" };
            printFoodItems(ACCOUNT_TYPE_NORMAL, items);
        }


        static void printExecutiveMenu()
        {
            string[] items = new string[] { "Apple Juice", "Delux Pan Pizza", "Garlic Bread", "Pasta" };
            printFoodItems(ACCOUNT_TYPE_EXECUTIVE, items);
        }

        static void printPremiumMenu()
        {
            string[] items = new string[] { "Shampagne", "Cheese Burst Pizza", "Chicken Burger", "Pasta", "Chocolate cake", "Ice Cream" };
            printFoodItems(ACCOUNT_TYPE_PREMIUM, items);
        }

        static void printFoodItems(int stars, string[] foodItems)
        {
            foreach (var item in foodItems)     //"foreach" loop is used to iterate over items in a collection (more on this later in the course)
            {
                Console.WriteLine("{0} {1} {0}", getStars(stars), item);
            }
        }

        static string getStars(int stars)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < stars; i++)     //"for" loop is used to execute a block of code until a specific condition is met.
                returnValue += STAR_SIGN;
            return returnValue;
        }
    }
}
