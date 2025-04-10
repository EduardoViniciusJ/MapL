using MapL.Models;
using Microsoft.EntityFrameworkCore;

namespace MapL.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }   
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<PorqueAprender> Porques { get; set; }
        public DbSet<OQueAprender> Oques { get; set; }
        public DbSet<ComoAprender> Comos { get; set; }
    }
}
