using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace iDonateBlood.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RegisterDonorViewModel : ViewModelBase
    {
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

            NeverDonated = false;
        }    


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

    }
}
