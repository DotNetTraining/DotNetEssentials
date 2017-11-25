using System;


namespace OOPCChapter5
{
    /// <summary>
    /// An Empty class to demonstrate Xml Documentation Comments
    /// </summary>
    public class SampleClass
    {
        /// <summary>
        /// Store for the name property.</summary>
        private string _name = null;

        /// <summary>
        /// Name property. </summary>
        /// <value>
        /// A value tag is used to describe the property value.</value>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    throw new System.Exception("Name is null");
                }
                return _name;
            }
        }

        /// <summary>
        /// A sample method to demonstrate usage of Xml Comments
        /// </summary>
        /// <param name="parameter1">First input paramter1.</param>
        /// <param name="parameter2">Second input parameter2.</param>
        public void SampleMethod1(int parameter1, string parameter2)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OOPCChapter5.SampleClass"/> class.
        /// </summary>
        private SampleClass()
        {
            
        }

        /// <summary>
        /// Create the instance of Sample Class.
        /// </summary>
        /// <returns>returns a new instance of the <see cref="T:OOPCChapter5.SampleClass"/> class.</returns>
        public static SampleClass Create()
        {
            return new SampleClass();
        }

        /// <summary>
        /// Description for SomeMethod.</summary>
        /// <param name="s"> Parameter description for s goes here.</param>
        /// <seealso cref="System.String">
        /// You can use the cref attribute on any tag to reference a type or member 
        /// and the compiler will check that the reference exists. </seealso>
        public void SomeMethod(string s)
        {
        }

        /// <summary>
        /// Some other method. </summary>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        /// <seealso cref="SomeMethod(string)">
        /// Notice the use of the cref attribute to reference a specific method. </seealso>
        public int SomeOtherMethod()
        {
            return 0;
        }
    }

    /// <summary>
    /// Documentation that describes the interface goes here.
    /// </summary>
    /// <remarks>
    /// Details about the interface go here.
    /// </remarks>
    interface TestInterface
    {
        /// <summary>
        /// Documentation that describes the method goes here.
        /// </summary>
        /// <param name="n">
        /// Parameter n requires an integer argument.
        /// </param>
        /// <returns>
        /// The method returns an integer.
        /// </returns>
        int InterfaceMethod(int n);
    }
}