//Fully Qualified Names
/*
 * Namespaces and types have unique titles described by fully qualified names that indicate a logical hierarchy.
 * For example, the statement A.B implies that A is the name of the namespace or type, and B is nested inside it.
 * In the following example, there are nested classes and namespaces. The fully qualified name is indicated as a comment following each entity.
*/
namespace N1     // N1
{
    class C1      // N1.C1
    {
        class C2   // N1.C1.C2
        {
        }
    }
    namespace N2  // N1.N2
    {
        class C2   // N1.N2.C2
        {
        }
    }
}

//Using Namespaces to control scope
/*
 * The namespace keyword is used to declare a scope.
 * The ability to create scopes within your project helps organize code and lets you create globally-unique types.
 * In the following example, a class titled SampleClass is defined in two namespaces, one nested inside the other.
 * The . Operator is used to differentiate which method gets called.
*/

namespace SampleNamespace
{
    //Namespace Aliases
    using nested = NestedNamespace;


    class SampleClass
    {
        public void SampleMethod()
        {
            System.Console.WriteLine(
              "SampleMethod inside SampleNamespace");
        }
    }

    // Create a nested namespace, and define another class.
    namespace NestedNamespace
    {
        class SampleClass
        {
            public void SampleMethod()
            {
                System.Console.WriteLine(
                  "SampleMethod inside NestedNamespace");
            }
        }
    }


    class NameSpaceExample
    {
        

        static void RunExample()
        {
            // Displays "SampleMethod inside SampleNamespace."
            SampleClass outer = new SampleClass();
            outer.SampleMethod();

            // Displays "SampleMethod inside SampleNamespace."
            SampleNamespace.SampleClass outer2 = new SampleNamespace.SampleClass();
            outer2.SampleMethod();

            //or you can use the alias declacred above
            nested.SampleClass outer3 = new nested.SampleClass();

            // Displays "SampleMethod inside NestedNamespace."
            NestedNamespace.SampleClass inner = new NestedNamespace.SampleClass();
            inner.SampleMethod();
        }
    }
}

/*
 * In this example, the namespace System is used to include the class TestClass therefore, 
 * global::System.Console must be used to reference the System.Console class, which is hidden by the System namespace. 
 * Also, the alias colAlias is used to refer to the namespace System.Collections; 
 * therefore, the instance of a System.Collections.Hashtable was created using this alias instead of the namespace.
*/


namespace System
{
    using colAlias = System.Collections;
    class TestClass
    {
        static void ExampleGlobalNamespaces()
        {
            // Searching the alias:
            colAlias::Hashtable test = new colAlias::Hashtable();

            // Add items to the table.
            test.Add("A", "1");
            test.Add("B", "2");
            test.Add("C", "3");

            foreach (string name in test.Keys)
            {
                // Searching the global namespace:
                global::System.Console.WriteLine(name + " " + test[name]);
            }
        }
    }
}