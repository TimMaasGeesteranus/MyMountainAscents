using MyMountainAscents.Data.Entities;
using MyMountainAscents.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyMountainAscents.WPF.UserControls
{
    public partial class MountainCard : UserControl
    {
        public List<Mountain> Mountains = new();


        public MountainCard()
        {
            InitializeComponent();

            FillMountainsHardcoded();

            mountainList.ItemsSource = Mountains;
        }

        public void FillMountainsHardcoded()
        {
            Mountain m1 = new();
            Mountain m2 = new();
            m1.Name = "Test1";
            m2.Name = "Test2";
            m1.Country = "CTest1";
            m2.Country = "CTest2";
            Mountains.Add(m1);
            Mountains.Add(m2);
        }

        public async void AddMountainsFromAPI(object sende, RoutedEventArgs e)
        {
            Mountains.AddRange(await GetAllMountains());
            Mountains.Add(new Mountain());
            mountainList.ItemsSource = Mountains;
        }


        public async Task<List<Mountain>> GetAllMountains()
        {
            try
            {
                using HttpClient httpClient = new();
                using var response = await httpClient.GetAsync("https://localhost:44341/api/mountain");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Mountain>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                return null;
            }
        }

        public void GoToDetail()
        {

        }

        public void GoToOverview()
        {

        }
    }
}
