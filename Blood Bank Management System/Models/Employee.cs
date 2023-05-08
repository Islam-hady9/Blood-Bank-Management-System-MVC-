using System.Text.RegularExpressions;

namespace Blood_Bank_Management_System.Models
{
    public enum EmployeeType { Manager, Technician }
    public class Employee
    {
        private string employeeName;
        private string employeeID;
        private string employeePhone;
        private string employeeAddress;
        private string employeeEmail;
        private int employeeAge;
        private EmployeeType field;

        // Default Constructor.
        public Employee()
        {
            this.employeeName = "";
            this.employeeID = "";
            this.employeePhone = "";
            this.employeeAddress = "";
            this.employeeEmail = "";
            this.employeeAge = 25;
            this.field = EmployeeType.Manager;
        }

        // Argument Constructor.
        public Employee(string employeeName, string employeeID, string employeePhone, string employeeAddress, string employeeEmail, int employeeAge, EmployeeType field)
        {
            this.employeeName = employeeName;
            if (employeeID.Length == 14 && Regex.IsMatch(employeeID, "^[0-9]+$"))
            {
                this.employeeID = employeeID;
            }
            else
            {
                throw new ArgumentException("Employee ID must be 14 characters long");
            }
            if (employeePhone.Length == 11 && Regex.IsMatch(employeePhone, "^[0-9]+$") && employeePhone[0] == '0')
            {
                this.employeePhone = employeePhone;
            }
            else
            {
                throw new ArgumentException("Employee Phone must be 11 characters long");
            }
            this.employeeAddress = employeeAddress;
            this.employeeEmail = employeeEmail;
            if (employeeAge >= 25 && employeeAge < 60)
            {
                this.employeeAge = employeeAge;
            }
            else
            {
                throw new ArgumentException("Employee Age must be between 25 and 60");
            }
            this.field = field;
        }

        //Setters.
        public void SetEmployeeID(string employeeID)
        {
            if (employeeID.Length == 14 && Regex.IsMatch(employeeID, "^[0-9]+$"))
            {
                this.employeeID = employeeID;
            }
            else
            {
                throw new ArgumentException("Employee ID must be 14 characters long");
            }
        }
        public void SetEmployeeName(string employeeName)
        {
            this.employeeName = employeeName;
        }
        public void SetEmployeePhone(string employeePhone)
        {
            if (employeePhone.Length == 11 && Regex.IsMatch(employeePhone, "^[0-9]+$") && employeePhone[0] == '0')
            {
                this.employeePhone = employeePhone;
            }
            else
            {
                throw new ArgumentException("Employee Phone must be 11 characters long");
            }
        }
        public void SetEmployeeAddress(string employeeAddress)
        {
            this.employeeAddress = employeeAddress;
        }
        public void SetEmployeeEmail(string employeeEmail)
        {
            this.employeeEmail = employeeEmail;
        }
        public void SetEmployeeAge(int employeeAge)
        {
            if (employeeAge >= 25 && employeeAge < 60)
            {
                this.employeeAge = employeeAge;
            }
            else
            {
                throw new ArgumentException("Employee Age must be between 25 and 60");
            }
        }
        public void SetEmployeeType(EmployeeType field)
        {
            this.field = field;
        }

        // Getters.
        public string GetEmployeeID()
        {
            return employeeID;
        }
        public string GetEmployeeName()
        {
            return employeeName;
        }
        public string GetEmployeePhone()
        {
            return employeePhone;
        }
        public string GetEmployeeAddress()
        {
            return employeeAddress;
        }
        public string GetEmployeeEmail()
        {
            return employeeEmail;
        }
        public int GetEmployeeAge()
        {
            return employeeAge;
        }
        public EmployeeType GetEmployeeType()
        {
            return field;
        }
    }
}
