using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blood_Bank_Management_System.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Interface()
		{
			return View();
		}

        public IActionResult RedirectToInterface()
        {
            return View("/Views/Home/Interface.cshtml");
        }

        public IActionResult Donors()
		{
			return View();
		}

        public IActionResult RedirectToDonors()
        {
            return View("/Views/Home/Donors.cshtml");
        }

        public IActionResult Management()
		{
			return View();
		}

        public IActionResult RedirectToManagement()
        {
            return View("/Views/Home/Management.cshtml");
        }

        public IActionResult SearchBlood()
		{
			return View();
		}

        public IActionResult RedirectToSearchBlood()
        {
            return View("/Views/Home/SearchBlood.cshtml");
        }

        public IActionResult Hospitals()
		{
			return View();
		}

        public IActionResult RedirectToHospitals()
        {
            return View("/Views/Home/Hospitals.cshtml");
        }

        public IActionResult RequestBlood()
		{
			return View();
		}

        public IActionResult RedirectToRequestBlood()
        {
            return View("/Views/Home/RequestBlood.cshtml");
        }

        public IActionResult SendRequest()
		{
			return View();
		}

        public IActionResult RedirectToSendRequest()
        {
            return View("/Views/Home/SendRequest.cshtml");
        }

        public IActionResult ViewRequests()
		{
			return View();
		}

		public IActionResult RedirectToViewRequests()
		{
			return View("/Views/Home/ViewRequests.cshtml");
		}
	}
}