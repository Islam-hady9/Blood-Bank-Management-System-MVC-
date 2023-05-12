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
				_context.Add(hospital);
				_context.SaveChanges();
				return View("/Views/Home/MainPage.cshtml");
			}
			catch (Exception ex)
			{
				ViewBag.exc = ex.Message;
				return View("/Views/Hospital/Registration.cshtml");
			}
		}
	}
}
