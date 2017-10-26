using System;

namespace OOPCChapter3
{
    /*
     * Creating Custom Attributes
     * Suppose you want to tag types with the name of the programmer who wrote the type. You might define a custom Author attribute class:
    */
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class Author : System.Attribute
    {
        public string Name { get; set; }
        public double Version { get; set; }

        public Author(string name)
        {
            this.Name = name;
            Version = 1.0;
        }
    }

    [Author("Pradeep Singh", Version = 1.0)]
    public class AlgorithmEasy
    {
        public void MyImplementation()
        {
            Console.WriteLine("This is so easy");
        }
    }

    [Author("Pradeep Singh", Version = 1.1)]
    public class AlgorithmSimple : AlgorithmEasy
    {
        public new void MyImplementation()
        {
            Console.WriteLine("This is so simple");
        }
    }

    /*
     * The following example demonstrates the effect of the Inherited and AllowMultiple arguments to the AttributeUsage attribute, and how the custom attributes applied to a class can be enumerated.
    */
    // Create some custom attributes:  
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    class A1 : System.Attribute { }

    [AttributeUsage(System.AttributeTargets.Class)]
    class A2 : System.Attribute { }

    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class A3 : System.Attribute { }

    // Apply custom attributes to classes:  
    [A1, A2]
    class BaseClass { }

    [A3, A3]
    class DerivedClass : BaseClass { }


}