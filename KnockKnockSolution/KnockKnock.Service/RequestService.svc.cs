using KnockKnock.Web.Data;
using KnockKnock.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace KnockKnock.Service
{
    public class RequestService : IRequestService
    {
        // Fetch all requests (pending, approved, rejected)
        public List<Request> CheckForRequests()
        {
            using (var db = new RequestContext())
            {
                return db.Request.ToList(); // Return all requests, not just pending ones
            }
        }

        // Update request status and ensure changes are saved
        public bool UpdateRequest(int requestID, bool approve)
        {
            using (var db = new RequestContext())
            {
                var request = db.Request.Find(requestID);
                if (request == null) return false;

                request.Status = approve ? 1 : 2; // 1 = Approved, 2 = Rejected
                request.UpdatedAt = DateTime.Now; // Update the timestamp
                db.SaveChanges();

                return true;
            }
        }
    }
}
