using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.DAL;
using Practica_Prioridades.Models;
using System.Linq.Expressions;

namespace Practica_Prioridades.Services
{
    public class TicketsService
    {
        private readonly Contexto _contexto;
        public TicketsService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Tickets tickets)
        {
            _contexto.Tickets.Add(tickets);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Tickets tickets)
        {
            _contexto.Update(tickets);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int TicketId)
        {
            return await _contexto.Tickets.AnyAsync(t => t.TicketId == TicketId);
        }
        public async Task<bool> Guardar(Tickets tickets)
        {
            if (!await Existe(tickets.TicketId))
                return await this.Insertar(tickets);
            else
                return await this.Modificar(tickets);
        }
        public async Task<bool> Eliminar(Tickets tickets)
        {
            _contexto.Entry(tickets).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Tickets?> Buscar(int TicketId)
        {
            return await _contexto.Tickets.Where(t => t.TicketId == TicketId).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> Criterio)
        {
            return await _contexto.Tickets.Where(Criterio).AsNoTracking().ToListAsync()!;
        }
    }
}
