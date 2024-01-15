using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.DAL;
using Practica_Prioridades.Models;
using System.Linq.Expressions;

namespace Practica_Prioridades.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Insertar(Prioridades prioridades)
        {
            _contexto.Prioridades.Add(prioridades);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades prioridades)
        {
            _contexto.Update(prioridades);
            int modificado = _contexto.SaveChanges();
            return modificado > 0;
        }
        public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridades.Any(t => t.PrioridadId == PrioridadId);
        }
        public bool Guardar(Prioridades prioridades)
        {
            if (!Existe(prioridades.PrioridadId))
                return this.Insertar(prioridades);
            else
                return this.Modificar(prioridades);
        }
        public bool Eliminar(Prioridades prioridades)
        {
            _contexto.Entry(prioridades).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return _contexto.Prioridades.Where(t => t.PrioridadId == PrioridadId).AsNoTracking().SingleOrDefault();
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades.Where(Criterio).AsNoTracking().ToList();
        }
    }
}
