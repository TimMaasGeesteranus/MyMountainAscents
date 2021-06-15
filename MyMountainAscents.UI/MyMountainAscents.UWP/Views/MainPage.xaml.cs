using MyMountainAscents.UWP.Models;
using MyMountainAscents.UWP.Services;
using MyMountainAscents.UWP.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMountainAscents.UWP
{
    public sealed partial class MainPage : Page
    {
        public List<Mountain> Mountains;


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public MainPage()
        {
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            DataService dataService = new DataService();
            Mountains = new List<Mountain>();
            try
            {
                Mountains = await dataService.GetAllMountains();
                this.InitializeComponent();
                if (!Mountains.Any())
                    warning.Text = "No mountains (yet)";
            }
            catch (Exception f)
            {
                var test = f;
            }
        }

        private void GoToAddMountain(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(AddMountain));
        }
    }
}
