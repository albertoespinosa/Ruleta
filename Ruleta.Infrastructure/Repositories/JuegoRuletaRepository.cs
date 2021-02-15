using Microsoft.EntityFrameworkCore;
using Ruleta.Core.Entities;
using Ruleta.Core.Interfaces;
using Ruleta.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Infrastructure.Repositories
{
    public class JuegoRuletaRepository : IJuegoRuletaRepository
    {
        private readonly RuletaDbContext _context;

        public JuegoRuletaRepository(RuletaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JuegoRuleta>> GetAll()
        {
            var juegoRuletas = _context.JuegoRuletas.AsNoTracking();                                         

            return await juegoRuletas.ToListAsync();
        }
        public async Task<JuegoRuleta> GetById(int id)
        {
            return await _context.JuegoRuletas.SingleOrDefaultAsync(v => v.Id == id);
           
        }

        public void Add(JuegoRuleta juegoruleta)
        {
            _context.JuegoRuletas.Add(juegoruleta);
        }

        public void Update(JuegoRuleta juegoruleta)
        {
            _context.JuegoRuletas.Update(juegoruleta);

        }       
    }
}
