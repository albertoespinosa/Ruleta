using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IJuegoRuletaRepository JuegoRuletas { get; }
        IApuestaRepository Apuestas { get; }
        IJugadorRepository Jugadores { get; }
        Task CompleteAsync();
    }
}
