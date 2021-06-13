using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyMountainAscents.UWP.Views
{
    public sealed partial class AddMountain : Page
    {
        public string MountainName { get; set; }
        public string MountainCountry { get; set; }
        public int MountainHeight { get; set; }
        public byte[] MountainImage { get; set; }

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

        private async void AddImage(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                await ImageToBytes(file);
                uploadButton.Content = "Uploaded";
            }
            else
            {
            }

        }

        private async Task ImageToBytes(StorageFile image)
        {
            var stream = await image.OpenStreamForReadAsync();
            var bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            MountainImage = bytes;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            MountainName = mountainName.Text;
            MountainCountry = mountainCountry.Text;
            MountainHeight = Int32.Parse(mountainHeight.Text);

            if (InputValid())
                AddMountainToAPI();
            else
                Warning.Text = "Input not valid, try again";
        }

        private bool InputValid()
        {
            if (MountainCountry == null || MountainName == null || MountainImage == null)
                return false;
            return true;
        }

        private void AddMountainToAPI()
        {

        }
    }
}
