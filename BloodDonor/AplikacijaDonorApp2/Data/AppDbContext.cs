using Microsoft.EntityFrameworkCore;
using AplikacijaDonorApp2.Models;
using System.IO;

namespace AplikacijaDonorApp2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Donor> Donors { get; set; }

        private string _dbPath;

        public AppDbContext()
        {
            var folder = FileSystem.AppDataDirectory;
            _dbPath = Path.Combine(folder, "donors.db");
            Database.EnsureCreated(); // automatski kreira bazu ako ne postoji
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={_dbPath}");
        }
    }
}
