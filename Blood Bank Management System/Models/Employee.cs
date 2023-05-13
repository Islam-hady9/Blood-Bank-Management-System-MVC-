using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blood_Bank_Management_System.Models
{
    public enum EmployeeType { Manager, Technician }
    public class Employee
    {
        [Key]
        [StringLength(14)]
        [Required(ErrorMessage = "Employee ID is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Employee ID should contain only digits.")]
        public string EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee Age is required.")]
        [Range(25, 60, ErrorMessage = "Employee Age should be between 25 and 60.")]
        public int EmployeeAge { get; set; }

        [Required(ErrorMessage = "Employee Address is required.")]
        public string EmployeeAddress { get; set; }

        [Required(ErrorMessage = "Employee Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Employee Email is invalid")]
        public string EmployeeEmail { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "Employee Phone is required.")]
        [RegularExpression(@"^01[0125]\d{8}$", ErrorMessage = "Employee Phone should start with '01' and have a length of 11.")]
        public string EmployeePhone { get; set; }

        [Required(ErrorMessage = "Employee Type is required.")]
        public EmployeeType Field { get; set; }

        [DefaultValue("default.png")]
        [Required(ErrorMessage = "Image Name is required.")]
        public string ImageName { get; set; }

        // To establish relationships between Employee and Request entities.
        // public ICollection<Request> Enrollments { get; set; }    // As ArrayList.

        // Default Constructor
        public Employee()
        {
            this.EmployeeName = string.Empty;
            this.EmployeeID = string.Empty;
            this.EmployeePhone = string.Empty;
            this.EmployeeAddress = string.Empty;
            this.EmployeeEmail = string.Empty;
            this.EmployeeAge = 25;
            this.Field = EmployeeType.Manager;
            this.ImageName = string.Empty;
        }
    }
}
