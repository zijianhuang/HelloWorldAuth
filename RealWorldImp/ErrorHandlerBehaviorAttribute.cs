using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Diagnostics;

namespace Fonlow.Demo.RealWorldService
{
    /// <summary>
    /// Handle uncaught exceptions, As described in the WCF book, page 285.
    /// FaultException will be in Warning trace, and other exceptions will be in Error trace.
    /// </summary>
    /// <remarks>It is important to have this to catch exception thrown by the runtime.</remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class ErrorHandlerBehaviorAttribute : Attribute, IServiceBehavior, IErrorHandler
    {
        Type ServiceType
        { get; set; }

        void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            //do nothing
            Debug.WriteLine(String.Format("IServiceBehavior.AddBindingParameters -- Service name: {0}  namespace: {1}", serviceDescription.Name, serviceDescription.Namespace));
            Debug.WriteLine(String.Concat(endpoints.Select(d => String.Format("Contract: {0} Address: {1}\n", d.Contract, d.Address)).ToArray()));
        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase host)
        {
            Trace.WriteLine("Ready to ApplyDispatchBehavior...");
            ServiceType = description.ServiceType;
            foreach (ChannelDispatcher dispatcher in host.ChannelDispatchers)
            {
                if (dispatcher.Endpoints[0].ContractName == "TargetService")
                {
                    Trace.WriteLine("Ignore TargetService");
                    continue;
                }
                Trace.WriteLine(String.Format("To add error handler to this dispatcher: {0}", String.Join(", ",
                    dispatcher.Endpoints.Select(d => String.Format("[{0}, {1}]", d.ContractName, d.EndpointAddress.ToString())))));
                dispatcher.ErrorHandlers.Add(this);
                Debug.WriteLine("Added.");
            }
        }


        void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Debug.WriteLine("IServiceBehavior.Validate");
        }

        /// <summary>
        /// Trace the error, and the session should then abort.
        /// </summary>
        /// <param name="error"></param>
        /// <returns>Always false, so the session will abort.</returns>
        /// <remarks>called after returning to the client</remarks>
        bool IErrorHandler.HandleError(Exception error)
        {
            string errorMessage = "ErrorHandlerBehaviorAttribute: " + error.ToString();
            if (error is FaultException)
            {
                // Trace.TraceWarning(errorMessage);
                Trace.TraceWarning(errorMessage);
            }
            else
            {
                Trace.TraceError(errorMessage);
            }
            return false;
        }


        /// <remarks>called before returning to the client.</remarks>
        void IErrorHandler.ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            //do nothing, just let the runtime generate fault.
        }
    }
}
