using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blood_Bank_Management_System.Controllers
{
    public class BloodBankController : Controller
    {
        public readonly BloodBankDbContext _context;        // create, read, update, delete

        public BloodBankController(BloodBankDbContext context)
        {
            _context = context;
        }

        public IActionResult BloodBank()
        {
            List<BloodBank> bloodbanks = _context.BloodBanks.ToList();
            if (bloodbanks.Count == 0)
            {
                return View("/Views/Home/BloodBank.cshtml");
            }
            return View("/Views/Home/BloodBank.cshtml", bloodbanks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // To more security, It ensures that the request originated from the same application.
        public IActionResult Add(BloodBank bloodBank)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bloodBank);
                    _context.SaveChanges();
                    List<BloodBank> bloodBanks = _context.BloodBanks.ToList();
                    return View("/Views/Home/BloodBank.cshtml", bloodBanks);
                }
                return View("/Views/Home/MainPage.cshtml");
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/BloodBank/AddBlood.cshtml");
            }
        }

        [HttpGet]
        public IActionResult AddBlood()
        {
            return View(new BloodBank());
        }

        [HttpPost]
        public IActionResult AddBlood(BloodBank bloodBank)
        {
            if (ModelState.IsValid)
            {
                _context.BloodBanks.Add(bloodBank);
                _context.SaveChanges();
                ViewData["bloodBanks"] = _context.BloodBanks.ToList();
                return View("/Views/Home/BloodBank.cshtml");
            }
            return View(bloodBank);
        }

        public IActionResult DeleteBlood()
        {
            return View();
        }

        public IActionResult SearchBlood()
        {
            return View();
        }

        public IActionResult UpdateBlood()
        {
            return View();
        }

        public IActionResult GetBloodBankDataById(int id)
        {
            var bloodbank1 = _context.BloodBanks.Find(id);
            var bloodbank2 = bloodbank1;
            if (bloodbank1 != null)
            {
                _context.BloodBanks.Remove(bloodbank1);
                _context.SaveChanges();
                return View("/Views/BloodBank/UpdateBlood.cshtml", bloodbank2);
            }
            return View("/Views/BloodBank/UpdateBlood.cshtml");
        }

        public IActionResult UpdateBloodBank(BloodBank bloodbank)
        {
            // Adding new one.
            _context.Add(bloodbank);
            _context.SaveChanges();

            // Getting data and return to the BloodBank view.
            List<BloodBank> bloodbanks = _context.BloodBanks.ToList();
            if (bloodbanks.Count == 0)
            {
                return View("/Views/Home/BloodBank.cshtml");
            }
            return View("/Views/Home/BloodBank.cshtml", bloodbanks);
        }

        public IActionResult Search(int id)
        {
            // Blood Bank
            var bloodBank1 = _context.BloodBanks.Find(id);
            if (bloodBank1 == null)
            {
                return NotFound();
            }
            ViewData["BloodBanks"] = bloodBank1;

            // Employees
            var bloodBank2 = _context.BloodBanks.Include(bb => bb.Employees).FirstOrDefault(bb => bb.BloodBankId == id);
            if (bloodBank2 == null)
            {
                return NotFound();
            }
            /*
             * In this code, the null conditional operator (?.) is used to check if bloodBank1.Employees is null.
             * If it's not null, the ToList() method is called.
             * Otherwise, a new empty list of type Employee is assigned.
             * This ensures that ViewData["Employees"] will always contain a non-null list, even if bloodBank1.Employees is null.
             */
            ViewData["Employees"] = bloodBank2.Employees?.ToList() ?? new List<Employee>();

            // Doner
            var bloodBank3 = _context.BloodBanks.Include(bb => bb.Donors).FirstOrDefault(bb => bb.BloodBankId == id);
            if (bloodBank3 == null)
            {
                return NotFound();
            }
            ViewData["Donors"] = bloodBank3.Donors?.ToList() ?? new List<Donor>();

            // Request
            var bloodBank4 = _context.BloodBanks.Include(bb => bb.Requests).FirstOrDefault(bb => bb.BloodBankId == id);
            if (bloodBank4 == null)
            {
                return NotFound();
            }
            ViewData["Requests"] = bloodBank4.Requests?.ToList() ?? new List<Request>();

            return View("/Views/BloodBank/SearchBlood.cshtml");
        }

        public IActionResult RemoveId(int id)
        {
            var blood = _context.BloodBanks.Find(id);
            if (blood != null)
            {
                _context.BloodBanks.Remove(blood);
                _context.SaveChanges();
                return View("/Views/BloodBank/DeleteBlood.cshtml", blood);
            }
            return View("/Views/BloodBank/DeleteBlood.cshtml");
        }
    }
}
