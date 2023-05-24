using Blood_Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_Bank_Management_System.Data
{
    public class BloodBankDbContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Require> Requires { get; set; }
        
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {
            Hospitals = Set<Hospital>();
            Employees = Set<Employee>();
            Donors = Set<Donor>();
            BloodBanks = Set<BloodBank>();
            Requests = Set<Request>();
            Requires = Set<Require>();
        }
    }
}