using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Models
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
                
        }
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<Color> Colors  { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Quatation> Quatations { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleAccessories> VehicleAccessories { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


    }
}
