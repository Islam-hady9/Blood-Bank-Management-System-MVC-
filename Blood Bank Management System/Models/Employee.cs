using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Bank_Management_System.Models
{
    public enum EmployeeType { Manager, Technician }
    public class Employee
    {
        [Key]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Employee ID should be exactly 14 at length.")]
        [Required(ErrorMessage = "Employee ID is required.")]
        public string EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Employee Name should contain only letters and spaces")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee Age is required.")]
        [Range(25, 60, ErrorMessage = "Employee Age should be between 25 and 60.")]
        public int EmployeeAge { get; set; }

        [Required(ErrorMessage = "Employee Address is required.")]
        public string EmployeeAddress { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Employee Email is required.")]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Employee Phone is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Employee Phone should be exactly 11 length.")]
        [RegularExpression(@"^01[0125]\d{8}$", ErrorMessage = "Employee Phone should start with '01' and have a length of 11.")]
        public string EmployeePhone { get; set; }

        [Required(ErrorMessage = "Employee Type is required.")]
        public EmployeeType Field { get; set; }

        [DefaultValue("default.png")]
        public string ImageName { get; set; }

        public int BloodBankId { get; set; }

        [ForeignKey("BloodBankId")]
        public BloodBank? BloodBank { get; set; }

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
