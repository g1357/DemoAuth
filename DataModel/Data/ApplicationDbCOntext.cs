using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DayMenu> DayMenus { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Server=(localdb)\\mssqllocaldb;Database=EFDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
