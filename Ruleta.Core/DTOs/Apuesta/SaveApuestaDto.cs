namespace Ruleta.Core.DTOs.Apuesta
{
    public class SaveApuestaDto
    {        
        public string TipoApuesta { get; set; }
        public string SeleccionApuesta { get; set; }
        public int MontoDinero { get; set; }
        public int JugadorId { get; set; }     
        public int JuegoRuletaId { get; set; }       
    }
}


