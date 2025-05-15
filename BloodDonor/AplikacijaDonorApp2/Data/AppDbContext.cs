using Microsoft.EntityFrameworkCore;
using AplikacijaDonorApp2.Models;
using System.IO;

namespace AplikacijaDonorApp2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; } // ✅ dodato

        private string _dbPath;

        public AppDbContext()
        {
            var folder = FileSystem.AppDataDirectory;
            _dbPath = Path.Combine(folder, "donors.db");

            if (File.Exists(_dbPath))
            {
                File.Delete(_dbPath);
            }
            

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={_dbPath}");
        }
    }
}
