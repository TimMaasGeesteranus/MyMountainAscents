using Microsoft.EntityFrameworkCore;
using MyMountainAscents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.API.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<Ascent> Ascents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
