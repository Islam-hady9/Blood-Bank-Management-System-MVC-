using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blood_Bank_Management_System.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }

        public bool RequestStatus { get; set; } // accept or reject

        [Required]
        public string RequestBloodQuantity { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public BloodType RequestBloodType { get; set; }

        // [Required]
        public int BloodBankId { get; set; }

        [ForeignKey("BloodBankId")]
        public BloodBank? BloodBank { get; set; }

        public ICollection<Require>? Requires { get; set; }

        // Default Constructor...
        public Request()
        {
            // this.RequestID = 1;
            this.RequestStatus = true;
            this.RequestBloodQuantity = "0";
            this.RequestDate = DateTime.Now;
            this.RequestBloodType = BloodType.A;
            Requires = new List<Require>();
        }
    }
}