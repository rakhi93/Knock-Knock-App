using KnockKnock.Web.Models;
using System.Collections.Generic;
using System.ServiceModel;
namespace KnockKnock.Service
{
     [ServiceContract] // Note:SOAP Service
    public interface IRequestService
    {
        [OperationContract]  // Note:SOAP Service
        List<Request> CheckForRequests();
 
        [OperationContract]
        bool UpdateRequest(int requestID, bool approve);
    }

}