using Ruleta.Core.Interfaces;
using Ruleta.Infrastructure.Data;
using System.Threading.Tasks;

namespace Ruleta.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RuletaDbContext _context;
        private readonly IJuegoRuletaRepository _juegoruletaRepository;
        private readonly IApuestaRepository _apuestaRepository;
        private readonly IJugadorRepository _jugadorRepository;

        public UnitOfWork(RuletaDbContext context)
        {
            this._context = context;
        }

        public IJuegoRuletaRepository JuegoRuletas => _juegoruletaRepository ?? new JuegoRuletaRepository(_context);
        public IApuestaRepository Apuestas => _apuestaRepository ?? new ApuestaRepository(_context);
        public IJugadorRepository Jugadores => _jugadorRepository ?? new JugadorRepository(_context);

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
