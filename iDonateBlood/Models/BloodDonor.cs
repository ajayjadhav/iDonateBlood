using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iDonateBlood.Models
{
    public class BloodDonor
    {
        public int Id { get; set; }

        [DataMember(Name = "email", IsRequired=true)]
        public string Email { get; set; }

        [DataMember(Name = "fullname", IsRequired = true)]
        public string FullName { get; set; }

        [DataMember(Name = "dob", IsRequired = true)]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Name = "gender", IsRequired = true)]
        public string Gender { get; set; }

        [DataMember(Name = "bloodgroup", IsRequired = true)]
        public string BloodGroup { get; set; }

        [DataMember(Name = "lastdonatedon", IsRequired = false)]
        public DateTime? LastDonatedOn { get; set; }

        [DataMember(Name = "mobileno", IsRequired = true)]
        public string MobileNumber { get; set; }

        [DataMember(Name = "telephoneno", IsRequired = false)]
        public string TelephoneNumber { get; set; }

        [DataMember(Name = "address", IsRequired = true)]
        public string Address { get; set; }

        [DataMember(Name = "country", IsRequired = true)]
        public string Country { get; set; }

        [DataMember(Name = "state", IsRequired = true)]
        public string State { get; set; }

        [DataMember(Name = "city", IsRequired = true)]
        public string City { get; set; }

        public string FullAddress
        {
            get { return Address+", "+City+", "+State+", "+Country; }
        }
        

    }
}
