using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAzure.MobileServices;
using iDonateBlood.Models;

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
        // MobileServiceCollectionView implements ICollectionView (useful for databinding to lists) and 
        // is integrated with your Mobile Service to make it easy to bind your data to the ListView
        private MobileServiceCollectionView<BloodDonor> donors;

        private IMobileServiceTable<BloodDonor> bloodDonorTable = App.MobileService.GetTable<BloodDonor>();

        private RelayCommand registerCommand;

        public RelayCommand RegisterCommand
        {
            get
            {
                if (registerCommand == null) registerCommand =
                    new RelayCommand(RegisterDonor);
                return registerCommand;
            }
            private set { registerCommand = value; }
        }

        private void RegisterDonor()
        {
            //var bloodDonor = new BloodDonor
            //{
            //    Email = Email,
            //    Address = Address,
            //    City = City,
            //    Gender = SelectedGender,
            //    BloodGroup = SelectedBloodGroup,
            //    Country = SelectedCountry,
            //    DateOfBirth = DateOfBirth,
            //    FullName = FullName,
            //    LastDonatedOn = LastDonatedOn,
            //    MobileNumber = MobileNumber,
            //    State = SelectedCountry,
            //    TelephoneNumber = TelephoneNumber
            //};

            var bloodDonor = new BloodDonor
            {
                Email = "vijay@itcube.net",
                Address = "606, b3, anita residency, Bibwewadi-Kondhava road",
                City = "Pune",
                Gender = "Male",
                BloodGroup = "AB-ve",
                Country = "India",
                DateOfBirth = new DateTime(1980, 01, 01),
                FullName = "Ajay Jadhav",
                LastDonatedOn = new DateTime(2011,01,01),
                MobileNumber = "9881727525",
                State = "MS"
                //TelephoneNumber = ""
            };

            InsertBloodDonor(bloodDonor);
        }

        private async void InsertBloodDonor(BloodDonor bloodDonor)
        {
            // This code inserts a new BloodDonor into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await bloodDonorTable.InsertAsync(bloodDonor);
            //donors.Add(bloodDonor);

            if (bloodDonor.Id > 0)
            {
                NavigateToSearch("success");
            }
            else
            {
                NavigateToSearch("failure");
            }
            //SuccessMsg.Text = "Donor Registered successfully.. ID = " + bloodDonor.Id;
        }

        private void RefreshBloodDonors()
        {
            // This code refreshes the entries in the list view be querying the BloodDonors table.
            // The query excludes completed BloodDonors
            donors = bloodDonorTable
                //.Where(bloodDonor => bloodDonor.NevenDonated == false)
                .ToCollectionView();
        }

        private void NavigateToSearch(string successOrFailure)
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<string>(successOrFailure);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes a new instance of the RegisterDonorViewModel class.
        /// </summary>
        public RegisterDonorViewModel()
	    {
            FullName = App.LoginName;
            SelectedGender = App.Gender;

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

            GenderList = new List<String>();
            GenderList.Add("Male");
            GenderList.Add("Female");

            NeverDonated = false;
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string SelectedGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public DateTime LastDonatedOn { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public string SelectedCountry { get; set; }
        public string SelectedState { get; set; }

        public string City { get; set; }

        public IList<String> GenderList { get; set; }
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
