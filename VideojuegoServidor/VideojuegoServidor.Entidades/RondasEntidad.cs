using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoServidor.Entidades
{
    public class RondasEntidad
    {
        public int IdRonda { get; set; }
        public int IdBatalla { get; set; }
        public int NumeroRonda { get; set; }
        public int IdInventarioAtacante { get; set; }
        public int IdInventarioDefensor { get; set; }
        public int GanadorRonda { get; set; }
    }

}
