using System.Text.RegularExpressions;

namespace Blood_Bank_Management_System.Models
{
    public enum Gender { Male, Female }
    public enum BloodType {
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
        private string donorName;
        private string donorID;
        private string donorPhone;
        private string donorAddress;
        private int donorAge;
        private Gender donorGender;
        private BloodType donorBloodType;
        private DateTime lastDonationDate;

        // Default Constructor...
        public Donor() 
        {
            this.donorName = string.Empty;
            this.donorID = string.Empty;
            this.donorPhone = string.Empty;
            this.donorAddress = string.Empty;
            this.donorAge = 18;
            this.donorGender = Gender.Male;
            this.donorBloodType = BloodType.A;
            this.lastDonationDate = DateTime.Now;
        }

        // Argument Constructor...
        public Donor(string donorName, string donorID, string donorPhone, string donorAddress, int donorAge, Gender donorGender, BloodType donorBloodType, DateTime lastDonationDate)
        {
            this.donorName= donorName;
            if (donorID.Length == 14 && Regex.IsMatch(donorID, "^[0-9]+$"))
            {
                this.donorID = donorID;
            }
            else
            {
                throw new ArgumentException("Donor ID must be 14 characters long");
            }
            if (donorPhone.Length == 11 && Regex.IsMatch(donorPhone, "^[0-9]+$") && donorPhone[0] == '0')
            {
                this.donorPhone = donorPhone;
            }
            else
            {
                throw new ArgumentException("Donor Phone must be 11 characters long");
            }
            this.donorAddress = donorAddress;
            if (donorAge >= 18 && donorAge < 60)
            {
                this.donorAge = donorAge;
            }
            else
            {
                throw new ArgumentException("Donor Age must be between 18 and 60");
            }
            this.donorGender = donorGender;
            this.donorBloodType = donorBloodType;
            this.lastDonationDate = lastDonationDate;
        }

        //Setters...
        public void SetDonorName(string donorName)
        {
            this.donorName = donorName;
        }
        public void SetDonorID(string donorID)
        {
            if (donorID.Length == 14 && Regex.IsMatch(donorID, "^[0-9]+$"))
            {
                this.donorID = donorID;
            }
            else
            {
                throw new ArgumentException("Donor ID must be 14 characters long");
            }
        }
        public void SetDonorPhone(string donorPhone) 
        {
            if (donorPhone.Length == 11 && Regex.IsMatch(donorPhone, "^[0-9]+$") && donorPhone[0] == '0')
            {
                this.donorPhone = donorPhone;
            }
            else
            {
                throw new ArgumentException("Donor Phone must be 11 characters long");
            }
        }
        public void SetDonorAddress(string donorAddress)
        {
            this.donorAddress = donorAddress;
        }
        public void SetDonorAge(int donorAge) 
        {
            if (donorAge >= 18 && donorAge < 60)
            {
                this.donorAge = donorAge;
            }
            else
            {
                throw new ArgumentException("Donor Age must be between 18 and 60");
            }
        }
        public void SetDonorGender(Gender donorGender)
        {
            this.donorGender = donorGender;
        }
        public void SetDonorBloodType(BloodType donorBloodType)
        {
            this.donorBloodType = donorBloodType;
        }
        public void SetLastDonationDate(DateTime lastDonationDate) 
        {
            this.lastDonationDate = lastDonationDate;
        }

        //Getter...
        public string GetDonorName()
        {
            return this.donorName;
        }
        public string GetDonorID()
        {
            return this.donorID;
        }
        public string GetDonorPhone() 
        {
            return this.donorPhone;
        }
        public string GetDonorAddress() 
        {
            return this.donorAddress;
        }
        public int GetDonorAge() 
        {
            return this.donorAge;
        }
        public Gender GetDonorGender() 
        {
            return this.donorGender;
        }
        public BloodType GetDonorBloodType() 
        {
            return this.donorBloodType;
        }
        public DateTime GetLastDonationDate()
        {
            return this.lastDonationDate;
        }
    }
}