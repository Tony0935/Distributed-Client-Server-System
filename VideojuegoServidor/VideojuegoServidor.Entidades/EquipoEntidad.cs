using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoServidor.Entidades
{
    public class EquipoEntidad
    {
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public int IdJugador { get; set; }
        public int IdCriatura1 { get; set; }
        public int IdCriatura2 { get; set; }
        public int IdCriatura3 { get; set; }
    }
}
