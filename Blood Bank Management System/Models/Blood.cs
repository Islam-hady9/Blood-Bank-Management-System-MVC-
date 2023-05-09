namespace Blood_Bank_Management_System.Models
{
    public class Blood
    {
        // Data Members
        private int bloodID;
        private BloodType bloodType;
        private float bloodQuantity;

        // Default Constructor
        public Blood()
        {
            this.bloodID = 1;
            this.bloodType = BloodType.A;
            this.bloodQuantity = 0.0f;
        }

        // Argument Constructor
        public Blood(int bloodID, BloodType bloodType, float bloodQuantity)
        {
            if (bloodID > 0)
            {
                this.bloodID = bloodID;
            }
            else
            {
                throw new ArgumentException("Blood ID must be greater than 0");
            }
            this.bloodType = bloodType;
            if (bloodQuantity >= 0.0f)
            {
                this.bloodQuantity = bloodQuantity;
            }
            else
            {
                throw new ArgumentException("Blood Quantity must be greater than or equal to 0");
            }
        }

        //Setters
        public void SetBloodID(int bloodID)
        {
            if (bloodID > 0)
            {
                this.bloodID = bloodID;
            }
            else
            {
                throw new ArgumentException("Blood ID must be greater than 0");
            }
        }
        public void SetBloodType(BloodType bloodType)
        {
            this.bloodType = bloodType;
        }
        public void SetBloodQuantity(float bloodQuantity)
        {
            if (bloodQuantity >= 0.0f)
            {
                this.bloodQuantity = bloodQuantity;
            }
            else
            {
                throw new ArgumentException("Blood Quantity must be greater than or equal to 0");
            }
        }

        //Getter
        public int GetBloodID()
        {
            return this.bloodID;
        }
        public BloodType GetBloodType()
        {
            return this.bloodType;
        }
        public float GetBloodQuantity()
        {
            return this.bloodQuantity;
        }
    }
}