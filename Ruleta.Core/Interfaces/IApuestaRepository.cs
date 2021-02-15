using Ruleta.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Core.Interfaces
{
    public interface IApuestaRepository
    {
        Task<IEnumerable<Apuesta>> GetAll();
        Task<Apuesta> GetById(int id);
        void Add(Apuesta apuesta);       
    }
}