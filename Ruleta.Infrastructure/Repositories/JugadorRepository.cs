using Microsoft.EntityFrameworkCore;
using Ruleta.Core.Entities;
using Ruleta.Core.Interfaces;
using Ruleta.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Infrastructure.Repositories
{
    public class JugadorRepository : IJugadorRepository
    {
        private readonly RuletaDbContext _context;

        public JugadorRepository(RuletaDbContext context)
        {
            _context = context;
        }
   
        public async Task<Jugador> GetById(int id)
        {
            return await _context.Jugadores.SingleOrDefaultAsync(v => v.Id == id);            
        }

        public void Update(Jugador jugador)
        {
            _context.Jugadores.Update(jugador);

        }
    }
}
