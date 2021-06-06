using MyMountainAscents.Data.Entities;
using MyMountainAscents.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MyMountainAscents.WPF.UserControls
{
    public partial class MountainCard : UserControl
    {
        public List<Mountain> Mountains = new();

        public MountainCard()
        {
            InitializeComponent();

            FillMountainsHardcoded();
            //FillMountainsAPI();

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

        public async void FillMountainsAPI()
        {
           // Mountains = await DataService.GetAllMountains();
        }

        public void GoToDetail()
        {

        }

        public void GoToOverview()
        {

        }
    }
}
