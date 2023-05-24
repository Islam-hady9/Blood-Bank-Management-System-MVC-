//using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Bank_Management_System.Models
{
    //[PrimaryKey(nameof(RequestID), nameof(HospitalId))]
    public class Require
    {
        [Key]
        public int HospitalId { get; set; }
        public int RequestID { get; set; }

        // Declare the two properties as nullable
        // by adding a question mark after its type:
        [ForeignKey("HospitalId")]
        public Hospital? Hospital { get; set; }

        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
    }
}
