
using Ruleta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Ruleta.Core.DTOs.Apuesta
{
    public class GetApuestaDto
    {
        public int Id { get; set; }
        public string TipoApuesta { get; set; }
        public string SeleccionApuesta { get; set; }
        public int MontoDinero { get; set; }
        public int JugadorId { get; set; }
        public int JuegoRuletaId { get; set; }
    }
}
