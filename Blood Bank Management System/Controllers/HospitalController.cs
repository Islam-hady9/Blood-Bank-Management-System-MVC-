using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Management_System.Controllers
{
	public class HospitalController : Controller
	{
		public readonly BloodBankDbContext _context;        // create, read, update, delete

		public HospitalController(BloodBankDbContext context)
		{
			_context = context;
		}

		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]  // To more security, It ensures that the request originated from the same application.
        public IActionResult AddHospital(Hospital hospital)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(hospital);
                    _context.SaveChanges();
                    return View("/Views/Home/SignIn.cshtml");
                }
                return View("/Views/Hospital/Registration.cshtml");
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/Hospital/Registration.cshtml");
            }
        }

        [HttpPost]
        public IActionResult AddSignIn(string HospitalEmail, string HospitalPassword)
        {
            var hospital = _context.Hospitals.FirstOrDefault(u => u.HospitalEmail == HospitalEmail);

            if (hospital == null)
            {
                return View("/Views/Hospital/Registration.cshtml");
            }
            else if (hospital.Password != HospitalPassword)
            {
                ModelState.AddModelError("", "Invalid password");
                return View("/Views/Home/SignIn.cshtml");
            }

            HttpContext.Session.SetString("HospitalName", hospital.HospitalName);

            return View("/Views/Home/MainPage.cshtml");
        }
    }
}
