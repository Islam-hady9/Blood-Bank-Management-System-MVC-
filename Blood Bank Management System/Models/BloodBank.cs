using System.ComponentModel.DataAnnotations;

namespace Blood_Bank_Management_System.Models
{
    public enum BloodStatus
    {
        Fresh, NotFresh
    }
    public class BloodBank
    {
        // Blood Bank Data
        [Key]
        public int BloodBankId { get; set; }
        public float BloodBankQuantity { get; set; }
        public BloodType BloodGroup { get; set; }
        public BloodStatus StatusOfBlood { get; set; }

        // The Defult Constractor
        public BloodBank()
        {
            this.BloodBankId = 1;
            this.BloodBankQuantity = 0.0f;
            this.BloodGroup = BloodType.A;
            this.StatusOfBlood = BloodStatus.Fresh;
        }

        // The Argument Constractor //
        //public BloodBank(int bloodBankId, float bloodBankQuantity, BloodType bloodGroup, BloodStatus statusOfBlood)
        //{
        //    if (bloodBankId <= 0)
        //    {
        //        throw new ArgumentException("Blood Bank Id must be greater than 0");
        //    }
        //    else
        //    {
        //        this.bloodBankId = bloodBankId;
        //    }
        //    if (bloodBankQuantity >= 0)
        //    {
        //        this.bloodBankQuantity = bloodBankQuantity;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Blood Bank Quantity must be greater than or equal to zero.");
        //    }
        //    this.bloodGroup = bloodGroup;
        //    this.statusOfBlood = statusOfBlood;
        //}

        //// Setters //
        //public void SetBloodBankId(int bloodBankId)
        //{
        //    if (bloodBankId <= 0)
        //    {
        //        throw new ArgumentException("Blood Bank Id must be greater than 0");
        //    }
        //    else
        //    {
        //        this.bloodBankId = bloodBankId;
        //    }
        //}
        //public void SetBloodBankQuantity(float bloodBankQuantity)
        //{
        //    if (bloodBankQuantity >= 0)
        //    {
        //        this.bloodBankQuantity = bloodBankQuantity;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Blood Bank Quantity must be greater than or equal to zero.");
        //    }
        //}
        //public void SetBloodGroups(BloodType bloodGroup)
        //{
        //    this.bloodGroup = bloodGroup;
        //}
        //public void SetBloodStatus(BloodStatus statusOfBlood)
        //{
        //    this.statusOfBlood = statusOfBlood;
        //}

        //// Getter //

        //public int GetBloodBankId()
        //{
        //    return this.bloodBankId;
        //}
        //public float GetBloodBankQuantity()
        //{
        //    return this.bloodBankQuantity;
        //}
        //public BloodType GetBloodGroups()
        //{
        //    return this.bloodGroup;
        //}
        //public BloodStatus GetBloodStatus()
        //{
        //    return this.statusOfBlood;
        //}
    }
}
