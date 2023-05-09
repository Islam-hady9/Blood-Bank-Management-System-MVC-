using System.Text.RegularExpressions;

namespace Blood_Bank_Management_System.Models
{
    public class Request
    {

        public string requestID { get; set; }
        public bool requestStatus { get; set; } // accept or reject
        public float bloodQuantity { get; set; }
        public DateTime requestDate { get; set; }

        public BloodType bType { get; set; }

        // Default Constructor...
        public Request()
        {
            this.requestID = string.Empty;
            this.requestStatus = true;
            this.bloodQuantity = 500;
            this.requestDate = DateTime.Now;
            this.bType = BloodType.A;

        }
        // Argument Constructor...
        public Request(string requestID, bool requestStatus, float bloodQuantity, DateTime requestDate, BloodType bType)
        {
            if (requestID.Length == 14 && Regex.IsMatch(requestID, "^[0-9]+$"))
            {
                this.requestID = requestID;
            }
            else
            {
                throw new ArgumentException("Donor ID must be 14 characters long");
            }

            if (bloodQuantity < 5000)
            {
                this.bloodQuantity = 500;
                this.requestStatus = true;

            }
            else
            {
                this.requestStatus = false;
                throw new Exception("The request is rejected");
            }

            this.requestDate = DateTime.Now;
            this.bType = BloodType.A;

        }
        //Setters...
        public void SetRequestID(string requestID)
        {
            if (requestID.Length == 14 && Regex.IsMatch(requestID, "^[0-9]+$"))
            {
                this.requestID = requestID;
            }
            else
            {
                throw new ArgumentException("Donor ID must be 14 characters long");
            }
        }
        public void SetRequestStatus(bool requestStatus)
        {
            this.requestStatus = requestStatus;
        }
        public void SetBloodQuantity(float bloodQuantity)
        {
            if (bloodQuantity < 5000)
            {
                this.bloodQuantity = bloodQuantity;
                this.requestStatus = true;

            }
            else
            {
                this.requestStatus = false;
                throw new Exception("The request is rejected");
            }
        }
        public void SetRequestDate(DateTime requestDate)
        {
            this.requestDate = requestDate;
        }
        public void SetBloodType(BloodType bType)
        {
            this.bType = bType; ;
        }
        //Getters...
        public string GetRequestID()
        {
            return this.requestID;
        }
        public float GetBloodQuantity()
        {
            return bloodQuantity;
        }
        public DateTime GetRequestDate()
        {
            return requestDate;
        }
        public BloodType GetBloodType()
        {
            return bType;
        }
        public bool GetRequestStatus()
        {
            return requestStatus;
        }
    }
}