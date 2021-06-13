using MyMountainAscents.UWP.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMountainAscents.UWP.Views
{
    public sealed partial class AddAscent : Page
    {
        public Mountain Mountain;

        public AddAscent()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Mountain = (Mountain)e.Parameter;
            base.OnNavigatedTo(e);
        }
    }
}
