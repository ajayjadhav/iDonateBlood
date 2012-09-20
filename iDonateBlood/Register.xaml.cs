using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace iDonateBlood
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Register : iDonateBlood.Common.LayoutAwarePage
    {
        public Register()
        {
            this.InitializeComponent();
            this.DataContext = new RegistrationData();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

    }

    public class RegistrationData
    {
        public RegistrationData()
        {
            Countries = new List<string>();

            Countries.Add("India");
            //Countries.Add("United States");
            //Countries.Add("United Kingdom");

            States = new List<String>();
            States.Add("Maharashtra");
            States.Add("Andra Pradesh");
            States.Add("Karnataka");
            States.Add("Orisa");
            States.Add("Uttar Pradesh");
            States.Add("Gujrat");

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

        public List<String> Countries { get; set; }
        public List<String> States { get; set; }
        public List<String> BloodGroups { get; set; }
        public bool NeverDonated { get; set; }
    }
}
