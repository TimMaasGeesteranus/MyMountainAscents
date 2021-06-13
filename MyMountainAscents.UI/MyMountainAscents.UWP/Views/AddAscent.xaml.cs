using MyMountainAscents.UWP.Models;
using MyMountainAscents.UWP.Services;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMountainAscents.UWP.Views
{
    public sealed partial class AddAscent : Page
    {
        public Mountain Mountain;
        public DateTimeOffset Date;
        public string Comment;

        public AddAscent()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Mountain = (Mountain)e.Parameter;
            base.OnNavigatedTo(e);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
        }

        private async void Submit(object sender, RoutedEventArgs e)
        {
            Comment = comment.Text;
            Date = date.Date;

            if (InputValid())
            {
                await AddAscentToAPI();
            }
            else
                Warning.Text = "Input not valid, try again";
        }

        private bool InputValid()
        {
            if (Comment == null || Date == null)
                return false;
            return true;
        }

        private async Task AddAscentToAPI()
        {
            DataService dataService = new DataService();
            Ascent ascent = new Ascent(Date.DateTime, Comment);
            await dataService.AddAscent(ascent, Mountain.Id);
        }
    }
}
