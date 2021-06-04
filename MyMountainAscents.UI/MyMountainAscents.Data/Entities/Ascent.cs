using System;
using System.ComponentModel.DataAnnotations;

namespace MyMountainAscents.Data.Entities
{
    public class Ascent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Comment { get; set; }

    }
}
