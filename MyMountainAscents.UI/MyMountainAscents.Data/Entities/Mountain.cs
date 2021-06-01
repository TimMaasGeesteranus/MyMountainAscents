using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMountainAscents.Data.Entities
{
    public class Mountain
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Height { get; set; }
        [Required]
        public string Country { get; set; }
        public byte[] Image { get; set; }
        public List<Ascent> Ascents { get; set; }
    }
}
