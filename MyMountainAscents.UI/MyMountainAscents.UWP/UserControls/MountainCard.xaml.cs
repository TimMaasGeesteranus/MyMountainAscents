using MyMountainAscents.UWP.ViewModels;
using Windows.UI.Xaml.Controls;


namespace MyMountainAscents.UWP.UserControls
{
    public sealed partial class MountainCard : UserControl
    {
        public MountainCollectionViewModel Mountains { get; set; }

        public MountainCard()
        {
            this.InitializeComponent();
            Mountains = new MountainCollectionViewModel();

        }
    }
}
