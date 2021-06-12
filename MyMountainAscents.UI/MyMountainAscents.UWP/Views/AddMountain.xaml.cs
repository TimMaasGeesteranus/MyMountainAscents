using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace MyMountainAscents.UWP.Views
{
    public sealed partial class AddMountain : Page
    {
        public AddMountain()
        {
            this.InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
        }
    }
}
