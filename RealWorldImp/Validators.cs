using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Security.Principal;
using System.Diagnostics;

//It is event better to put the classes into a shared component
namespace Fonlow.Web.Identity
{
    public class IdentityValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            Debug.WriteLine("Check user name");
            if ((userName != "test") || (password != "tttttttt"))
            {
                var msg = String.Format("Unknown Username {0} or incorrect password {1}", userName, password);
                Trace.TraceWarning(msg);
                throw new FaultException(msg);//the client actually will receive MessageSecurityException. But if I throw MessageSecurityException, the runtime will give FaultException to client without clear message.
            }

        }
    }


    public class RoleAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            // Find out the roleNames from the user database, for example, var roleNames = userManager.GetRoles(user.Id).ToArray();

            var roleNames = new string[] { "Customer" };

            operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = new GenericPrincipal(operationContext.ServiceSecurityContext.PrimaryIdentity, roleNames);
            return true;
        }

    }



}
