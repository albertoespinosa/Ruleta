using Ruleta.Core.Entities;
using Ruleta.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Ruleta.Core.Services
{
    public class JuegoRuletaService : IJuegoRuletaService
    {
        private readonly IUnitOfWork _UoW;

        public JuegoRuletaService(IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;
        }

        public async Task<IEnumerable<Apuesta>> GetRuletaApuestas(int ruletaId, int numeroGanador)
        {
            var color = numeroGanador % 2 == 0 ? "Rojo" : "Negro";

            string numero = numeroGanador.ToString();

            var ruletaApuestas = await _UoW.Apuestas.GetAll();
            ruletaApuestas = ruletaApuestas.Where(a => a.JuegoRuletaId == ruletaId && (a.SeleccionApuesta == numero || a.SeleccionApuesta == color));

            foreach (var apuesta in ruletaApuestas)
            {
                if (apuesta.TipoApuesta == "Numero")
                    apuesta.MontoDinero *= 3;
                if (apuesta.TipoApuesta == "Color")
                    apuesta.MontoDinero = (int) (1.8 * apuesta.MontoDinero);
            }

            return ruletaApuestas;
        }

        public async Task<JuegoRuleta> GetJuegoRuleta(int id)
        {
            return await _UoW.JuegoRuletas.GetById(id);
        }

        public async Task InsertJuegoRuleta(JuegoRuleta NuevoJuego)
        {           
            _UoW.JuegoRuletas.Add(NuevoJuego);
            await _UoW.CompleteAsync();          
        }

        public async Task UpdateJuegoRuleta(JuegoRuleta juegoRuleta)
        {
            _UoW.JuegoRuletas.Update(juegoRuleta);
            await _UoW.CompleteAsync();
        }
    }
}
