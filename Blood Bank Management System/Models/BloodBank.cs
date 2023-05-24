using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Bank_Management_System.Models
{
    public enum BloodStatus
    {
        Fresh, NotFresh
    }
    public class BloodBank
    {
        // Blood Bank Data & Data Annotation...
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodBankId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Blood Bank Email is required.")]
        public string BloodBankEmail { get; set; }

        [Required(ErrorMessage = "Blood Bank Group is required.")]
        public BloodType BloodGroup { get; set; }

        [Required(ErrorMessage = "Blood Bank Quantity is required.")]
        [Range(0, 5, ErrorMessage = "Blood Bank Quantity is between 1 and 5.")]
        public int BloodBankQuantity { get; set; }

        [Required(ErrorMessage = "Blood Bank Status is required.")]
        public BloodStatus StatusOfBlood { get; set; }

        public ICollection<Employee>? Employees { get; set; }

        public ICollection<Donor>? Donors { get; set; }

        public ICollection<Request>? Requests { get; set; }

        // The Defult Constractor
        public BloodBank()
        {
            // this.BloodBankId = 1;
            this.BloodBankEmail = string.Empty;
            this.BloodGroup = BloodType.A;
            this.BloodBankQuantity = 0;
            this.StatusOfBlood = BloodStatus.Fresh;
            Employees = new List<Employee>();
            Donors = new List<Donor>();
            Requests = new List<Request>();
        }

        public static implicit operator int(BloodBank? v)
        {
            throw new NotImplementedException();
        }
    }
}