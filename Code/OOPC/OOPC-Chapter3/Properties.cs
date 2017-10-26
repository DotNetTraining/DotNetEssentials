using System;
using System.Linq;

namespace OOPCChapter3
{
    /*
     * Properties with backing fields
     * One basic pattern for implementing a property involves using a private backing field for setting and retrieving the property value.
     * The get accessor returns the value of the private field, and the set accessor may perform some data validation before assigning a value to the private field. Both accessors may also perform some conversion or computation on the data before it is stored or returned.
    */

    class TimePeriod
    {
        private double seconds;

        public double Hours
        {
            get { return seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} must be between 0 and 24.");

                seconds = value * 3600;
            }
        }
    }

    /*
     * Expression body definitions C# 6.0
     * Property accessors often consist of single-line statements that just assign or return the result of an expression.
     * You can implement these properties as expression-bodied members. 
     * Expression body definitions consist of the => symbol followed by the expression to assign to or retrieve from the property.
     * Starting with C# 6, read-only properties can implement the get accessor as an expression-bodied member. 
     * In this case, neither the get accessor keyword nor the return keyword is used.
     * The following example implements the read-only Name property as an expression-bodied member.
    */

    public class Person
    {
        private string firstName;
        private string lastName;

        public Person(string first, string last)
        {
            firstName = first;
            lastName = last;
        }

        public string Name => $"{firstName} {lastName}";
    }

    /*
     * Expression body definitions 7.0
     * Starting with C# 7, both the get and the set accessor can be implemented as expression-bodied members. 
     * In this case, the get and set keywords must be present. 
     * The following example illustrates the use of expression body definitions for both accessors. 
     * Note that the return keyword is not used with the get accessor.
    */

    public class SaleItem
    {
        string name;
        decimal cost;

        public SaleItem(string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal Price
        {
            get => cost;
            set => cost = value;
        }
    }

    /*
     * Auto-implemented properties
     * In some cases, property get and set accessors just assign a value to or retrieve a value from a backing field without including any additional logic. 
     * By using auto-implemented properties, you can simplify your code while having the C# compiler transparently provide the backing field for you.
     * If a property has both a get and a set accessor, both must be auto-implemented. 
     * You define an auto-implemented property by using the get and set keywords without providing any implementation. 
     * The following example repeats the previous one, except that Name and Price are auto-implemented properties. 
     * Note that the example also removes the parameterized constructor, so that SaleItem objects are now initialized with a call to the default constructor and an object initializer.
    */
    public class SaleItemV2
    {
        public string Name
        { get; set; }

        public decimal Price
        { get; set; }
    }

    /*
     * Properties in Interfaces
     * Properties can be declared on an interface.
    */
    interface IEmployee
    {
        string Name
        {
            get;
            set;
        }

        int Counter
        {
            get;
        }
    }

    public class Employee : IEmployee
    {
        public static int numberOfEmployees;

        private string name;
        public string Name  // read-write instance property
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int counter;
        public int Counter  // read-only instance property
        {
            get
            {
                return counter;
            }
        }

        public Employee()  // constructor
        {
            counter = ++counter + numberOfEmployees;
        }
    }

    /*
     * Access Modifiers on Property Getters and Setters
     * The get and set portions of a property or indexer are called accessors.
     * By default these accessors have the same visibility, or access level: that of the property or indexer to which they belong.
     * Typically, this involves restricting the accessibility of the set accessor, while keeping the get accessor publicly accessible.
     * Using the accessor modifiers on properties or indexers is subject to these conditions:
        * You cannot use accessor modifiers on an interface or an explicit interface member implementation.
        * You can use accessor modifiers only if the property or indexer has both set and get accessors. In this case, the modifier is permitted on one only of the two accessors.
        * If the property or indexer has an override modifier, the accessor modifier must match the accessor of the overridden accessor, if any.
        * The accessibility level on the accessor must be more restrictive than the accessibility level on the property or indexer itself.
     * When you override a property or indexer, the overridden accessors must be accessible to the overriding code. 
     * Also, the accessibility level of both the property/indexer, and that of the accessors must match the corresponding overridden property/indexer and the accessors.
     * For example: The below classes have different access modifiers for getter and setter.
    */

    public class Parent
    {
        public virtual int TestProperty
        {
            // Notice the accessor accessibility level.
            protected set { }

            // No access modifier is used here.
            get { return 0; }
        }
    }
    public class Kid : Parent
    {
        public override int TestProperty
        {
            // Use the same accessibility level as in the overridden accessor.
            protected set { }

            // Cannot use access modifier here.
            get { return 0; }
        }
    }

    /*
     * Implementing Interfaces with Different Access Modifiers
     * When you use an accessor to implement an interface, the accessor may not have an access modifier. 
     * However, if you implement the interface using one accessor, such as get, the other accessor can have an access modifier, as in the following example:
    */

    public interface ISomeInterface
    {
        int TestProperty
        {
            // No access modifier allowed here
            // because this is an interface.
            get;
        }
    }

    public class TestClass : ISomeInterface
    {
        public int TestProperty
        {
            // Cannot use access modifier here because
            // this is an interface implementation.
            get { return 10; }

            // Interface property does not have set accessor,
            // so access modifier is allowed.
            protected set { }
        }
    }

    /*
     * Implement a Lightweight Class with Auto-Implemented Properties
     * This example shows how to create an immutable lightweight class that serves only to encapsulate a set of auto-implemented properties.
     * Use this kind of construct instead of a struct when you must use reference type semantics.
     * You can make an immutable property in two ways. You can declare the set accessor.to be private.
     * The property is only settable within the type, but it is immutable to consumers. You can instead declare only the get accessor, which makes the property immutable everywhere except in the type’s constructor.
     * When you declare a private set accessor, you cannot use an object initializer to initialize the property. You must use a constructor or a factory method.
    */
    // This class is immutable. After an object is created,   
    // it cannot be modified from outside the class. It uses a   
    // constructor to initialize its properties.   
    class Contact
    {
        // Read-only properties.   
        public string Name { get; }
        public string Address { get; private set; }

        // Public constructor.   
        public Contact(string contactName, string contactAddress)
        {
            Name = contactName;
            Address = contactAddress;
        }
    }

    // This class is immutable. After an object is created,   
    // it cannot be modified from outside the class. It uses a   
    // static method and private constructor to initialize its properties.      
    public class Contact2
    {
        // Read-only properties.   
        public string Name { get; private set; }
        public string Address { get; }

        // Private constructor.   
        private Contact2(string contactName, string contactAddress)
        {
            Name = contactName;
            Address = contactAddress;
        }

        // Public factory method.   
        public static Contact2 CreateContact(string name, string address)
        {
            return new Contact2(name, address);
        }
    }
}