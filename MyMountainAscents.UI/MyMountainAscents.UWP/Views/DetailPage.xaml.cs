using MyMountainAscents.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMountainAscents.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        Mountain Mountain;
        public static byte[] Image;
        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Mountain = (Mountain)e.Parameter;
            Image = Mountain.Image;
            SetMountainValues();
            base.OnNavigatedTo(e);
        }

        private void SetMountainValues()
        {
            name.Text = Mountain.Name;
            country.Text = Mountain.Country;
            height.Text = Mountain.Height.ToString();
            ascents.Text = Mountain.Ascents?.Count.ToString() ?? "0";
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(MainPage));
        }

        public static ImageSource GetImg()
        {
            BitmapImage image = new BitmapImage();
            InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream();
            ms.AsStreamForWrite().Write(Image, 0, Image.Length);
            ms.Seek(0);

            image.SetSource(ms);
            ImageSource src = image;

            return src;
        }
    }
}
