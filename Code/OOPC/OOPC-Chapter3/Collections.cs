using System;
namespace OOPCChapter3
{

    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class Collections
    {
        //Arrays
        /*
         * An array has the following properties:
            * An array can be Single-Dimensional, Multidimensional or Jagged.
            * The number of dimensions and the length of each dimension are established when the array instance is created. These values can't be changed during the lifetime of the instance.
            * The default values of numeric array elements are set to zero, and reference elements are set to null.
            * A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to null.
            * Arrays are zero indexed: an array with n elements is indexed from 0 to n-1.
            * Array elements can be of any type, including an array type.
            * Array types are reference types derived from the abstract base type Array. Since this type implements IEnumerable and IEnumerable<T>, you can use foreach iteration on all arrays in C#.
        */
        //You can refer to Chapter 2 for more detailed examples of Arrays.
        public static void ArrayExample()
        {
            string[] names = { "James", "Megan", "Heather", "Julie" };
            //all LINQ methods are availble on Arrays
            var nameAndLengths = names.Select(name => (name, name.Length));
            foreach (var item in nameAndLengths)
            {
                Console.WriteLine($"Name: {item.name}");
            }
        }

        //Lists
        public static void ListExample()
        {
            var salmons = new List<string> { "chinook", "coho", "pink" };
            salmons.Add("sockeye");
            salmons.Remove("coho");
            var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Remove odd numbers.  
            for (var index = numbers.Count - 1; index >= 0; index--)
            {
                if (numbers[index] % 2 == 1)
                {
                    // Remove the element by specifying  
                    // the zero-based index in the list.  
                    numbers.RemoveAt(index);
                }
            }
            // Iterate through the list.  
            // A lambda expression is placed in the ForEach method  
            // of the List(T) object.  
            numbers.ForEach(
                number => Console.Write(number + " "));
            // Output: 0 2 4 6 8 
        }
        
        //Sorted List
        public static void SortedListExample()
        {
            // Create a new sorted list of strings, with string
            // keys.
            SortedList<string, string> openWith =
                new SortedList<string, string>();

            // Add some elements to the list. There are no 
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is 
            // already in the list.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you 
            // can omit its name when accessing elements. 
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // The indexer can be used to change the value associated
            // with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the list.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the list, TryGetValue can be a more efficient 
            // way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting 
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWith["ht"]);
            }

            // When you use foreach to enumerate list elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            IList<string> ilistValues = openWith.Values;

            // The elements of the list are strongly typed with the 
            // type that was specified for the SorteList values.
            Console.WriteLine();
            foreach (string s in ilistValues)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // The Values property is an efficient way to retrieve
            // values by index.
            Console.WriteLine("\nIndexed retrieval using the Values " +
                "property: Values[2] = {0}", openWith.Values[2]);

            // To get the keys alone, use the Keys property.
            IList<string> ilistKeys = openWith.Keys;

            // The elements of the list are strongly typed with the 
            // type that was specified for the SortedList keys.
            Console.WriteLine();
            foreach (string s in ilistKeys)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // The Keys property is an efficient way to retrieve
            // keys by index.
            Console.WriteLine("\nIndexed retrieval using the Keys " +
                "property: Keys[2] = {0}", openWith.Keys[2]);

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }

        //Dictionaries
        public static void DictionaryExample()
        {
            // Create a new dictionary of strings, with string keys.
            //
            Dictionary<string, string> openWith =
                new Dictionary<string, string>();

            // Add some elements to the dictionary. There are no 
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is 
            // already in the dictionary.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you 
            // can omit its name when accessing elements. 
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // The indexer can be used to change the value associated
            // with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the dictionary.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient 
            // way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting 
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWith["ht"]);
            }

            // When you use foreach to enumerate dictionary elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            // To get the values alone, use the Values property.
            Dictionary<string, string>.ValueCollection valueColl =
                openWith.Values;

            // The elements of the ValueCollection are strongly typed
            // with the type that was specified for dictionary values.
            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // To get the keys alone, use the Keys property.
            Dictionary<string, string>.KeyCollection keyColl =
                openWith.Keys;

            // The elements of the KeyCollection are strongly typed
            // with the type that was specified for dictionary keys.
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }

            /* This code example produces the following output:
             * An element with Key = "txt" already exists.
             * For key = "rtf", value = wordpad.exe.
             * For key = "rtf", value = winword.exe.
             * Key = "tif" is not found.
             * Key = "tif" is not found.
             * Value added for key = "ht": hypertrm.exe
             * Key = txt, Value = notepad.exe
             * Key = bmp, Value = paint.exe
             * Key = dib, Value = paint.exe
             * Key = rtf, Value = winword.exe
             * Key = doc, Value = winword.exe
             * Key = ht, Value = hypertrm.exe
             * Value = notepad.exe
             * Value = paint.exe
             * Value = paint.exe
             * Value = winword.exe
             * Value = winword.exe
             * Value = hypertrm.exe
             * Key = txt
             * Key = bmp
             * Key = dib
             * Key = rtf
             * Key = docKey = ht
             * Remove("doc")
             * Key "doc" is not found.
            */
        }

        //Queues
        public static void QueueExample()
        {
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            // A queue can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
            Console.WriteLine("Peek at next item to dequeue: {0}",
                numbers.Peek());
            Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

            // Create a copy of the queue, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in queueCopy)
            {
                Console.WriteLine(number);
            }

            // Create an array twice the size of the queue and copy the
            // elements of the queue, starting at the middle of the 
            // array. 
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second queue, using the constructor that accepts an
            // IEnumerable(Of T).
            Queue<string> queueCopy2 = new Queue<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in queueCopy2)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nqueueCopy.Contains(\"four\") = {0}",
                queueCopy.Contains("four"));

            Console.WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            Console.WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);
            /* This code example produces the following output:
             * one
             * two
             * three
             * four
             * five
             * Dequeuing 'one'
             * Peek at next item to dequeue: two
             * Dequeuing 'two'
             * Contents of the copy:
             * three
             * four
             * five
             * Contents of the second copy, with duplicates and nulls:
             * three
             * four
             * five
             * queueCopy.Contains("four") = True
             * queueCopy.Clear()
             * queueCopy.Count = 0
            */
        }
        //Stacks
        public static void StackExample()
        {
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            // A stack can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            Console.WriteLine("Peek at next item to destack: {0}",
                numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            // Create a copy of the stack, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in stack2)
            {
                Console.WriteLine(number);
            }

            // Create an array twice the size of the stack and copy the
            // elements of the stack, starting at the middle of the 
            // array. 
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second stack, using the constructor that accepts an
            // IEnumerable(Of T).
            Stack<string> stack3 = new Stack<string>(array2);

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in stack3)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nstack2.Contains(\"four\") = {0}",
                stack2.Contains("four"));

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);

            /* This code example produces the following output:
             * five
             * four
             * three
             * two
             * one
             * Popping 'five'
             * Peek at next item to destack: four
             * Popping 'four'
             * Contents of the first copy:
             * one
             * two
             * three
             * Contents of the second copy, with duplicates and nulls:
             * one
             * two
             * three
             * stack2.Contains("four") = False
             * stack2.Clear()
             * stack2.Count = 0

            */
        }
        //Iterators
        public static void IteratorsExample()
        {
            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            // Output: 6 8 10 12 14 16 18  
            Console.ReadKey();
        }

        public static System.Collections.Generic.IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.  
            for (int number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        //make a custom collection class
        public class DaysOfTheWeek : IEnumerable
        {
            private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            public IEnumerator GetEnumerator()
            {
                for (int index = 0; index < days.Length; index++)
                {
                    // Yield each day of the week.  
                    yield return days[index];
                }
            }
        }

    }


}