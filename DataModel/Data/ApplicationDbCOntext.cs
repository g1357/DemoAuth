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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            options.UseSqlServer(
                Microsoft.Extensions.Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
