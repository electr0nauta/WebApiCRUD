using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPortfolio.Entidades;

namespace WebApiPortfolio
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores{ get; set; }
        public DbSet<Libro> Libros { get; set; }//coloco explicitamente el dbset libros para poder realizar querys especificamente en la tabla libros
    }
}
