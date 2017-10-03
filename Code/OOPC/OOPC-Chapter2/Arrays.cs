using System;
using System.Linq;
using System.Collections.Generic;

namespace OOPCChapter2
{
    public static class Arrays
    {
        /*
         * You can store multiple variables of the same type in an array data structure. You declare an array by specifying the type of its elements.
            type[] arrayName;
         * The following examples create single-dimensional, multidimensional, and jagged arrays:
        */

        public static void SimpleArray()
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            //Arrays in C# implement the IQueryable Interface so they can be queried using LINQ.
            var greaterThan80Scrores = scores.Where(x => x > 80);
            //The same can be expressed using query syntax as:
            /*
                IEnumerable<int> greaterThan80Scrores =
                from score in scores
                where score > 80
                select score;
             */
            // Execute the query.
            /*
             * Variables created using LINQ queries are always evaluated when you try to access the results for the first time.
             * So even though we created a variable greaterThan80Scrores of type IEnumerable<int>, the variable will hold a reference only when we try to access the data from the variable.
            */
            foreach (int i in greaterThan80Scrores)
            {
                Console.Write(i + " ");
            }

            // Output: 97 92 81
        }

        public static void ArraysAsObjects()
        {
            /*
             * In C#, arrays are actually objects, and not just addressable regions of contiguous memory as in C and C++.
             * Array is the abstract base type of all array types. You can use the properties, and other class members, that Array has.
             * An example of this would be using the Length property to get the length of an array. 
             * The following code assigns the length of the numbers array, which is 5, to a variable called lengthOfNumbers:
            */

            int[] numbers = { 1, 2, 3, 4, 5 };
            int lengthOfNumbers = numbers.Length;

            //This example uses the Rank property to display the number of dimensions of an array.
            // Declare and initialize an array:
            int[,] theArray = new int[5, 10];
            System.Console.WriteLine("The array has {0} dimensions.", theArray.Rank);

            // Output: The array has 2 dimensions.
        }

        public static void SingleDimensionalArray()
        {
            //This array contains the elements from array[0] to array[4]. 
            //The new operator is used to create the array and initialize the array elements to their default values. 
            //In this example, all the array elements are initialized to zero.
            //You can declare a single - dimensional array of five integers as shown in the following example:
            int[] array = new int[5];
            //An array that stores string elements can be declared in the same way.For example:
            string[] stringArray = new string[6];

            //Array Initialization
            //It is possible to initialize an array upon declaration, in which case, the rank specifier is not needed because it is already supplied by the number of elements in the initialization list.
            //For example:
            int[] array1 = new int[] { 1, 3, 5, 7, 9 };
            //A string array can be initialized in the same way.
            //The following is a declaration of a string array where each array element is initialized by a name of a day:
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        }

        public static void MultiDimensionalArray()
        {
            //Arrays can have more than one dimension. For example, the following declaration creates a two-dimensional array of four rows and two columns.
            int[,] array = new int[4, 2];
            //The following declaration creates an array of three dimensions, 4, 2, and 3.
            int[,,] array1 = new int[4, 2, 3];

            // Two-dimensional array.
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // The same array with dimensions specified.
            int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // A similar array with string elements.
            string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            // Three-dimensional array.
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
            // The same array with dimensions specified.
            int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

            // Accessing array elements.
            System.Console.WriteLine(array2D[0, 0]);
            System.Console.WriteLine(array2D[0, 1]);
            System.Console.WriteLine(array2D[1, 0]);
            System.Console.WriteLine(array2D[1, 1]);
            System.Console.WriteLine(array2D[3, 0]);
            System.Console.WriteLine(array2Db[1, 0]);
            System.Console.WriteLine(array3Da[1, 0, 1]);
            System.Console.WriteLine(array3D[1, 1, 2]);

            // Getting the total count of elements or the length of a given dimension.
            var allLength = array3D.Length;
            var total = 1;
            for (int i = 0; i < array3D.Rank; i++)
            {
                total *= array3D.GetLength(i);
            }
            System.Console.WriteLine("{0} equals {1}", allLength, total);

            // Output:
            // 1
            // 2
            // 3
            // 4
            // 7
            // three
            // 8
            // 12
            // 12 equals 12

            //You also can initialize the array without specifying the rank.
            int[,] array4 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            //If you choose to declare an array variable without initialization, you must use the new operator to assign an array to the variable.
            //The use of new is shown in the following example.
            int[,] array5;
            array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };   // OK
            //array5 = {{1,2}, {3,4}, {5,6}, {7,8}};   // Error

            //The following example assigns a value to a particular array element.
            array5[2, 1] = 25;

            //Similarly, the following example gets the value of a particular array element and assigns it to variable elementValue.
            int elementValue = array5[2, 1];

            //The following code example initializes the array elements to default values (except for jagged arrays).
            int[,] array6 = new int[10, 10];
        }

        public static void JaggedArray()
        {
            /*
             * A jagged array is an array whose elements are arrays.
             * The elements of a jagged array can be of different dimensions and sizes. 
             * A jagged array is sometimes called an "array of arrays." The following examples show how to declare, initialize, and access jagged arrays.
             * The following is a declaration of a single-dimensional array that has three elements, each of which is a single-dimensional array of integers:
            */

            int[][] jaggedArray = new int[3][];

            //Before you can use jaggedArray, its elements must be initialized. You can initialize the elements like this:
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[4];
            jaggedArray[2] = new int[2];


            //Each of the elements is a single-dimensional array of integers. The first element is an array of 5 integers, the second is an array of 4 integers, and the third is an array of 2 integers.
            //It is also possible to use initializers to fill the array elements with values, in which case you do not need the array size.
            //For example:
            jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            jaggedArray[1] = new int[] { 0, 2, 4, 6 };
            jaggedArray[2] = new int[] { 11, 22 };

            //You can also initialize the array upon declaration like this:
            int[][] jaggedArray2 = new int[][]
            {
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6},
                new int[] {11,22}
            };

            //You can use the following shorthand form.
            //Notice that you cannot omit the new operator from the elements initialization because there is no default initialization for the elements:
            int[][] jaggedArray3 = {
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6},
                new int[] {11,22}
            };

            //A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to null.
            //You can access individual array elements like these examples:
            // Assign 77 to the second element ([1]) of the first array ([0]):
            jaggedArray3[0][1] = 77;

            // Assign 88 to the second element ([1]) of the third array ([2]):
            jaggedArray3[2][1] = 88;

            //It is possible to mix jagged and multidimensional arrays.
            //The following is a declaration and initialization of a single-dimensional jagged array that contains three two-dimensional array elements of different sizes.
            int[][,] jaggedArray4 = new int[3][,]{
                new int[,] { {1,3}, {5,7} },
                new int[,] { {0,2}, {4,6}, {8,10} },
                new int[,] { {11,22}, {99,88}, {0,9} }
            };

            //You can access individual elements as shown in this example, which displays the value of the element [1,0] of the first array (value 5):
            System.Console.Write("{0}", jaggedArray4[0][1, 0]);

            //The method Length returns the number of arrays contained in the jagged array.
            System.Console.WriteLine(jaggedArray4.Length);

            //This example builds an array whose elements are themselves arrays. Each one of the array elements has a different size.

            // Declare the array of two elements:
            int[][] arr = new int[2][];

            // Initialize the elements:
            arr[0] = new int[5] { 1, 3, 5, 7, 9 };
            arr[1] = new int[4] { 2, 4, 6, 8 };

            // Display the array elements:
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }

            /* Output:
                Element(0): 1 3 5 7 9
                Element(1): 2 4 6 8
            */
        }

        /*
         * ********************************************** *
         * Passing Single-Dimensional Arrays As Arguments *
         * ********************************************** *
         * Arrays can be passed as arguments to method parameters. Because arrays are reference types, the method can change the value of the elements.
         * In the following example, an array of strings is initialized and passed as an argument to a PrintArray method for strings. 
         * The method displays the elements of the array. Next, methods ChangeArray and ChangeArrayElement are called to demonstrate that sending an array argument by value does not prevent changes to the array elements.
        */

        static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");
            }
            System.Console.WriteLine();
        }

        static void ChangeArray(string[] arr)
        {
            // The following attempt to reverse the array does not persist when
            // the method returns, because arr is a value parameter.
            arr = (arr.Reverse()).ToArray();
            // The following statement displays Sat as the first element in the array.
            System.Console.WriteLine("arr[0] is {0} in ChangeArray.", arr[0]);
        }

        static void ChangeArrayElements(string[] arr)
        {
            // The following assignments change the value of individual array 
            // elements. 
            arr[0] = "Sat";
            arr[1] = "Fri";
            arr[2] = "Thu";
            // The following statement again displays Sat as the first element
            // in the array arr, inside the called method.
            System.Console.WriteLine("arr[0] is {0} in ChangeArrayElements.", arr[0]);
        }

        public static void PassingSingleDimensionArrays()
        {
            // Declare and initialize an array.
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            // Pass the array as an argument to PrintArray.
            PrintArray(weekDays);

            // ChangeArray tries to change the array by assigning something new
            // to the array in the method. 
            ChangeArray(weekDays);

            // Print the array again, to verify that it has not been changed.
            System.Console.WriteLine("Array weekDays after the call to ChangeArray:");
            PrintArray(weekDays);
            System.Console.WriteLine();

            // ChangeArrayElements assigns new values to individual array
            // elements.
            ChangeArrayElements(weekDays);

            // The changes to individual elements persist after the method returns.
            // Print the array, to verify that it has been changed.
            System.Console.WriteLine("Array weekDays after the call to ChangeArrayElements:");
            PrintArray(weekDays);

            // Output: 
            // Sun Mon Tue Wed Thu Fri Sat
            // arr[0] is Sat in ChangeArray.
            // Array weekDays after the call to ChangeArray:
            // Sun Mon Tue Wed Thu Fri Sat
            // 
            // arr[0] is Sat in ChangeArrayElements.
            // Array weekDays after the call to ChangeArrayElements:
            // Sat Fri Thu Wed Thu Fri Sat
        }

        /*
         * ******************************************** *
         * Passing Multidimensional Arrays As Arguments *
         * ******************************************** *
         * You pass an initialized multidimensional array to a method in the same way that you pass a one-dimensional array.
         * In the following example, a two-dimensional array of integers is initialized and passed to the Print2DArray method. 
         * The method displays the elements of the array.
        */
        static void Print2DArray(int[,] arr)
        {
            // Display the array elements.
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.WriteLine("Element({0},{1})={2}", i, j, arr[i, j]);
                }
            }
        }
        public static void Passing2DArray()
        {
            // Pass the array as an argument.
            Print2DArray(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } });

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        /*
         * Passing Arrays Using ref and out keywords
         * You can use the out contextual keyword in two contexts:
         *  * As a parameter modifier, which lets you pass an argument to a method by reference rather than by value.
         *  * In generic type parameter declarations for interfaces and delegates, which specifies that a type parameter is covariant.
         * The ref keyword indicates a value that is passed by reference. It is used in three different contexts:
         *  * In a method signature and in a method call, to pass an argument to a method by reference. See Passing an argument by reference for more information.
         *  * In a method signature, to return a value to the caller by reference. See Reference return values for more information.
         *  * In a member body, to indicate that a reference return value is stored locally as a reference that the caller intends to modify.
         * Like all out parameters, an out parameter of an array type must be assigned before it is used; that is, it must be assigned by the callee.
         * Like all ref parameters, a ref parameter of an array type must be definitely assigned by the caller.
         * Therefore, there is no need to be definitely assigned by the callee. A ref parameter of an array type may be altered as a result of the call.
         * For example, the array can be assigned the null value or can be initialized to a different array.
        */

        /*
         * In this example, the array theArray is declared in the caller (the Main method), and initialized in the FillArray method.
         * Then, the array elements are returned to the caller and displayed.
        */
        static void FillArray(out int[] arr)
        {
            // Initialize the array:
            arr = new int[5] { 1, 2, 3, 4, 5 };
        }

        public static void ArrayOutExample()
        {
            int[] theArray; // Initialization is not required

            // Pass the array to the callee using out:
            FillArray(out theArray);

            // Display the array elements:
            System.Console.WriteLine("Array elements are:");
            for (int i = 0; i < theArray.Length; i++)
            {
                System.Console.Write(theArray[i] + " ");
            }

            /* Output:
                Array elements are:
                1 2 3 4 5        
            */
        }

        /*
         * In this example, the array theArray is initialized in the caller (the Main method), and passed to the FillArrayRef method by using the ref parameter. 
         * Some of the array elements are updated in the FillArrayRef method. Then, the array elements are returned to the caller and displayed.
        */

        static void FillArrayRef(ref int[] arr)
        {
            // Create the array on demand:
            if (arr == null)
            {
                arr = new int[10];
            }
            // Fill the array:
            arr[0] = 1111;
            arr[4] = 5555;
        }

        public static void ArrayRefExample()
        {
            // Initialize the array:
            int[] theArray = { 1, 2, 3, 4, 5 };

            // Pass the array using ref:
            FillArrayRef(ref theArray);

            // Display the updated array:
            System.Console.WriteLine("Array elements are:");
            for (int i = 0; i < theArray.Length; i++)
            {
                System.Console.Write(theArray[i] + " ");
            }

            /* Output:
                Array elements are:
                1111 2 3 4 5555
            */
        }

        /*
         * Implicitly Typed Arrays
         * You can create an implicitly-typed array in which the type of the array instance is inferred from the elements specified in the array initializer.
         * The rules for any implicitly-typed variable also apply to implicitly-typed arrays.
         * Implicitly-typed arrays are usually used in query expressions together with anonymous types and object and collection initializers.
         * The following examples show how to create an implicitly-typed array:
        */

        public static void ImplicitelyTypedArrays()
        {
            var a = new[] { 1, 10, 100, 1000 }; // int[]
            var b = new[] { "hello", null, "world" }; // string[]

            // single-dimension jagged array
            var c = new[]
            {
                new[]{1,2,3,4},
                new[]{5,6,7,8}
            };

            // jagged array of strings
            var d = new[]
            {
                new[]{"Luca", "Mads", "Luke", "Dinesh"},
                new[]{"Karen", "Suma", "Frances"}
            };
        }

        /*
         * Implicitly-typed Arrays in Object Initializers
         * When you create an anonymous type that contains an array, the array must be implicitly typed in the type's object initializer.
         * In the following example, contacts is an implicitly-typed array of anonymous types, each of which contains an array named PhoneNumbers.
         * Note that the var keyword is not used inside the object initializers.
        */
        public static void ImplicitlyTypedArraysInObjectInitializers()
        {
            var contacts = new[]
            {
                new {
                        Name = " Eugene Zabokritski",
                        PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                },
                new {
                        Name = " Hanying Feng",
                        PhoneNumbers = new[] { "650-555-0199" }
                }
            };
            foreach (var item in contacts)
            {
                Console.WriteLine("Name: {0}\tPhone Numbers: {1}", item.Name, String.Join(", ", item.PhoneNumbers));
            }
        }
    }
}
