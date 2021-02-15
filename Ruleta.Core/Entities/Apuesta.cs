namespace Ruleta.Core.Entities
{
    public class Apuesta
    {
        public int Id { get; set; }        
        public string TipoApuesta { get; set; }
        public string SeleccionApuesta { get; set; }
        public int MontoDinero { get; set; }

        public int JugadorId { get; set; } 
        public int JuegoRuletaId { get; set; }

        public Jugador Jugador { get; set; }
        public JuegoRuleta JuegoRuleta { get; set; }
    }
}
