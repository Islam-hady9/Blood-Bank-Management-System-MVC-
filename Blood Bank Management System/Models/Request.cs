using System.Text.RegularExpressions;
namespace Blood_Bank_Management_System.Models
{
    public class Request
    {

        private int requestID { get; set; }
        private bool requestStatus { get; set; } // accept or reject
        private float requestBloodQuantity { get; set; }
        private DateTime requestDate { get; set; }
        private BloodType requestBloodType { get; set; }

        // Default Constructor...
        public Request()
        {
            this.requestID = 0;
            this.requestStatus = true;
            this.requestBloodQuantity = 500;
            this.requestDate = DateTime.Now;
            this.requestBloodType = BloodType.A;

        }
        // Argument Constructor...
        public Request(int requestID, bool requestStatus, float requestBloodQuantity, DateTime requestDate, BloodType requestBloodType)
        {
            if (requestID < 0)
            {
                throw new ArgumentException("Invalid ID");
            }
            else
            {
                this.requestID = requestID;

            }

            if (requestBloodQuantity < 5000)
            {
                this.requestBloodQuantity = 500;
                this.requestStatus = true;

            }
            else
            {
                this.requestStatus = false;
                throw new Exception("The request is rejected");
            }

            this.requestDate = DateTime.Now;
            this.requestBloodType = BloodType.A;

        }
        //Setters...
        public void SetRequestID(int requestID)
        {
            if (requestID < 0)
            {
                throw new ArgumentException("Invalid ID");
            }
            else
            {
                this.requestID = requestID;
            }
        }
        public void SetRequestStatus(bool requestStatus)
        {
            this.requestStatus = requestStatus;
        }
        public void SetBloodQuantity(float requestBloodQuantity)
        {
            if (requestBloodQuantity < 5000)
            {
                this.requestBloodQuantity = requestBloodQuantity;
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
        public void SetRequestBloodType(BloodType requestBloodType)
        {
            this.requestBloodType = requestBloodType; ;
        }
        //Getters...
        public int GetRequestID()
        {
            return this.requestID;
        }
        public float GetRequestBloodQuantity()
        {
            return requestBloodQuantity;
        }
        public DateTime GetRequestDate()
        {
            return requestDate;
        }
        public BloodType GetRequestBloodType()
        {
            return requestBloodType;
        }
        public bool GetRequestStatus()
        {
            return requestStatus;
        }
    }
}