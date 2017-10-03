using System;

/*
 * An interface contains definitions for a group of related functionalities that a class or a struct can implement.
 * By using interfaces, you can, for example, include behavior from multiple sources in a class.
 * That capability is important in C# because the language doesn't support multiple inheritance of classes.
 * In addition, you must use an interface if you want to simulate inheritance for structs, because they can't actually inherit from another struct or class.
 * The interface defines only the signature. 
 * In that way, an interface in C# is similar to an abstract class in which all the methods are abstract. 
 * However, a class or struct can implement multiple interfaces, but a class can inherit only a single class, abstract or not. 
 * Therefore, by using interfaces, you can include behavior from multiple sources in a class.
 * Interfaces can contain methods, properties, events, indexers, or any combination of those four member types.
 * An interface can't contain constants, fields, operators, instance constructors, finalizers, or types.
 * Interface members are automatically public, and they can't include any access modifiers. 
 * Members also can't be static.
 * To implement an interface member, the corresponding member of the implementing class must be public, non-static, and have the same name and signature as the interface member.
 * When a class or struct implements an interface, the class or struct must provide an implementation for all of the members that the interface defines. 
 * The interface itself provides no functionality that a class or struct can inherit in the way that it can inherit base class functionality. 
 * However, if a base class implements an interface, any class that's derived from the base class inherits that implementation.
*/


namespace OOPCChapter2
{
    #region Basic Example
    //Basic Example: Implementing an interface simply requires implementing all of its properties and methods, in whatever way is best for your class
    interface IStorable
    {
        void Read();
        void Write(object obj);
        int Status { get; set; }
    }

    public class Document : IStorable
    {

        public Document(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }

        #region IStorable

        public void Read()
        {
            Console.WriteLine("Executing Document's Read Method for IStorable");
        }

        public void Write(object o)
        {
            Console.WriteLine("Executing Document's Write Method for IStorable");
        }

        // property required by IStorable
        public int Status { get; set; }

        #endregion

    }

    public class InterfaceTester
    {
        public void Run()
        {
            Document doc = new Document("Test Document");
            doc.Status = -1;
            doc.Read();
            Console.WriteLine("Document Status: {0}", doc.Status);
        }

        static void TestInterfaceImplementation()
        {
            InterfaceTester t = new InterfaceTester();
            t.Run();
        }
    }
    #endregion

    #region Implementing More Than One Interface
    //Implementing multiple interfaces isn't much more difficult than implementing a single one; you just have to implement the required methods for both interfaces
    // here's the new interface
    interface ICompressible
    {
        void Compress();
        void Decompress();
    }

    public class CompressibleDocument : IStorable, ICompressible
    {
        public CompressibleDocument(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }

        #region IStorable

        public void Read()
        {
            Console.WriteLine("Executing Document's Read Method for IStorable");
        }

        public void Write(object o)
        {
            Console.WriteLine("Executing Document's Write Method for IStorable");
        }

        public int Status { get; set; }

        #endregion     // IStorable

        #region ICompressible

        public void Compress()
        {
            Console.WriteLine("Executing Document's Compress Method for ICompressible");
        }
        public void Decompress()
        {
            Console.WriteLine("Executing Document's Decompress Method for ICompressible");
        }
        #endregion  // ICompressible

    }

    class BothInterfacesTester
    {
        public void Run()
        {
            CompressibleDocument doc = new CompressibleDocument("Test Document");
            doc.Status = -1;
            doc.Read();          // invoke method from IStorable
            doc.Compress();      // invoke method from ICompressible
            Console.WriteLine("Document Status: {0}", doc.Status);
        }

        static void TestInterfaceImplementations()
        {
            BothInterfacesTester t = new BothInterfacesTester();
            t.Run();
        }
    }
    #endregion

    #region Extending Interfaces

    /*
     * You can extend an existing interface to add new methods or members.
     * For example, you might extend ICompressible with a new interface, ILoggedCompressible, which extends the original interface with methods to keep track of the bytes saved. 
     * One such method might be called LogSavedBytes( ).
     * The following code creates a new interface named ILoggedCompressible that is identical to ICompressible except that it adds the method LogSavedBytes:
    */

    // extend ICompressible to log the bytes saved
    interface ILoggedCompressible : ICompressible
    {
        void LogSavedBytes();
    }

    public class SuperiorDocument : ILoggedCompressible, IStorable
    {

        public SuperiorDocument(string s)
        {

            Console.WriteLine("Creating document with: {0}", s);
        }

        #region

        public void Compress()
        {
            Console.WriteLine("Executing Compress");
        }

        public void Decompress()
        {
            Console.WriteLine("Executing Decompress");
        }

        public void LogSavedBytes()
        {
            Console.WriteLine("Executing LogSavedBytes");
        }

        #endregion //ILoggedCompressible

        #region IStorable

        public void Read()
        {
            Console.WriteLine("Executing Document's Read Method for IStorable");
        }

        public void Write(object o)
        {
            Console.WriteLine("Executing Document's Write Method for IStorable");
        }

        public int Status { get; set; }

        #endregion     // IStorable
    }

    public class SuperiorDocumentTester
    {
        public void Run()
        {
            SuperiorDocument doc = new SuperiorDocument("Test Document");

            ILoggedCompressible myLoggedCompressible =
                                doc as ILoggedCompressible;
            if (myLoggedCompressible != null)
            {
                Console.Write("\nCalling both ICompressible and ");
                Console.WriteLine("ILoggedCompressible methods...");
                myLoggedCompressible.Compress();
                myLoggedCompressible.LogSavedBytes();
            }
            else
            {
                Console.WriteLine("Something went wrong! Not ILoggedCompressible");
            }

            IStorable myStorable = doc as IStorable;
            if (myStorable != null)
            {
                Console.WriteLine("Calling IStorable methods...");
                myStorable.Status = -1;
                myStorable.Read();
                Console.WriteLine("Document Status: {0}", myStorable.Status);
            }
            else
            {
                Console.WriteLine("Something went wrong! Not IStorable");
            }
        }

        static void TestInterfaceImplementations()
        {
            SuperiorDocumentTester t = new SuperiorDocumentTester();
            t.Run();
        }

        #endregion
    }

    #region Combining Interfaces
    /*
     * You can also create new interfaces by combining existing interfaces and optionally adding new methods or properties.
     * For example, you might decide to combine the definitions of IStorable and ICompressible into a new interface called IStorableCompressible.
     * This interface would combine the methods of each of the other two interfaces, but would also add a new method, LogOriginalSize( ), to store the original size of the precompressed item:
    */
    interface IStorableCompressible : IStorable, ILoggedCompressible
    {
        void LogOriginalSize();
    }

    public class UltimateDocument : IStorableCompressible
    {

        public UltimateDocument(string s)
        {

            Console.WriteLine("Creating document with: {0}", s);
        }

        #region IStorableCompressible

        public void LogOriginalSize()
        {
            Console.WriteLine("Executing LogOriginalSize");
        }
        #endregion

        #region ILoggedCompressible

        public void Compress()
        {
            Console.WriteLine("Executing Compress");
        }

        public void Decompress()
        {
            Console.WriteLine("Executing Decompress");
        }

        public void LogSavedBytes()
        {
            Console.WriteLine("Executing LogSavedBytes");
        }

        #endregion //ILoggedCompressible

        #region IStorable

        public void Read()
        {
            Console.WriteLine("Executing Document's Read Method for IStorable");
        }

        public void Write(object o)
        {
            Console.WriteLine("Executing Document's Write Method for IStorable");
        }

        public int Status { get; set; }

        #endregion     // IStorable
    }

    public class UltimateDocumentTester
    {
        public void Run()
        {
            UltimateDocument doc = new UltimateDocument("Test Document");

            IStorableCompressible myStorableCompressible =
                doc as IStorableCompressible;
            if (myStorableCompressible != null)
            {
                Console.Write("\nCalling both ICompressible and ");
                Console.WriteLine("ILoggedCompressible methods...");
                myStorableCompressible.Compress();
                myStorableCompressible.LogSavedBytes();
                Console.WriteLine("Calling IStorable methods...");
                myStorableCompressible.Status = -1;
                myStorableCompressible.Read();
                Console.WriteLine("Document Status: {0}", myStorableCompressible.Status);
                Console.WriteLine("Calling IStorableCompressible methods...");
                myStorableCompressible.LogOriginalSize();
            }
            else
            {
                Console.WriteLine("Something went wrong! Not ILoggedCompressible");
            }
        }

        static void TestInterfaceImplementations()
        {
            SuperiorDocumentTester t = new SuperiorDocumentTester();
            t.Run();
        }
    }
    #endregion
}
