using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.DAL;
using Practica_Prioridades.Migrations;
using Practica_Prioridades.Models;
using System.Linq.Expressions;

namespace Practica_Prioridades.Services
{
    public class PrioridadesService
    {
        private readonly Contexto _contexto;
        public PrioridadesService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Prioridades prioridades)
        {
            _contexto.Prioridades.Add(prioridades);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Prioridades prioridades)
        {
            _contexto.Update(prioridades);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int PrioridadId)
        {
            return await _contexto.Prioridades.AnyAsync(t => t.PrioridadId == PrioridadId);
        }
        public async Task<bool> Guardar(Prioridades prioridades)
        {
            if (!await Existe(prioridades.PrioridadId))
                return await this.Insertar(prioridades);
            else
                return await this.Modificar(prioridades);
        }
        public async Task<bool> Eliminar(Prioridades prioridades)
        {
            _contexto.Entry(prioridades).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Prioridades?> Buscar(int PrioridadId)
        {
            return await _contexto.Prioridades.Where(t => t.PrioridadId == PrioridadId).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return await _contexto.Prioridades.Where(Criterio).AsNoTracking().ToListAsync()!;
        }
    }
}
