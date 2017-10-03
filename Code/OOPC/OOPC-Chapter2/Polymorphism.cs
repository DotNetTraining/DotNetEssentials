using System;

namespace OOPCChapter2
{
    /*
     * Basic Polymorphism
     * First, create a base class called Shape, and derived classes such as Rectangle, Circle, and Triangle.
     * Give the Shape class a virtual method called Draw, and override it in each derived class to draw the particular shape that the class represents. 
     * Create a List<Shape> object and add a Circle, Triangle and Rectangle to it. (We will learn n great depth about Generic Collections in Chapters 3 and 4)
     * To update the drawing surface, use a foreach loop to iterate through the list and call the Draw method on each Shape object in the list. 
     * Even though each object in the list has a declared type of Shape, it is the run-time type (the overridden version of the method in each derived class) that will be invoked.
    */

    public class Shape1
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    class Circle1 : Shape1
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    class Rectangle : Shape1
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }
    class Triangle : Shape1
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }

    public class PolymorphismBasic
    {
        static void TestPolymorphicObjects(string[] args)
        {
            // Polymorphism at work #1: a Rectangle, Triangle and Circle
            // can all be used whereever a Shape is expected. No cast is
            // required because an implicit conversion exists from a derived 
            // class to its base class.
            System.Collections.Generic.List<Shape1> shapes = new System.Collections.Generic.List<Shape1>();
            shapes.Add(new Rectangle());
            shapes.Add(new Triangle());
            shapes.Add(new Circle1());

            // Polymorphism at work #2: the virtual method Draw is
            // invoked on each of the derived classes, not the base class.
            foreach (Shape1 s in shapes)
            {
                s.Draw();
            }
            /* Output:
                Drawing a rectangle
                Performing base class drawing tasks
                Drawing a triangle
                Performing base class drawing tasks
                Drawing a circle
                Performing base class drawing tasks
            */
        }

    }

    /*
     * Hiding Base Class Members with New Members
     * If you want your derived member to have the same name as a member in a base class, but you do not want it to participate in virtual invocation, you can use the new keyword. 
     * The new keyword is put before the return type of a class member that is being replaced. 
     * The following code provides an example:
    */

    public class WorkerBase
    {
        public void DoWork() { WorkField++; }
        public int WorkField;
        public int WorkProperty
        {
            get { return 0; }
        }
    }

    public class HardWorkingWorker : WorkerBase
    {
        public new void DoWork() { WorkField += 2; }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }

    public class WorkerDemo
    {
        public static void Work()
        {
            HardWorkingWorker B = new HardWorkingWorker();
            B.DoWork();  // Calls the new method.
            //This will also call the new method due to late binding
            WorkerBase worker = new HardWorkingWorker();
            worker.DoWork();

            //Hidden base class members can still be accessed from client code by casting the instance of the derived class to an instance of the base class.
            //For example:
            WorkerBase baseWorker = (WorkerBase)B;
            baseWorker.DoWork();    // Calls the old method.
        }
    }

    /*
     * Preventing Derived Classes from Overriding Virtual Members
     * Virtual members remain virtual indefinitely, regardless of how many classes have been declared between the virtual member and the class that originally declared it. 
     * If class A declares a virtual member, and class B derives from A, and class C derives from B, class C inherits the virtual member, and has the option to override it, regardless of whether class B declared an override for that member. 
     * The following code provides an example:
    */
    public class A
    {
        public virtual void DoWork() { Console.WriteLine("Working in A!"); }
    }
    public class B : A
    {
        public override void DoWork() { Console.WriteLine("Working in B!"); }
    }

    /*
     * A derived class can stop virtual inheritance by declaring an override as sealed. This requires putting the sealed keyword before the override keyword in the class member declaration. 
     * The following code provides an example:
    */

    public class C : B
    {
        public sealed override void DoWork() { Console.WriteLine("Working in C!"); }
    }

    /*
     * In the previous example, the method DoWork is no longer virtual to any class derived from C. 
     * It is still virtual for instances of C, even if they are cast to type B or type A. 
     * Sealed methods can be replaced by derived classes by using the new keyword, as the following example shows:
    */
    public class D : C
    {
        /*
         * In this case, if DoWork is called on D using a variable of type D, the new DoWork is called. 
         * If a variable of type C, B, or A is used to access an instance of D, a call to DoWork will follow the rules of virtual inheritance, routing those calls to the implementation of DoWork on class C.
        */
        public new void DoWork() { Console.WriteLine("Working in D!"); }
    }

    public class ABCD
    {
        public static void Demonstrate()
        {
            D finalInstance = new D();
            finalInstance.DoWork(); // will print "Working in D!"
            C cInstance = new D();
            cInstance.DoWork(); //will print "Working in C!"
            B bInstance = new D();
            bInstance.DoWork(); //will print "Working in C!"
            A aInstance = new D();
            aInstance.DoWork(); //will print "Working in C!"
        }
    }

    /*
     * Accessing Base Class Virtual Members from Derived Classes
     * A derived class that has replaced or overridden a method or property can still access the method or property on the base class using the base keyword. 
     * The following code provides an example:
     */
    public class Base
    {
        public virtual void DoWork() { Console.WriteLine("This is base doing the work!"); }
    }
    public class Derived : Base
    {
        public override void DoWork()
        {
            //Perform Derived's work here
            Console.WriteLine("This is derived working now, I will pass the control to base shortly!");
            // Call DoWork on base class
            base.DoWork();
        }
    }

}