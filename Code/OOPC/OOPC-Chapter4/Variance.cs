using System;
using System.Collections.Generic;
namespace OOPCChapter4
{
    public class Variance
    {
        public void SimpleConceptsExample()
        {
            // Assignment compatibility.   
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.   
            object obj = str;

            // Covariance.   
            IEnumerable<string> strings = new List<string>();
            // An object that is instantiated with a more derived type argument   
            // is assigned to an object instantiated with a less derived type argument.   
            // Assignment compatibility is preserved.   
            IEnumerable<object> objects = strings;

            // Contravariance.             
            // Assume that the following method is in the class:   
            // static void SetObject(object o) { }   
            Action<object> actObject = SetObject;
            // An object that is instantiated with a less derived type argument   
            // is assigned to an object instantiated with a more derived type argument.   
            // Assignment compatibility is reversed.   
            Action<string> actString = actObject;

            //Covariance for arrays - not type safe
            object[] array = new String[10];
            // The following statement produces a run-time exception.  
            // array[0] = 10; 
        }

        //The following code example shows covariance and contravariance support for method groups.
        static object GetObject() { return null; }
        static void SetObject(object obj) { }

        static string GetString() { return ""; }
        static void SetString(string str) { }
        static void MethodGroupExample()
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;
        }

        static void VarianceInInterfacesExample()
        {
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

            // Implicit conversion of IEqualityComparer<BaseClass> to   
            // IEqualityComparer<DerivedClass>.  
            IEqualityComparer<DerivedClass> childComparer = baseComparer;

            //Variance in generic interfaces is supported for reference types only. Value types do not support variance. For example, IEnumerable<int> cannot be implicitly converted to IEnumerable<object>, because integers are represented by a value type.
            IEnumerable<int> integers = new List<int>();
            // The following statement generates a compiler errror,  
            // because int is a value type.  
            // IEnumerable<Object> objects = integers;

            //It is also important to remember that classes that implement variant interfaces are still invariant.For example, although List<T> implements the covariant interface IEnumerable<T>, you cannot implicitly convert List<Object> to List<String>.This is illustrated in the following code example.
            // The following line generates a compiler error  
            // because classes are invariant.  
            // List<Object> list = new List<String>();  

            // You can use the interface object instead.  
            IEnumerable<Object> listObjects = new List<String>();
        }
    }

    //Variance in Generic Interfaces

    // Simple hierarchy of classes.  
    class BaseClass { }
    class DerivedClass : BaseClass { }

    // Comparer class.  
    class BaseComparer : IEqualityComparer<BaseClass>
    {
        public int GetHashCode(BaseClass baseInstance)
        {
            return baseInstance.GetHashCode();
        }
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }
    }

    /*
     * Variance in Delegates follows the same rules that are applicable to Variance in Method i.e:
        * Input parameters are Contravariant: You can pass a more specific type as input parameters
        * return values are Covariant: You can return a more specific type as output of a method
    */

}