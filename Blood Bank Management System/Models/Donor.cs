using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Bank_Management_System.Models
{
    public enum Gender { Male, Female }
    public enum BloodType
    {
        A,
        B,
        AB,
        O,
        Ap,
        Bp,
        ABp,
        Op,
        An,
        Bn,
        ABn,
        On
    }
    public class Donor
    {
        // Data Members...
        [Required(ErrorMessage = "Donor Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Donor Name should contain only letters and spaces")]
        public string DonorName { get; set; }

        [Key]
        [Required(ErrorMessage = "Donor ID is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Donor ID should contain only digits.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Donor ID should be exactly 14 characters.")]
        public string DonorID { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "Donor Phone is required.")]
        [RegularExpression(@"^01[0125]\d{8}$", ErrorMessage = "Donor Phone should start with '01' and have a length of 11.")]
        public string DonorPhone { get; set; }

        [Required(ErrorMessage = "Donor Address is required.")]
        public string DonorAddress { get; set; }

        [Required(ErrorMessage = "Donor Age is required.")]
        [Range(18, 60, ErrorMessage = "Donor Age should be between 18 and 60.")]
        public int DonorAge { get; set; }

        [Required(ErrorMessage = "Donor Gender is required.")]
        public Gender DonorGender { get; set; }

        [Required(ErrorMessage = "Donor Blood Type is required.")]
        public BloodType DonorBloodType { get; set; }

        [Required(ErrorMessage = "Donor Last Donation Date is required.")]
        public DateTime LastDonationDate { get; set; }

        public int BloodBankId { get; set; }

        [ForeignKey("BloodBankId")]
        public BloodBank? BloodBank { get; set; }

        // Default Constructor...
        public Donor()
        {
            this.DonorName = string.Empty;
            this.DonorID = string.Empty;
            this.DonorPhone = string.Empty;
            this.DonorAddress = string.Empty;
            this.DonorAge = 18;
            this.DonorGender = Gender.Male;
            this.DonorBloodType = BloodType.A;
            this.LastDonationDate = DateTime.Now;
        }
    }
}