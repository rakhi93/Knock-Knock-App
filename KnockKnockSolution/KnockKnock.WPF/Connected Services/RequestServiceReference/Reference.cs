
namespace RequestServiceReference
{   
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Request", Namespace="http://schemas.datacontract.org/2004/07/KnockKnock.Web.Models")]
    public partial class Request : object
    {
        private System.DateTime CreatedAtField;
        
        private int RequestIDField;
        
        private int StatusField;
        
        private System.Nullable<System.DateTime> UpdatedAtField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.CreatedAtField;
            }
            set
            {
                this.CreatedAtField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RequestID
        {
            get
            {
                return this.RequestIDField;
            }
            set
            {
                this.RequestIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> UpdatedAt
        {
            get
            {
                return this.UpdatedAtField;
            }
            set
            {
                this.UpdatedAtField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RequestServiceReference.IRequestService")]
    public interface IRequestService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestService/CheckForRequests", ReplyAction="http://tempuri.org/IRequestService/CheckForRequestsResponse")]
        System.Threading.Tasks.Task<RequestServiceReference.Request[]> CheckForRequestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestService/UpdateRequest", ReplyAction="http://tempuri.org/IRequestService/UpdateRequestResponse")]
        System.Threading.Tasks.Task<bool> UpdateRequestAsync(int requestID, bool approve);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IRequestServiceChannel : RequestServiceReference.IRequestService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class RequestServiceClient : System.ServiceModel.ClientBase<RequestServiceReference.IRequestService>, RequestServiceReference.IRequestService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public RequestServiceClient() : 
                base(RequestServiceClient.GetDefaultBinding(), RequestServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IRequestService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RequestServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(RequestServiceClient.GetBindingForEndpoint(endpointConfiguration), RequestServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RequestServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(RequestServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RequestServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(RequestServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RequestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<RequestServiceReference.Request[]> CheckForRequestsAsync()
        {
            return base.Channel.CheckForRequestsAsync();
        }
        
        public System.Threading.Tasks.Task<bool> UpdateRequestAsync(int requestID, bool approve)
        {
            return base.Channel.UpdateRequestAsync(requestID, approve);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRequestService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRequestService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:52530/RequestService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return RequestServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IRequestService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return RequestServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IRequestService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IRequestService,
        }
    }
}
