using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace iDonateBlood
{
    public class Donor
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public Nullable<DateTime> LastDonatedOn { get; set; }
        public Int64 MobileNumber { get; set; }
        //public string FullAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
    public class CityandBloodGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /*-----------------------DonorList---------------------------*/
        private List<Donor> _donorList =
            new List<Donor>() { new Donor() { FullName = "Andy Smirnov1", 
                                              Address = "asasd, asdasd, asd, ahjsdfhjasdjfgbasdgbf", 
                                              City = "Pune", 
                                              Country = "India", 
                                              State = "MH",
                                              Email = "andy_smirnov@hotmail.com", 
                                              LastDonatedOn = null, 
                                              MobileNumber = 9865962569 },
                               new Donor() { FullName = "Andy Smirnov2", 
                                              Address = "asasd,asdasd,asd,", 
                                              City = "Pune", 
                                              Country = "India", 
                                              State = "MH", 
                                              Email = "andy_smirnov@hotmail.com", 
                                              LastDonatedOn = null, 
                                              MobileNumber = 9865962569 },
                               new Donor() { FullName = "Andy Smirnov3", 
                                              Address = "asasd,asdasd,asd,", 
                                              City = "Pune", 
                                              Country = "India", 
                                              State = "MH", 
                                              Email = "andy_smirnov@hotmail.com", 
                                              LastDonatedOn = null, 
                                              MobileNumber = 9865962569 }
                             };

        public List<Donor> DonorList
        {
            get { return _donorList; }
        }
        /*---------------City List----------------------*/
        private IEnumerable<string> _cityList = new List<string>
        {
            "Pune",
            "Mumbai",
            "Banglore"
        };
        public IEnumerable<string> CityList
        {
            get { return _cityList; }
        }

        private string _selectedCity = "Pune";
        public string SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedCity"));
                }
            }
        }

        /*---------------Blood Group----------------------*/
        private IEnumerable<string> _bloodGroupList = new List<string>
        {
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"

        };
        public IEnumerable<string> BloodGroupList
        {
            get { return _bloodGroupList; }
        }

        private string _selectedBloodGroup = "B+";
        public string SelectedBloodGroup
        {
            get { return _selectedBloodGroup; }
            set
            {
                _selectedBloodGroup = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedBloodGroup"));
                }
            }
        }
    }


}
