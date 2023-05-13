using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Management_System.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public readonly BloodBankDbContext _context;        // create, read, update, delete

        public DonorController(BloodBankDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Donor donor)
        {
            try
            {
                _context.Add(donor);
                _context.SaveChanges();
                List<Donor> donors = _context.Donors.ToList();
                return View("/Views/Home/Donors.cshtml", donors);
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/Donor/AddDonor.cshtml");
            }
        }
        public IActionResult AddDonor()
        {
            return View();
        }

        public IActionResult DeleteDonor()
        {
            return View();
        }

        public IActionResult SearchDonor()
        {
            return View();
        }

        public IActionResult UpdateDonor()
        {
            return View();
        }

        public IActionResult Show()
        {
            List<Donor> donors = _context.Donors.ToList();
            return View("/Views/Home/Donors.cshtml", donors);
        }
        public IActionResult Search(string id)
        {
            return View("/Views/Donor/SearchDonor.cshtml", _context.Donors.Find(id));
        }
        public IActionResult RemoveId(string id)
        {
            var don = _context.Donors.Find(id);
            if (don != null)
            {
                _context.Donors.Remove(don);
                _context.SaveChanges();
                return View("/Views/Donor/DeleteDonor.cshtml", don);
            }
            return View("/Views/Donor/DeleteDonor.cshtml");
        }
    }
}
