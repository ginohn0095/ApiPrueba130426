using Microsoft.EntityFrameworkCore;
using ApiPrueba130426.Models;

namespace ApiPrueba130426.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Tabla1> Tabla1 { get; set; }
        public DbSet<Tabla2> Tabla2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tabla1>().HasData(
                new Tabla1
                {
                    Id = 1,
                    Nombre = "Primero",
                    Cantidad = 11,
                    Descripcion = "Descripción del primer elemento"

                },
                new Tabla1
                {
                    Id = 2,
                    Nombre = "Segundo",
                     Cantidad = 10,
                    Descripcion = "Descripción del primer elemento"
                },
                new Tabla1
                {
                    Id = 3,
                    Nombre = "Tercero",
                     Cantidad = 12,
                    Descripcion = "Descripción del primer elemento"
                });


            modelBuilder.Entity<Tabla2>().HasData(
                new Tabla2
                {
                    Id = 1,
                    Apellido = "Apellido1",
                    NumeroT = 100
                },
                new Tabla2
                {
                    Id = 2,
                    Apellido = "Apellido2",
                    NumeroT = 200
                },
                new Tabla2
                {
                    Id = 3,
                    Apellido = "Apellido3",
                    NumeroT = 300
                });

        }
       

       
    }
}

   
