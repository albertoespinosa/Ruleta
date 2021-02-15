using Microsoft.EntityFrameworkCore;
using Ruleta.Core.Entities;
using Ruleta.Core.Interfaces;
using Ruleta.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Infrastructure.Repositories
{
    public class ApuestaRepository : IApuestaRepository
    {
        private readonly RuletaDbContext _context;

        public ApuestaRepository(RuletaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apuesta>> GetAll()
        {
            var apuestas = _context.Apuestas.AsNoTracking();         

            return await apuestas.ToListAsync();
        }
        public async Task<Apuesta> GetById(int id)
        {
            return await _context.Apuestas.SingleOrDefaultAsync(v => v.Id == id);           
        }

        public void Add(Apuesta apuesta)
        {
            _context.Apuestas.Add(apuesta);
        }

        public void Update(Apuesta apuesta)
        {
            _context.Apuestas.Update(apuesta);

        }
    }
}
