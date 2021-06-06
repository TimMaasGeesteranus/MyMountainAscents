using MyMountainAscents.Data.Entities;
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
    /// <summary>
    /// Interaction logic for MountainCard.xaml
    /// </summary>
    public partial class MountainCard : UserControl
    {
        public List<Mountain> Mountains = new();
        public MountainCard()
        {
            InitializeComponent();
            Mountain m1 = new();
            Mountain m2 = new();
            m1.Name = "Test1";
            m2.Name = "Test2";
            m1.Country = "CTest1";
            m2.Country = "CTest2";
            Mountains.Add(m1);
            Mountains.Add(m2);

            mountainList.ItemsSource = Mountains;
        }

        public void GoToDetail()
        {

        }

        public void GoToOverview()
        {

        }
    }
}
