using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.Models;

namespace Practica_Prioridades.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options){ }
        public DbSet<Prioridades> Prioridades { get; set; }
    }
}
