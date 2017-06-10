using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Fonlow.RealWorldService.ClientData;
using Fonlow.RealWorldService.Clients;
using System.ServiceModel;
using RealServiceClientApi;

namespace TestRealWorldIntegration
{
    /// <summary>
    /// Summary description for Integration
    /// </summary>
    [Collection(TestConstants.IisExpressAndInit)]
    public class IntegrationTest
    {
        const string realWorldEndpoint = "DefaultBinding_RealWorld";

        [Fact]
        public void TestGetData()
        {
            using (RealWorldProxy client = new RealWorldProxy(realWorldEndpoint))
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "tttttttt";
                Assert.True(client.Instance.GetData(1234).Contains("1234"));
            }

        }

        [Fact]
        public void TestGetData666ExpectedError()
        {

            using (RealWorldProxy client = new RealWorldProxy(realWorldEndpoint))
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "tttttttt";
                var ex = Assert.Throws<FaultException<Evil666Error>>(() =>
                {
                    Assert.True(client.Instance.GetData(666).Contains("1234"));
                    Assert.True(false, "Expect fault");
                });
                ex.Detail.Message.Contains("666");
            }
            //ErrorHandlerBehaviorAttribute in the service side also catch the exception.
        }

        [Fact]
        public void TestGetDataUsingDataContract()
        {
            using (RealWorldProxy client = new RealWorldProxy(realWorldEndpoint))
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "tttttttt";
                CompositeType data = new CompositeType()
                {
                    BoolValue = true,
                    StringValue = "Good",
                };

                CompositeType result = client.Instance.GetDataUsingDataContract(data);
                Assert.Equal("GoodSuffix", result.StringValue);
            }

            using (RealWorldProxy client = new RealWorldProxy(realWorldEndpoint))
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "tttttttt";

                CompositeType data = new CompositeType()
                {
                    BoolValue = false,
                    StringValue = "Good",
                };
                CompositeType result = client.Instance.GetDataUsingDataContract(data);
                Assert.Equal("Good", result.StringValue);
            }

            using (RealWorldProxy client = new RealWorldProxy(realWorldEndpoint))
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "tttttttt";
                try
                {
                    CompositeType result = client.Instance.GetDataUsingDataContract(null);
                    Assert.True(false, "Hey, I expect FaultException.");
                }
                catch (System.ServiceModel.FaultException)
                {
                    Assert.True(true, "Very good, excepted.");
                }
            }

        }

        [Fact]
        public void TestGetDataUsingDataContractThrowsMessageSecurityException()
        {
            using (RealWorldProxy client = new RealWorldProxy(realWorldEndpoint))
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "wrongpwd";

                    CompositeType data = new CompositeType()
                    {
                        BoolValue = true,
                        StringValue = "Good",
                    };

                var ex = Assert.Throws<System.ServiceModel.Security.MessageSecurityException>(() =>
                {
                    CompositeType result = client.Instance.GetDataUsingDataContract(data);
                });

                Assert.True(ex.InnerException is System.ServiceModel.FaultException);
            }

        }

    }


}
