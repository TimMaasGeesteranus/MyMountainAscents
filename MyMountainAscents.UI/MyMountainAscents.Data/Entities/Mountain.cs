using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMountainAscents.Data.Entities
{
    public class Mountain
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Height { get; set; }
        [Required]
        public string Country { get; set; }

        public List<Ascent> Ascents { get; set; }
    }
}
