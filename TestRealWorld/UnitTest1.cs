using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fonlow.Demo.RealWorldService;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.Principal;

namespace TestRealWorld
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
         //Use ClassInitialize to run code before running the first test in the class
         [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
         [TestInitialize()]
         public void MyTestInitialize()
         {
             AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
             GenericPrincipal principal = new GenericPrincipal(System.Threading.Thread.CurrentPrincipal.Identity, new string[] { "Customer" });
             System.Threading.Thread.CurrentPrincipal = principal;
         }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetData()
        {
            IService1 service = new Service1();
            Assert.IsTrue(service.GetData(1234).Contains("1234"));
        }

        [TestMethod]
        public void TestGetDataUsingDataContract()
        {
            IService1 service = new Service1();
            CompositeType data = new CompositeType()
            {
                BoolValue = true,
                StringValue = "Good",
            };

            CompositeType result = service.GetDataUsingDataContract(data);
            Assert.AreEqual("GoodSuffix", result.StringValue);

            data = new CompositeType()
            {
                BoolValue = false,
                StringValue = "Good",
            };
            result = service.GetDataUsingDataContract(data);
            Assert.AreEqual("Good", result.StringValue);

            try
            {
                result = service.GetDataUsingDataContract(null);
                Assert.Fail("Hey, I expect ArgumentNullException.");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true, "Very good, excepted.");
            }

        }
    }
}
