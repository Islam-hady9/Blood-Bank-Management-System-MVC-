using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Management_System.Controllers
{
    public class DonorController : Controller
    {
        // create, read, update, delete
        public readonly BloodBankDbContext _context;

        public DonorController(BloodBankDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddDonor()
        {
            ViewData["Donors"] = _context.Donors.ToList();
            return View(new Donor());
        }

        public IActionResult Donors()
        {
            List<Donor> donors = _context.Donors.ToList();
            if (donors.Count == 0)
            {
                return View("/Views/Home/Donors.cshtml");
            }
            return View("/Views/Home/Donors.cshtml", donors);
        }

        [HttpPost]
        public IActionResult AddDonor(Donor donor)
        {
            if (ModelState.IsValid)
            {
                var Bank = _context.BloodBanks.Find(donor.BloodBankId);
                var NewDon = new Donor
                {
                    DonorName = donor.DonorName,
                    DonorID = donor.DonorID,
                    DonorPhone = donor.DonorPhone,
                    DonorAddress = donor.DonorAddress,
                    DonorGender = donor.DonorGender,
                    DonorAge = donor.DonorAge,
                    LastDonationDate = donor.LastDonationDate,
                    DonorBloodType = donor.DonorBloodType,
                    BloodBankId = Bank
                };
                _context.Donors.Add(NewDon);
                _context.SaveChanges();
                return View("/Views/BloodBank/SearchBlood.cshtml");
            }
            return View(donor);
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

        public IActionResult GetDonorDataById(string id)
        {
            var donor = _context.Donors.Find(id);
            if (donor != null)
            {
                return View("/Views/Donor/UpdateDonor.cshtml", donor);
            }
            return View("/Views/Donor/UpdateDonor.cshtml");
        }

        public IActionResult Update(Donor donor)
        {
            // Deleting the Donor.
            var emp = _context.Donors.FirstOrDefault(d => d.DonorID == donor.DonorID);
            if (emp != null)
            {
                _context.Donors.Remove(emp);
                _context.SaveChanges();
            }

            // Adding new one.
            _context.Add(donor);
            _context.SaveChanges();

            // Getting data and return to the Management view.
            List<Donor> donors = _context.Donors.ToList();
            if (donors.Count == 0)
            {
                return View("/Views/Home/Donors.cshtml");
            }
            return View("/Views/Home/Donors.cshtml", donors);
        }

        public IActionResult SearchForDonorByEveryThing(string id, string name, int age, string address, Gender gender, BloodType blood)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var donors = _context.Donors.Where(e => e.DonorID == id).ToList();
                return View("/Views/Donor/SearchDonor.cshtml", donors);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var donors = _context.Donors.Where(e => e.DonorName == name).ToList();
                return View("/Views/Donor/SearchDonor.cshtml", donors);
            }
            else if (age != 0)
            {
                var donors = _context.Donors.Where(e => e.DonorAge == age).ToList();
                return View("/Views/Donor/SearchDonor.cshtml", donors);
            }
            else if (!string.IsNullOrEmpty(address))
            {
                var donors = _context.Donors.Where(e => e.DonorAddress == address).ToList();
                return View("/Views/Donor/SearchDonor.cshtml", donors);
            }
            else if (Enum.IsDefined(typeof(Gender), gender) && gender != default(Gender))
            {
                var donors = _context.Donors.Where(e => e.DonorGender == gender).ToList();
                return View("/Views/Donor/SearchDonor.cshtml", donors);
            }
            else if (Enum.IsDefined(typeof(BloodType), blood) && blood != default(BloodType))
            {
                var donors = _context.Donors.Where(e => e.DonorBloodType == blood).ToList();
                return View("/Views/Donor/SearchDonor.cshtml", donors);
            }
            else
            {
                return View("/Views/Donor/SearchDonor.cshtml");
            }
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
