using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPCChapter2
{
    public static class Strings
    {
        public static void StringBasics()
        {
            //You can declare and initialize strings in various ways, as shown in the following example:
            // Declare without initializing.
            string message1;

            // Initialize to null.
            string message2 = null;

            // Initialize as an empty string.
            // Use the Empty constant instead of the literal "".
            string message3 = System.String.Empty;

            //Initialize with a regular string literal.
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // Initialize with a verbatim string literal.
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // Use System.String if you prefer.
            System.String greeting = "Hello World!";

            // In local variables (i.e. within a method body)
            // you can use implicit typing.
            var temp = "I'm still a strongly-typed System.String!";

            // Use a const string to prevent 'message4' from
            // being used to store another string value.
            const string message4 = "You can't get rid of me!";

            // Use the String constructor only when creating
            // a string from a char*, char[], or sbyte*. See
            // System.String documentation for details.
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);
        }

        public static void ImmutabilityOfStringObjects()
        {
            /*
             * String objects are immutable: they cannot be changed after they have been created.
             * All of the String methods and C# operators that appear to modify a string actually return the results in a new string object.
             * In the following example, when the contents of s1 and s2 are concatenated to form a single string, the two original strings are unmodified. The += operator creates a new string that contains the combined contents.
             * That new object is assigned to the variable s1, and the original object that was assigned to s1 is released for garbage collection because no other variable holds a reference to it.
            */

            string s1 = "A string is more ";
            string s2 = "than the sum of its chars.";

            // Concatenate s1 and s2. This actually creates a new
            // string object and stores it in s1, releasing the
            // reference to the original object.
            s1 += s2;

            System.Console.WriteLine(s1);
            // Output: A string is more than the sum of its chars.

            /*
             * Because a string "modification" is actually a new string creation, you must use caution when you create references to strings. 
             * If you create a reference to a string, and then "modify" the original string, the reference will continue to point to the original object instead of the new object that was created when the string was modified. 
             * The following code illustrates this behavior:
            */
            string s3 = "Hello ";
            string s4 = s1;
            s3 += "World";

            System.Console.WriteLine(s4);
            //Output: Hello
        }

        public static void RegularVsVerbatimStringLiterals()
        {
            //Use regular string literals when you must embed escape characters provided by C#, as shown in the following example:

            string columns = "Column 1\tColumn 2\tColumn 3";
            //Output: Column 1        Column 2        Column 3

            string rows = "Row 1\r\nRow 2\r\nRow 3";
            /* Output:
              Row 1
              Row 2
              Row 3
            */

            string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
            //Output: "The Æolean Harp", by Samuel Taylor Coleridge

            /*
             * Use verbatim strings for convenience and better readability when the string text contains backslash characters, for example in file paths. 
             * Because verbatim strings preserve new line characters as part of the string text, they can be used to initialize multiline strings. 
             * Use double quotation marks to embed a quotation mark inside a verbatim string. 
             * The following example shows some common uses for verbatim strings:
            */

            string filePath = @"C:\Users\scoleridge\Documents\";
            //Output: C:\Users\scoleridge\Documents\

            string text = @"My pensive SARA ! thy soft cheek reclined
                            Thus on mine arm, most soothing sweet it is
                            To sit beside our Cot,...";
            /* Output:
            My pensive SARA ! thy soft cheek reclined
               Thus on mine arm, most soothing sweet it is
               To sit beside our Cot,... 
            */

            string quote = @"Her name was ""Sara.""";
            //Output: Her name was "Sara."
        }

        public static void FormatStrings()
        {
            /*
             * A format string is a string whose contents can be determined dynamically at runtime. 
             * You create a format string by using the static Format method and embedding placeholders in braces that will be replaced by other values at runtime. 
             * The following example uses a format string to output the result of each iteration of a loop:
            */

            // Get user input.
            System.Console.WriteLine("Enter a number");
            string input = System.Console.ReadLine();

            // Convert the input string to an int.
            int j;
            System.Int32.TryParse(input, out j);

            // Write a different string each iteration.
            string s;
            for (int i = 0; i < 10; i++)
            {
                // A simple format string with no alignment formatting.
                s = System.String.Format("{0} times {1} = {2}", i, j, (i * j));
                System.Console.WriteLine(s);
            }
        }

        public static void SubStrings()
        {
            string s3 = "Visual C# Express";
            System.Console.WriteLine(s3.Substring(7, 2));
            // Output: "C#"

            System.Console.WriteLine(s3.Replace("C#", "Basic"));
            // Output: "Visual Basic Express"

            // Index values are zero-based
            int index = s3.IndexOf("C");
            // index = 7
        }

        public static void AccessingIndividualCharacters()
        {
            /*
             * You can use array notation with an index value to acquire read-only access to individual characters, as in the following example:
            */
            string s5 = "Printing backwards";

            for (int i = 0; i < s5.Length; i++)
            {
                System.Console.Write(s5[s5.Length - i - 1]);
            }
            // Output: "sdrawkcab gnitnirP"
        }

        public static void StringBuilder()
        {
            /*
             * If the String methods do not provide the functionality that you must have to modify individual characters in a string,
             * you can use a StringBuilder object to modify the individual chars "in-place",
             * and then create a new string to store the results by using the StringBuilder methods. 
             * In the following example, assume that you must modify the original string in a particular way and then store the results for future use:
            */
            string question = "hOW DOES mICROSOFT wORD DEAL WITH THE cAPS lOCK KEY?";
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(question);

            for (int j = 0; j < stringBuilder.Length; j++)
            {
                if (System.Char.IsLower(stringBuilder[j]) == true)
                    stringBuilder[j] = System.Char.ToUpper(stringBuilder[j]);
                else if (System.Char.IsUpper(stringBuilder[j]) == true)
                    stringBuilder[j] = System.Char.ToLower(stringBuilder[j]);
            }
            // Store the new string.
            string corrected = stringBuilder.ToString();
            System.Console.WriteLine(corrected);
            // Output: How does Microsoft Word deal with the Caps Lock key?

            /*
             * Using StringBuilder for Fast String Creation
             * String operations in .NET are highly optimized and in most cases do not significantly impact performance. 
             * However, in some scenarios such as tight loops that are executing many hundreds or thousands of times, string operations can affect performance. 
             * The StringBuilder class creates a string buffer that offers better performance if your program performs many string manipulations. 
             * The StringBuilder string also enables you to reassign individual characters, something the built-in string data type does not support. 
             * This code, for example, changes the content of a string without creating a new string:
            */

            System.Text.StringBuilder builder = new System.Text.StringBuilder("Rat: the ideal pet");
            builder[0] = 'C';
            System.Console.WriteLine(builder.ToString());
            System.Console.ReadLine();

            //Outputs Cat: the ideal pet

            //In this example, a StringBuilder object is used to create a string from a set of numeric types:
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            // Create a string composed of numbers 0 - 9
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i.ToString());
            }
            System.Console.WriteLine(sb);  // displays 0123456789

            // Copy one character of the string (not possible with a System.String)
            sb[0] = sb[9];

            System.Console.WriteLine(sb);  // displays 9123456789
        }

        public static void NullAndEmptyStrings()
        {
            /*
             * An empty string is an instance of a String object that contains zero characters. 
             * Empty strings are used often in various programming scenarios to represent a blank text field. 
             * You can call methods on empty strings because they are valid String objects. 
             * Empty strings are initialized as follows:
            */
            string s = String.Empty;

            /*
             * By contrast, a null string does not refer to an instance of a String object and any attempt to call a method on a null string causes a NullReferenceException. 
             * However, you can use null strings in concatenation and comparison operations with other strings. 
             * The following examples illustrate some cases in which a reference to a null string does and does not cause an exception to be thrown:
            */

            string str = "hello";
            string nullStr = null;
            string emptyStr = String.Empty;

            string tempStr = str + nullStr;
            // Output of the following line: hello
            Console.WriteLine(tempStr);

            bool b = (emptyStr == nullStr);
            // Output of the following line: False
            Console.WriteLine(b);

            // The following line creates a new empty string.
            string newStr = emptyStr + nullStr;

            // Null strings and empty strings behave differently. The following
            // two lines display 0.
            Console.WriteLine(emptyStr.Length);
            Console.WriteLine(newStr.Length);
            // The following line raises a NullReferenceException.
            //Console.WriteLine(nullStr.Length);

            // The null character can be displayed and counted, like other chars.
            string s1 = "\x0" + "abc";
            string s2 = "abc" + "\x0";
            // Output of the following line: * abc*
            Console.WriteLine("*" + s1 + "*");
            // Output of the following line: *abc *
            Console.WriteLine("*" + s2 + "*");
            // Output of the following line: 4
            Console.WriteLine(s2.Length);
        }

        public static void StringsAndLinq()
        {
            /*
             * We will learn more about LINQ in Chapter 4
             * LINQ can be used to query and transform strings and collections of strings. It can be especially useful with semi-structured data in text files. 
             * LINQ queries can be combined with traditional string functions and regular expressions. 
             * For example, you can use the Split or Split method to create an array of strings that you can then query or modify by using LINQ. 
             * You can use the IsMatch method in the where clause of a LINQ query. 
             * And you can use LINQ to query or modify the MatchCollection results returned by a regular expression.
            */

            //Word Count using LINQ
            string text = @"Historically, the world of data and the world of objects" +  
                @" have not been well integrated. Programmers work in C# or Visual Basic" +  
                @" and also in SQL or XQuery. On the one side are concepts such as classes," +  
                @" objects, fields, inheritance, and .NET Framework APIs. On the other side" +  
                @" are tables, columns, rows, nodes, and separate languages for dealing with" +  
                @" them. Data types often require translation between the two worlds; there are" +  
                @" different standard functions. Because the object world has no notion of query, a" +  
                @" query can only be represented as a string without compile-time type checking or" +  
                @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +  
                @" objects in memory is often tedious and error-prone.";  
            string searchTerm = "data";  

            //Convert the string into an array of words  
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);  

            // Create the query.  Use ToLowerInvariant to match "data" and "Data"   
            var matchQuery = from word in source  
                         where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()  
                         select word;  

            // Count the matches, which executes the query.  
            int wordCount = matchQuery.Count();  
            Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, searchTerm);

            /*
             * Because the String class implements the generic IEnumerable<T> interface, any string can be queried as a sequence of characters.
             * However, this is not a common use of LINQ.
             * The following example queries a string to determine the number of numeric digits it contains. 
             * Note that the query is "reused" after it is executed the first time. 
             * This is possible because the query itself does not store any actual results.
            */

            string aString = "ABCDE99F-J74-12-89A";

            // Select only those characters that are numbers  
            IEnumerable<char> stringQuery =
              from ch in aString
              where Char.IsDigit(ch)
              select ch;

            // Execute the query  
            foreach (char c in stringQuery)
                Console.Write(c + " ");

            // Call the Count method on the existing query.  
            int count = stringQuery.Count();
            Console.WriteLine("Count = {0}", count);

            // Select all characters before the first '-'  
            IEnumerable<char> stringQuery2 = aString.TakeWhile(c => c != '-');

            // Execute the second query  
            foreach (char c in stringQuery2)
                Console.Write(c);
        }
    }
}
