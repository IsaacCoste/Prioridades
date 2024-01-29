using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.DAL;
using Practica_Prioridades.Models;
using System.Linq.Expressions;

namespace Practica_Prioridades.Services
{
    public class SistemasService
    {
        private readonly Contexto _contexto;
        public SistemasService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Sistemas sistemas)
        {
            _contexto.Sistemas.Add(sistemas);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Sistemas sistemas)
        {
            _contexto.Update(sistemas);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int SistemasId)
        {
            return await _contexto.Sistemas.AnyAsync(t => t.SistemasId == SistemasId);
        }
        public async Task<bool> Guardar(Sistemas sistemas)
        {
            if (!await Existe(sistemas.SistemasId))
                return await this.Insertar(sistemas);
            else
                return await this.Modificar(sistemas);
        }
        public async Task<bool> Eliminar(Sistemas sistemas)
        {
            _contexto.Entry(sistemas).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Sistemas?> Buscar(int SistemasId)
        {
            return await _contexto.Sistemas.Where(t => t.SistemasId == SistemasId).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> Criterio)
        {
            return await _contexto.Sistemas.Where(Criterio).AsNoTracking().ToListAsync()!;
        }
    }
}
