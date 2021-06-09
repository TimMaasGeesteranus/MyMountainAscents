using MyMountainAscents.UWP.Models;
using System.Collections.Generic;

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
            var list = new List<Mountain>
            {
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk"),
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk"),                           
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk"),                           
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk"),                           
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk"),                           
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk"),                           
                new Mountain("Matterhorn", 4003, "Zwitserland"),
                new Mountain("Grossglockner", 3891, "Oostenrijk")
            };
            MountainCollection.Mountains.AddRange(list);
        }
    }
}
