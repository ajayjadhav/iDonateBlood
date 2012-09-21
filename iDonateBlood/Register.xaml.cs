using iDonateBlood.Models;
using iDonateBlood.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace iDonateBlood
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Register : iDonateBlood.Common.LayoutAwarePage
    {

        // MobileServiceCollectionView implements ICollectionView (useful for databinding to lists) and 
        // is integrated with your Mobile Service to make it easy to bind your data to the ListView
        private MobileServiceCollectionView<BloodDonors> items;

        private IMobileServiceTable<BloodDonors> bloodDonorTable = App.MobileService.GetTable<BloodDonors>();

        public Register()
        {
            this.InitializeComponent();
            //this.DataContext = new RegisterDonorViewModel();
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

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var bloodDonor = new BloodDonors { Email = "ravi.patil@itcube.net", 
                Address="6th floor, crystal corporate, ITCube, Opp Light House, Bibwewadi-Kondhava Road, Above HDFC Bank, Bibwewadi",
                City="Pune", NevenDonated=false, BloodGroup="O+ve", Country="India", DateOfBirth=new DateTime(1980, 02,01),
                FullName ="Ravindra Patil", LastDonatedOn= new DateTime(2011, 01, 01), MobileNumber="+9198542154", 
                Password="DefaultPassword#1", State="MS", TelephoneNumber="+912023564578" };

            InsertBloodDonor(bloodDonor);
        }

        private async void InsertBloodDonor(BloodDonors bloodDonor)
        {
            // This code inserts a new BloodDonor into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await bloodDonorTable.InsertAsync(bloodDonor);
            items.Add(bloodDonor);
        
            SuccessMsg.Text = "Donor Registered successfully.. ID = " + bloodDonor.Id;
        }

        private void RefreshBloodDonors()
        {
            // This code refreshes the entries in the list view be querying the BloodDonors table.
            // The query excludes completed BloodDonors
            items = bloodDonorTable
                .Where(bloodDonor => bloodDonor.NevenDonated == false)
                .ToCollectionView();
            //ListItems.ItemsSource = items;
        }

        private async void UpdateCheckedBloodDonor(BloodDonors item)
        {
            // This code takes a freshly completed BloodDonor and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await bloodDonorTable.UpdateAsync(item);
            items.Remove(item);
        }

    }

}
