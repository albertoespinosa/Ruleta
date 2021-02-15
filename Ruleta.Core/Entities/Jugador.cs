using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ruleta.Core.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Dinero { get; set; }

        public ICollection<Apuesta> Apuestas { get; set; }
        public Jugador()
        {
            Apuestas = new Collection<Apuesta>();
        }
    }
}
