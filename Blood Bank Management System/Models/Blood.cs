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
            this.bloodID = bloodID;
            this.bloodType = bloodType;
            this.bloodQuantity = bloodQuantity;
        }

        //Setters
        public void SetBloodID(int bloodID)
        {
            this.bloodID = bloodID;
        }
        public void SetBloodType(BloodType bloodType)
        {
            this.bloodType = bloodType;
        }
        public void SetBloodQuantity()
        {
            this.bloodQuantity = bloodQuantity;
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
