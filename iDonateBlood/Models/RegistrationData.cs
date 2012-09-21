using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDonateBlood.Models
{
    public class RegistrationData
    {
        public RegistrationData()
        {

        }

        public List<String> Countries { get; set; }
        public List<String> States { get; set; }
        public List<String> BloodGroups { get; set; }
        public bool NeverDonated { get; set; }
    }
}
