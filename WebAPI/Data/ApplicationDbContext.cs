using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
