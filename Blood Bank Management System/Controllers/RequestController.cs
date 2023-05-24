using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blood_Bank_Management_System.Controllers
{
    public class RequestController : Controller
    {
        public readonly BloodBankDbContext _context;        // create, read, update, delete

        public RequestController(BloodBankDbContext context)
        {
            _context = context;
        }

        public IActionResult ViewRequests()
        {
            List<Require> requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).ToList();
            return View("/Views/Home/viewRequests.cshtml", requires);
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            ViewData["Requests"] = _context.Requests.ToList();

            return View(new Request());
        }

        [HttpPost]
        public IActionResult AddRequest(Request request)
        {
            if (ModelState.IsValid)
            {
                var Bank = _context.BloodBanks.Find(request.BloodBankId);
                var NewReq = new Request
                {
                    RequestID = request.RequestID,
                    RequestBloodQuantity = request.RequestBloodQuantity,
                    RequestBloodType = request.RequestBloodType,
                    RequestDate = request.RequestDate,
                    RequestStatus = request.RequestStatus,
                };
                _context.Requests.Add(NewReq);
                _context.SaveChanges();
                return View("/Views/BloodBank/SearchBlood.cshtml");
            }
            return View(request);
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult AddRec(Require require)
        {
            try
            {
                _context.Add(require);
                _context.SaveChanges();
                List<Require> requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).ToList();

                return View("/Views/Home/ViewRequests.cshtml", requires);
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/Request/AddRec.cshtml");
            }
        }

        public IActionResult SearchForRequestByEveryThing(int id, string name, string location, BloodType blood)
        {
            if (id != 0)
            {
                var requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).Where(r => r.RequestID == id).ToList();
                return View("/Views/Request/SearchRequest.cshtml", requires);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).Where(r => r.Hospital.HospitalName == name).ToList();
                return View("/Views/Request/SearchRequest.cshtml", requires);
            }
            else if (!string.IsNullOrEmpty(location))
            {
                var requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).Where(r => r.Hospital.HospitalLocation == location).ToList();
                return View("/Views/Request/SearchRequest.cshtml", requires);
            }
            else if (Enum.IsDefined(typeof(BloodType), blood) && blood != default(BloodType))
            {
                var requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).Where(r => r.Request.RequestBloodType == blood).ToList();
                return View("/Views/Request/SearchRequest.cshtml", requires);
            }
            else
            {
                return View("/Views/Request/SearchRequest.cshtml");
            }
        }

        public IActionResult RemoveId(int id)
        {
            var req = _context.Requests.Find(id);
            if (req != null)
            {
                _context.Remove(req);
                _context.SaveChanges();
                return View("/Views/Request/Delete.cshtml", req);
            }
            return View("/Views/Request/Delete.cshtml");
        }

        public IActionResult GetRequestDataById(int id)
        {
            var requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request)
                .Where(r => r.RequestID == id).ToList();

            return View("/Views/Request/Update.cshtml", requires);
        }

        public IActionResult UpdateRequest(Require updatedRequire)
        {
            // Updateing it.
            _context.Update(updatedRequire);
            _context.SaveChanges();

            // Getting data and return to the Request view.
            List<Require> requires = _context.Requires.Include(r => r.Hospital).Include(r => r.Request).ToList();
            return View("/Views/Home/ViewRequests.cshtml", requires);
        }
    }
}
