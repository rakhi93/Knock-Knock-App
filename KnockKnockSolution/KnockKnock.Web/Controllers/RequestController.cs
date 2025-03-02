using KnockKnock.Web.Data;
using KnockKnock.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KnockKnock.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly RequestContext _context = new RequestContext();

        public ActionResult Index(DateTime? filterDate)
        {
            var requests = _context.Request.ToList(); // Load all requests by default

            if (filterDate.HasValue)
            {
                requests = requests.Where(r => r.CreatedAt.Date == filterDate.Value.Date).ToList();
                ViewBag.FilterDate = filterDate.Value.ToString("yyyy-MM-dd"); // Preserve selected date
            }
            else
            {
                ViewBag.FilterDate = ""; // Clear filter when no date is selected
            }

            return View(requests);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var request = new Request { CreatedAt = DateTime.Now, Status = 0 };
            _context.Request.Add(request);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Request successfully submitted! Please wait for approval.";
            return RedirectToAction("Index"); // ✅ Redirect back to index to display success message
        }
    }
}
