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

        public IActionResult Management()
        {
            List<Employee> employees = _context.Employees.ToList();
            if (employees.Count == 0)
            {
                return View("/Views/Home/Management.cshtml");
            }
            return View("/Views/Home/Management.cshtml", employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["bloodBanks"] = _context.BloodBanks.ToList();
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var Bank = _context.BloodBanks.Find(employee.BloodBankId);
                var NewEmp = new Employee
                {
                    EmployeeName = employee.EmployeeName,
                    EmployeeID = employee.EmployeeID,
                    EmployeePhone = employee.EmployeePhone,
                    EmployeeAddress = employee.EmployeeAddress,
                    EmployeeEmail = employee.EmployeeEmail,
                    EmployeeAge = employee.EmployeeAge,
                    Field = employee.Field,
                    ImageName = employee.ImageName,
                    BloodBankId = Bank
                };
                _context.Employees.Add(NewEmp);
                _context.SaveChanges();
                return View("/Views/BloodBank/SearchBlood.cshtml");
            }
            return View(employee);
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

        public IActionResult GetEmployeeDataById(string id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                return View("/Views/Employee/Update.cshtml", employee);
            }
            return View("/Views/Employee/Update.cshtml");
        }

        public IActionResult UpdateEmployee(Employee employee, IFormFile uploaded_file)
        {
            // Deleting the employee.
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }

            // Image Name.
            string path = "/Img";
            path = Path.Combine(path, uploaded_file.FileName);
            path = path.Replace("\\", "/");
            employee.ImageName = path;

            // Adding new one.
            _context.Add(employee);
            _context.SaveChanges();

            // Getting data and return to the Management view.
            List<Employee> employees = _context.Employees.ToList();
            if (employees.Count == 0)
            {
                return View("/Views/Home/Management.cshtml");
            }
            return View("/Views/Home/Management.cshtml", employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // To more security, It ensures that the request originated from the same application.
        public async Task<IActionResult> Create(Employee employee, IFormFile uploaded_file)
        {
            // To create Images folder in the project Path.
            string path = Path.Combine(_environment.WebRootPath, "Img");
            string path2 = "/Img";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (uploaded_file != null)
            {
                path = Path.Combine(path, uploaded_file.FileName);
                path2 = Path.Combine(path2, uploaded_file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await uploaded_file.CopyToAsync(stream);
                }
            }
            else
            {
                path2 = Path.Combine(path2, "default.png");
            }
            path2 = path2.Replace("\\", "/");
            employee.ImageName = path2;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employee);
                    _context.SaveChanges();
                    List<Employee> employees = _context.Employees.ToList();
                    return View("/Views/Home/Management.cshtml", employees);
                }
                return View("/Views/Employee/Add.cshtml");
                // return RedirectToAction("Management", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.exc = ex.Message;
                return View("/Views/Employee/Add.cshtml");
            }
        }

        public IActionResult SearchForEmployeeByEveryThing(string id, string name, int age, string address, EmployeeType function)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var employees = _context.Employees.Where(e => e.EmployeeID == id).ToList();
                return View("/Views/Employee/Search.cshtml", employees);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var employees = _context.Employees.Where(e => e.EmployeeName == name).ToList();
                return View("/Views/Employee/Search.cshtml", employees);
            }
            else if (age != 0)
            {
                var employees = _context.Employees.Where(e => e.EmployeeAge == age).ToList();
                return View("/Views/Employee/Search.cshtml", employees);
            }
            else if (!string.IsNullOrEmpty(address))
            {
                var employees = _context.Employees.Where(e => e.EmployeeAddress == address).ToList();
                return View("/Views/Employee/Search.cshtml", employees);
            }
            else if (Enum.IsDefined(typeof(EmployeeType), function) && function != default(EmployeeType))
            {
                var employees = _context.Employees.Where(e => e.Field == function).ToList();
                return View("/Views/Employee/Search.cshtml", employees);
            }
            else
            {
                return View("/Views/Employee/Search.cshtml");
            }
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