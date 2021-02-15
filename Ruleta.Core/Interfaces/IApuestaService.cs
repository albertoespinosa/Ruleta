using Ruleta.Core.DTOs.Apuesta;
using Ruleta.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Core.Interfaces
{
    public interface IApuestaService
    {
        Task<IEnumerable<Apuesta>> GetApuestas();

        Task<Apuesta> GetApuesta(int id);

        Task InsertApuesta(Apuesta apuesta);        
    }
}
