using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Management_System.Controllers
{
    public class RequestController : Controller
    {
        public readonly BloodBankDbContext _context;        // create, read, update, delete


        public RequestController(BloodBankDbContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {
            return View();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Request request)
        {
            try
            {
                _context.Add(request);
                _context.SaveChanges();
                List<Request> requests = _context.Requests.ToList();
                return View("/Views/Home/ViewRequests.cshtml", requests);
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/Request/Add.cshtml");
            }
        }
        public IActionResult SearchRequest(int id)
        {
            return View("/Views/Request/SearchRequest.cshtml", _context.Requests.Find(id));
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
        public IActionResult Show()
        {
            List<Request> requests = _context.Requests.ToList();
            return View("/Views/Home/viewRequests.cshtml", requests);
        }

    }
}
