namespace Blood_Bank_Management_System.Models
{
    public enum BloodStatus 
    { 
        Fresh, NotFresh 
    }
    public enum BloodBankGroups
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
    public class BloodBank
    {
        // Blood Bank Data //
        private int bloodBankId;
        private float bloodBankQuantity;
        private BloodBankGroups bloodGroup;
        private BloodStatus statusOfBlood;

        // The Defult Constractor //
        public BloodBank()
        {
            this.bloodBankId = 1;
            this.bloodBankQuantity = 0.0f;
            this.bloodGroup = BloodBankGroups.A;
            this.statusOfBlood = BloodStatus.Fresh;
        }

        // The Argument Constractor //

        public BloodBank(int bloodBankId, float bloodBankQuantity, BloodBankGroups bloodGroup, BloodStatus statusOfBlood)
        {
            if (bloodBankId <= 0)
            {
                throw new ArgumentException("Blood Bank Id must be greater than 0");
            }
            else
            {
                this.bloodBankId = bloodBankId;
            }
            this.bloodBankQuantity = 0.0f;
            this.bloodGroup = bloodGroup;
            this.statusOfBlood = statusOfBlood;
        }

        // Setters //
        public void SetBloodBankId(int bloodBankId)
        {
            if (bloodBankId <= 0)
            {
                throw new ArgumentException("Blood Bank Id must be greater than 0");
            }
            else
            {
                this.bloodBankId = bloodBankId;

            }
        }
        public void SetBloodBankQuantity(float bloodBankQuantity)
        {
            this.bloodBankQuantity = bloodBankQuantity;
        }
        public void SetBloodGroups(BloodBankGroups bloodGroup)
        {
            this.bloodGroup = bloodGroup;
        }
        public void SetBloodStatus(BloodStatus statusOfBlood)
        {
            this.statusOfBlood = statusOfBlood;
        }

        // Getter //

        public int GetBloodBankId()
        {
            return this.bloodBankId;
        }
        public float GetBloodBankQuantity()
        {
            return this.bloodBankQuantity;
        }
        public BloodBankGroups GetBloodGroups()
        {
            return this.bloodGroup;

        }
        public BloodStatus GetBloodStatus()
        {
            return this.statusOfBlood;
        }

    }
}
