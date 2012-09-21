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
        
    }
    public class CityandBloodGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
