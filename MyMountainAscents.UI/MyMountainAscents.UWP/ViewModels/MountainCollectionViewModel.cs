using MyMountainAscents.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMountainAscents.UWP.ViewModels
{
    public class MountainCollectionViewModel
    {
        public MountainCollection MountainCollection;

        public MountainCollectionViewModel()
        {
            MountainCollection = new MountainCollection();

            SeedMountainCollection();
        }

        private void SeedMountainCollection()
        {
            MountainCollection.Mountains = new List<Mountain>();
            var m1 = new Mountain("Matterhorn", 4003, "Zwitserland");
            var m2 = new Mountain("Grossglockner", 3891, "Oostenrijk");
            MountainCollection.Mountains.Add(m1);
            MountainCollection.Mountains.Add(m2);
        }
    }
}
