using System;
using System.ComponentModel.DataAnnotations;

namespace MyMountainAscents.Data.Entities
{
    public class Ascent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Comment { get; set; }

    }
}
