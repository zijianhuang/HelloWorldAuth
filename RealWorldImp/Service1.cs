using System;
using System.ServiceModel;
using System.Security.Permissions;


namespace Fonlow.Demo.RealWorldService
{
    [ErrorHandlerBehaviorAttribute]
    public class Service1 : IService1 
    {
        public string GetData(int value)
        {
            System.Diagnostics.Trace.WriteLine("GetDataCalled");
            if (value == 666)
                throw new FaultException<Evil666Error>(new Evil666Error() { Message = "Hey, this is 666." });

            return string.Format("You entered: {0}", value);
        }

        [PrincipalPermission(SecurityAction.Demand, Role="Customer")]       
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {         
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }

            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string GetHardData(int value)
        {
            System.Threading.Thread.Sleep(40);
            return string.Format("You entered: {0}", value);
        }
    }
}
