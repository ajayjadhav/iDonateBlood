using iDonateBlood.Models;
using iDonateBlood.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
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
    public sealed partial class SearchDonorDetails : iDonateBlood.Common.LayoutAwarePage
    {
        private IMobileServiceTable<BloodDonors> donorTableList = App.MobileService.GetTable<BloodDonors>();
        private MobileServiceCollectionView<BloodDonors> items;
        public SearchDonorDetails()
        {
            this.InitializeComponent();
            this.DataContext = new RegisterDonorViewModel();
            //donnerList.ItemsSource = App.MobileService.GetTable<BloodDonors>();
            items = donorTableList.ToCollectionView();
            donorList.ItemsSource = items;
        }

        private void  Search_Click(object sender, RoutedEventArgs e)
        {
             IMobileServiceTable<BloodDonors> donorTableList = App.MobileService.GetTable<BloodDonors>();

            var city =  cbCity.SelectedValue != null ? cbCity.SelectedValue.ToString() : "";
            var bloodGroup = cbBloodGroup.SelectedValue != null ? cbBloodGroup.SelectedValue.ToString() : "";
            MobileServiceCollectionView<BloodDonors> searchList;
            if (cbCity.SelectedValue != null && cbBloodGroup.SelectedValue != null && items != null)
            {
                 searchList = (from d in donorTableList
                               where d.City == city  && d.BloodGroup == Uri.EscapeDataString(bloodGroup)
                               select d).ToCollectionView();

            }
            else if (cbCity.SelectedValue != null && cbBloodGroup.SelectedValue == null && items != null)
            {
                 searchList = donorTableList
                    .Where(d => d.City == city)
                    .ToCollectionView();
            }
            else
            {
                 searchList = donorTableList
                    .Where(d => d.BloodGroup == Uri.EscapeDataString(bloodGroup))
                    .ToCollectionView();
            }

            donorList.ItemsSource = null;
             donorList.ItemsSource = searchList;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register));
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
}
