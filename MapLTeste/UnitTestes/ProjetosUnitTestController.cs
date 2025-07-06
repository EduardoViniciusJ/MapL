using AutoMapper;
using MapL.Context;
using MapL.DTOs;
using MapL.Repositories;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLTeste.UnitTestes
{
    public class ProjetosUnitTestController
    {
        public IUnitOfWork repository;   
        public IMapper mapper;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString =
            "Server=DESKTOP-ONTE7RU;Database=MapDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";

        // Configuração do DbContextOptions 
        static ProjetosUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;  
        }

        public ProjetosUnitTestController()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SolutionDTOMappingProfile());
            });

            // Instância dos DTOs 
            mapper = config.CreateMapper();

            // Instância do banco de dados. 
            var context = new AppDbContext(dbContextOptions);

            // Instância do UnitOfWork
            repository = new UnitOfWork(context);
        }
    }
}
