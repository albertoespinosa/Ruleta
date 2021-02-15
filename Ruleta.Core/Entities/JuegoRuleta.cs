using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ruleta.Core.Entities
{
    public class JuegoRuleta
    {
        public int Id { get; set; }
        public string Estado { get; set; }

        public ICollection<Apuesta> Apuestas { get; set; }
        public JuegoRuleta()
        {
            Estado = "Creada";
            Apuestas = new Collection<Apuesta>();
        }

    }
}
