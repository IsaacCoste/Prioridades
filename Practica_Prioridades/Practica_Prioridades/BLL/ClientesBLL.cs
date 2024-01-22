using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.DAL;
using Practica_Prioridades.Models;
using System.Linq.Expressions;

namespace Practica_Prioridades.BLL
{
    public class ClientesBLL
    {
        private readonly Contexto _contexto;
        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Clientes clientes)
        {
            _contexto.Clientes.Add(clientes);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes clientes)
        {
            var t = await _contexto.Clientes.FindAsync(clientes.ClienteId);
            _contexto.Entry(t!).State = EntityState.Detached;
            _contexto.Entry(clientes).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public async Task<bool> Existe(int ClienteId)
        {
            return await _contexto.Clientes.AnyAsync(t => t.ClienteId == ClienteId);
        }

        public async Task<bool> Guardar(Clientes clientes)
        {
            if (!await Existe(clientes.ClienteId))
                return await Insertar(clientes);
            else
                return await Modificar(clientes);
        }

        public async Task<bool> Eliminar(Clientes clientes)
        {
            var cantidad = await _contexto.Clientes
                .Where(p => p.ClienteId == clientes.ClienteId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
         }

        public async Task<Clientes?> Buscar(int ClienteId)
        {
            return await _contexto.Clientes
                .Where(t => t.ClienteId == ClienteId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return _contexto.Clientes
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}
