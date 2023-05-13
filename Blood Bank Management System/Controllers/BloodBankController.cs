using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Management_System.Controllers
{
    public class BloodBankController : Controller
    {
        public readonly BloodBankDbContext _context;        // create, read, update, delete
        public readonly IWebHostEnvironment _environment;

        public BloodBankController(IWebHostEnvironment environment, BloodBankDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Add(BloodBank bloodBank)
        {
           
            try
            {
                _context.Add(bloodBank);
                _context.SaveChanges();
                List<BloodBank> bloodBanks = _context.BloodBanks.ToList();
                return View("/Views/Home/BloodBank.cshtml", bloodBanks);
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/BloodBank/AddBlood.cshtml");
            }
        }

        public IActionResult AddBlood()
        {
            return View();
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

        [HttpPost]
        [ValidateAntiForgeryToken]  // To more security, It ensures that the request originated from the same application.
       
        public IActionResult Show()
        {
            List<BloodBank> bloodBanks = _context.BloodBanks.ToList();
            return View("/Views/Home/BloodBank.cshtml", bloodBanks);
        }
        public IActionResult Search(int id)
        {
            return View("/Views/BloodBank/SearchBlood.cshtml", _context.BloodBanks.Find(id));
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
