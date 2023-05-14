using System.ComponentModel;
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
        //[Required(ErrorMessage = "Blood Bank ID is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodBankId { get; set; }
        [Required(ErrorMessage = "Blood Bank Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Blood Bank Email is invalid")]
        public string BloodBankEmail { get; set; }
        [Required(ErrorMessage = "Blood Bank Group is required.")]
        public BloodType BloodGroup { get; set; }
        [Required(ErrorMessage = "Blood Bank Quantity is required.")]
        public string BloodBankQuantity { get; set; }
        [Required(ErrorMessage = "Blood Bank Status is required.")]
        public BloodStatus StatusOfBlood { get; set; }

        // The Defult Constractor
        public BloodBank()
        {
            //this.BloodBankId = 1;
            this.BloodBankEmail = string.Empty;
            this.BloodGroup = BloodType.A;
            this.BloodBankQuantity = "0";
            this.StatusOfBlood = BloodStatus.Fresh;
        }
    }
}