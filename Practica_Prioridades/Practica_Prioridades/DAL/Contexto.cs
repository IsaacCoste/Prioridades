using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.Models;

namespace Practica_Prioridades.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
