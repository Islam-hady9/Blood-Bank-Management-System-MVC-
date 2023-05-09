using System.Text.RegularExpressions;

namespace Blood_Bank_Management_System.Models
{
    public class Hospital
    {
        public string hospitalName;
        public int hospitalId;
        public string hospitalEmail;
        public string hospitalLocation;
        public string hospitalPhone;
        public int receivedUnits;
        public DateTime DateOfAcception;

        public Hospital(string hospitalName, int hospitalId, string hospitalEmail, string hospitalLocation, string hospitalPhone, int receivedUnits, DateTime DateOfAcception)
        {
            this.hospitalName = hospitalName;
            this.hospitalEmail = hospitalEmail;
            this.hospitalId = hospitalId;
            this.hospitalLocation = hospitalLocation;
            this.hospitalPhone = hospitalPhone;
            this.receivedUnits = receivedUnits;
            this.DateOfAcception = DateOfAcception;
        }

        public Hospital()
        {
            this.hospitalName = string.Empty;
            this.hospitalEmail = string.Empty;
            this.hospitalId = 1;
            this.hospitalLocation = string.Empty;
            this.hospitalPhone = string.Empty;
            this.receivedUnits = 1;
            this.DateOfAcception = DateTime.Now;
        }
        //setter and getter for hospital name
        public void SetHospitalName(string hospitalName)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9\s\-.,()']{1,100}$");
            Match match = regex.Match(hospitalName);
            if (match.Success)
                this.hospitalName = hospitalName;
            else
                Console.Write(hospitalName + " is incorrect");
        }
        public string GetHospitalName()
        {
            return this.hospitalName;
        }

        //setter and getter for hospital email
        public void SetHospitalEmail(string hospitalEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(hospitalEmail);
            if (match.Success)
                this.hospitalEmail = hospitalEmail;
            else
                Console.Write(hospitalEmail + " is incorrect");
        }
        public string GetHospitalEmail()
        {
            return this.hospitalEmail;
        }

        //setter and getter for hospital id
        public void SetHospitalId(int hospitalId)
        {
            if (hospitalId != 0)
                this.hospitalId = hospitalId;
            else
                Console.Write(hospitalId + " is incorrect");
        }
        public int GetHospitalId()
        {
            return this.hospitalId;
        }

        //setter and getter for hospital location 
        public void SetHospitalLocation(string hospitalLocation)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9\s\-.,()']{1,100}$");
            Match match = regex.Match(hospitalLocation);
            if (match.Success)
                this.hospitalLocation = hospitalLocation;
            else
                Console.Write(hospitalLocation + " is incorrect");
        }
        public string GetHospitalLocation()
        {
            return this.hospitalLocation;
        }

        //setter and getter for hospital phone
        public void SetHospitalPhone(string hospitalPhone)
        {
            Regex regex = new Regex(@"^01[0-2]\d{1,8}$");
            Match match = regex.Match(hospitalPhone);
            if (match.Success)
                this.hospitalPhone = hospitalPhone;
            else
                Console.Write(hospitalPhone + " is incorrect");
        }
        public string GetHospitalPhone()
        {
            return this.hospitalPhone;
        }

        //setter and getter for receive units
        public void SetReceiveUnits(int receiveUnit)
        {
            if (receiveUnit != 0)
                this.receivedUnits = receiveUnit;
            else
                Console.Write(receiveUnit + " is incorrect");
        }
        public int GetReceiveUnits()
        {
            return this.receivedUnits;
        }

        //setter and getter for date of acception
        public void SetDateOfAcception(DateTime DateOfAcception)
        {
            if (DateOfAcception >= DateTime.Now)
                this.DateOfAcception = DateOfAcception;
            else
                Console.Write(DateOfAcception + " is incorrect");
        }
        public DateTime GetDateOfAcception()
        {
            return this.DateOfAcception;
        }

    }
}