using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoServidor.Entidades
{
    public class InventarioEntidad
    {
        public int IdInventario { get; set; }
        public int IdJugador { get; set; }
        public int IdCriatura { get; set; }
        public int Poder { get; set; } // aumenta +5 por ronda ganada
        public int Resistencia { get; set; }
    }
}
