using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WebApplication1.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<team> teams { get; set; } = null;
        public DbSet<bank> banks { get; set; } = null;
        //public DbSet<team> teams { get; set; } = null;
        //public DbSet<team> teams { get; set; } = null;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}