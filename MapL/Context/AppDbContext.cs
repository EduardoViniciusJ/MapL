using MapL.Models;
using Microsoft.EntityFrameworkCore;

namespace MapL.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }   
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Motivacao> Motivacoes { get; set; }
        public DbSet<Conhecimento> Conhecimentos { get; set; }
        public DbSet<Estrategia> Estrategias { get; set; }
    }
}
