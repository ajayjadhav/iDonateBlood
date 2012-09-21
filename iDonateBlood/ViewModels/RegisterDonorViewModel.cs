using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace iDonateBlood.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RegisterDonorViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes a new instance of the RegisterDonorViewModel class.
        /// </summary>
        public RegisterDonorViewModel()
	    {
            Countries = new List<string>();

            Countries.Add("India");

            States = new List<String>();
            States.Add("Maharashtra");
            States.Add("Andra Pradesh");
            States.Add("Karnataka");
            States.Add("Orisa");
            States.Add("Uttar Pradesh");
            States.Add("Gujarat");

            BloodGroups = new List<String>();
            BloodGroups.Add("O+ve");
            BloodGroups.Add("A+ve");
            BloodGroups.Add("B+ve");
            BloodGroups.Add("AB+ve");
            BloodGroups.Add("O-ve");
            BloodGroups.Add("A-ve");
            BloodGroups.Add("B-ve");
            BloodGroups.Add("AB-ve");
            BloodGroups.Add("BOMBAY AG");

            CityList = new List<string>();
            CityList.Add("Pune");
            CityList.Add("Mumbai");
            CityList.Add("Banglore");

            NeverDonated = false;
        }

        public IList<string> CityList { get; set; }
        public IList<String> Countries { get; set; }
        public IList<String> States { get; set; }
        public IList<String> BloodGroups { get; set; }
        public bool NeverDonated { get; set; }

        public bool IsEverDonated { 
            get
            {
                return !NeverDonated;
            }

        }

        private string _selectedCity;
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

        private string _selectedBloodGroup;
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
