using Ruleta.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Core.Interfaces
{
    public interface IJuegoRuletaRepository
    {
        Task<IEnumerable<JuegoRuleta>> GetAll();
        Task<JuegoRuleta> GetById(int id);
        void Add(JuegoRuleta juegoruleta);
        void Update(JuegoRuleta juegoruleta);       
    }
}