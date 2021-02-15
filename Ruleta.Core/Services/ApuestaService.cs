using Ruleta.Core.Entities;
using Ruleta.Core.Exceptions;
using Ruleta.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruleta.Core.Services
{
    public class ApuestaService : IApuestaService
    {
        private readonly IUnitOfWork _UoW;

        public ApuestaService(IUnitOfWork unitOfWork)
        {
            _UoW = unitOfWork;
        }

        public async Task<IEnumerable<Apuesta>> GetApuestas()
        {
            var Apuestas = await _UoW.Apuestas.GetAll();

            return Apuestas;
        }

        public async Task<Apuesta> GetApuesta(int id)
        {
            return await _UoW.Apuestas.GetById(id);
        }

        public async Task InsertApuesta(Apuesta apuesta)
        {
            var jugador = await _UoW.Jugadores.GetById(apuesta.JugadorId);

            if (jugador == null)
            {
                throw new NotFoundException("El Jugador No Está Registrado: " + apuesta.JugadorId);
            }               

            if(apuesta.MontoDinero > 10000)
            {
                throw new BusinessException("La apuesta es de maximo $10000: " + "Tu Apuesta $" + apuesta.MontoDinero);
            }

            if(jugador.Dinero < apuesta.MontoDinero)
            {
                throw new BusinessException("La apuesta supera la cantidad de dinero que tiene: $" + jugador.Dinero + ", Tu Apuesta $" + apuesta.MontoDinero);
            }

            int DineroRestante = jugador.Dinero - apuesta.MontoDinero;
            jugador.Dinero = DineroRestante;

            _UoW.Apuestas.Add(apuesta);
            _UoW.Jugadores.Update(jugador);
            await _UoW.CompleteAsync();           
        }    
    }
}
