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
        public DbSet<Motivacao> Porques { get; set; }
        public DbSet<Conhecimento> Oques { get; set; }
        public DbSet<Estrategia> Comos { get; set; }
    }
}
