using Ruleta.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Core.Interfaces
{
    public interface IJuegoRuletaService
    {
        Task<IEnumerable<Apuesta>> GetRuletaApuestas(int ruletaId, int numeroGanador);

        Task<JuegoRuleta> GetJuegoRuleta(int id);

        Task InsertJuegoRuleta(JuegoRuleta juegoRuleta);

        Task UpdateJuegoRuleta(JuegoRuleta juegoRuleta);    
    }
}
