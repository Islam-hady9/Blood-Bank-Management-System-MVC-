using Blood_Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_Bank_Management_System.Data
{
    public class BloodBankDbContext : DbContext
    {
<<<<<<< HEAD
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {
           Hospitals = Set<Hospital>();
           Employees = Set<Employee>();
           BloodBanks = Set<BloodBank>();
        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        // public DbSet<Request> Requests { get; set; } 
        // public DbSet<Donor> Donors { get; set; }
=======
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Donor> Donors { get; set; }

        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {
            Hospitals = Set<Hospital>();
            Employees = Set<Employee>();
            Donors = Set<Donor>();
        }
        // public DbSet<Request> Requests { get; set; } 
        // public DbSet<BloodBank> BloodBanks { get; set; }
>>>>>>> 281406d162702d2949f6cc750904d7bbfb7de730
    }
}
