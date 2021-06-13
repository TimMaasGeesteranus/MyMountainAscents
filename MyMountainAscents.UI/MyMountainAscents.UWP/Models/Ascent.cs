using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMountainAscents.UWP.Models
{
    public class Ascent
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public Ascent(DateTime date, string comment)
            => (Date, Comment) = (date, comment);

    }
}
