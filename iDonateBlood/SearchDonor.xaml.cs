﻿using iDonateBlood.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iDonateBlood
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchDonor : Page
    {
        public SearchDonor()
        {
            this.InitializeComponent();
            //test
            this.DataContext = new CityandBloodGroup();
            //donnerList.ItemsSource = App.MobileService.GetTable<BloodDonors>();
            IMobileServiceTable<BloodDonors> donorTableList= App.MobileService.GetTable<BloodDonors>();
            MobileServiceCollectionView<BloodDonors> items = donorTableList.ToCollectionView();
            var asdsad = items.Take(1);
            donorList.ItemsSource = items;
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var city = cbCity.SelectedItem;
        }
    }
}
