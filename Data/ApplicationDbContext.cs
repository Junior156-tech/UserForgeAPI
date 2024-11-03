using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserForgeAPI.Models;

namespace UserForgeAPI.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

    }

}