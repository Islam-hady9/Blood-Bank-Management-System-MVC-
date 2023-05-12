using System.ComponentModel.DataAnnotations;
namespace Blood_Bank_Management_System.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public bool RequestStatus { get; set; } // accept or reject
        public float RequestBloodQuantity { get; set; }
        public DateTime RequestDate { get; set; }
        public BloodType RequestBloodType { get; set; }
        public Hospital HospitalToRequestFrom { get; set; }

        // Default Constructor...
        public Request()
        {
            this.RequestID = 1;
            this.RequestStatus = true;
            this.RequestBloodQuantity = 5000;
            this.RequestDate = DateTime.Now;
            this.RequestBloodType = BloodType.A;
            this.HospitalToRequestFrom = new Hospital();
        }
        // Argument Constructor...
        //public Request(int requestID, float requestBloodQuantity, DateTime requestDate, BloodType requestBloodType, Hospital HospitalToRequestFrom)
        //{
        //    if (requestID > 0)
        //    {
        //        this.requestID = requestID;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Invalid ID");
        //    }

        //    if (requestBloodQuantity <= 5000.0f && requestBloodQuantity > 0.0f)
        //    {
        //        this.requestBloodQuantity = 5000.0f;
        //        this.requestStatus = true;
        //    }
        //    else
        //    {
        //        this.requestStatus = false;
        //        throw new Exception("The request is rejected");
        //    }
        //    this.requestDate = DateTime.Now;
        //    this.requestBloodType = BloodType.A;
        //    this.HospitalToRequestFrom = HospitalToRequestFrom;
        //}
        ////Setters...
        //public void SetRequestID(int requestID)
        //{
        //    if (requestID > 0)
        //    {
        //        this.requestID = requestID;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Invalid ID");
        //    }
        //}
        //public void SetRequestStatus(bool requestStatus)
        //{
        //    this.requestStatus = requestStatus;
        //}
        //public void SetRequestBloodQuantity(float requestBloodQuantity)
        //{
        //    if (requestBloodQuantity <= 5000.0f && requestBloodQuantity > 0.0f)
        //    {
        //        this.requestBloodQuantity = requestBloodQuantity;
        //        this.requestStatus = true;
        //    }
        //    else
        //    {
        //        this.requestStatus = false;
        //        throw new Exception("The request is rejected");
        //    }
        //}
        //public void SetRequestDate(DateTime requestDate)
        //{
        //    this.requestDate = requestDate;
        //}
        //public void SetRequestBloodType(BloodType requestBloodType)
        //{
        //    this.requestBloodType = requestBloodType; ;
        //}
        ////Getters...
        //public int GetRequestID()
        //{
        //    return this.requestID;
        //}
        //public float GetRequestBloodQuantity()
        //{
        //    return this.requestBloodQuantity;
        //}
        //public DateTime GetRequestDate()
        //{
        //    return this.requestDate;
        //}
        //public BloodType GetRequestBloodType()
        //{
        //    return this.requestBloodType;
        //}
        //public bool GetRequestStatus()
        //{
        //    return this.requestStatus;
        //}
    }
}