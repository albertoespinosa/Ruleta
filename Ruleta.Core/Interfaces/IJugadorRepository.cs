using Ruleta.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Core.Interfaces
{
    public interface IJugadorRepository
    {        
        Task<Jugador> GetById(int id);
        
        void Update(Jugador jugador);
    }
}