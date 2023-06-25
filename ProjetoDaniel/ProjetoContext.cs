using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDaniel
{
    public class ProjetoContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projetodan;Trusted_Connection=true;");
        }
    }

}
