using System;


namespace OOPCChapter4
{
#if WINDOWS
    using System.Runtime.InteropServices;
#endif
    public class Unsafe
    {
        //dont forget to enable /unsafe flag in the build options
        public unsafe static void UnsafePointersExample()
        {
            // Normal pointer to an object.  
            int[] a = new int[5] { 10, 20, 30, 40, 50 };
            // Must be in unsafe code to use interior pointers.  
            unsafe
            {
                // Must pin object on heap so that it doesn't move while using interior pointers.  
                fixed (int* p = &a[0])
                {
                    // p is pinned as well as object, so create another pointer to show incrementing it.  
                    int* p2 = p;
                    Console.WriteLine(*p2);
                    // Incrementing p2 bumps the pointer by four bytes due to its type ...  
                    p2 += 1;
                    Console.WriteLine(*p2);
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");
                    Console.WriteLine(*p);
                    // Deferencing p and incrementing changes the value of a[0] ...  
                    *p += 1;
                    Console.WriteLine(*p);
                    *p += 1;
                    Console.WriteLine(*p);
                }
            }

            Console.WriteLine("--------");
            Console.WriteLine(a[0]);
            Console.ReadLine();
        }

#if WINDOWS
        public class LibWrap
        {
            // Declares managed prototypes for unmanaged functions.
            [DllImport("User32.dll", EntryPoint = "MessageBox",
            CharSet = CharSet.Auto)]
            public static extern int MsgBox(int hWnd, string text, string caption,
          uint type);

            // Causes incorrect output in the message window.
            [DllImport("User32.dll", EntryPoint = "MessageBoxW",
                CharSet = CharSet.Ansi)]
            public static extern int MsgBox2(int hWnd, string text,
               string caption, uint type);

            // Causes an exception to be thrown. EntryPoint, CharSet, and
            // ExactSpelling fields are mismatched.
            [DllImport("User32.dll", EntryPoint = "MessageBox",
                CharSet = CharSet.Ansi, ExactSpelling = true)]
            public static extern int MsgBox3(int hWnd, string text,
                string caption, uint type);
        }

        public static void InterOpExample()
        {
            LibWrap.MsgBox(0, "Correct text", "MsgBox Sample", 0);
            LibWrap.MsgBox2(0, "Incorrect text", "MsgBox Sample", 0);

            try
            {
                LibWrap.MsgBox3(0, "No such function", "MsgBox Sample", 0);
            }
            catch(EntryPointNotFoundException)
            {
                Console.WriteLine("EntryPointNotFoundException thrown as expected!");
            }
        }
#endif
    }
}