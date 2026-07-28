using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoServidor.Entidades
{
    public class BatallaEntidad
    {
        public int IdBatalla { get; set; }
        public int IdEquipo1 { get; set; }
        public int IdEquipo2 { get; set; }
        public DateTime Fecha { get; set; }
        public int Ganador { get; set; }
        public string EstadoBatalla { get; set; }
    }
}
