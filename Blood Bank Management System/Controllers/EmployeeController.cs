using Blood_Bank_Management_System.Data;
using Blood_Bank_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Bank_Management_System.Controllers
{
	public class EmployeeController : Controller
	{
		public readonly BloodBankDbContext _context;        // create, read, update, delete
		public readonly IWebHostEnvironment _environment;

		public EmployeeController(IWebHostEnvironment environment, BloodBankDbContext context)
		{
			_environment = environment;
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
		[ValidateAntiForgeryToken]  // To more security, It ensures that the request originated from the same application.
		public async Task<IActionResult> Create(Employee employee, IFormFile uploaded_file)
		{
			// To create Images folder in the project Path.
			string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (uploaded_file != null)
			{
				path = Path.Combine(path, uploaded_file.FileName); // For exmple: /Img/Photoname.png
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await uploaded_file.CopyToAsync(stream);
					employee.ImageName = path;
				}
			}
			else
			{
				path = Path.Combine(path, "default.png");
				employee.ImageName = path;
			}
			try
			{
				_context.Add(employee);
				_context.SaveChanges();
				List<Employee> employees = _context.Employees.ToList();
				return View("/Views/Home/Management.cshtml", employees);
				// return RedirectToAction("Management", "Home");
			}
			catch (Exception ex)
			{
				ViewBag.exc = ex.Message;
				return View("/Views/Employee/Add.cshtml");
			}
		}
		public IActionResult Show()
		{
			List<Employee> employees = _context.Employees.ToList();
			return View("/Views/Home/Management.cshtml", employees);
		}
		public IActionResult Search2(string id)
		{
			return View("/Views/Employee/Search.cshtml", _context.Employees.Find(id));
		}
		public IActionResult RemoveId(string id)
		{
			var emp = _context.Employees.Find(id);
			if (emp != null)
			{
				_context.Employees.Remove(emp);
				_context.SaveChanges();
				return View("/Views/Employee/Delete.cshtml", emp);
			}
			return View("/Views/Employee/Delete.cshtml");
		}
	}
}