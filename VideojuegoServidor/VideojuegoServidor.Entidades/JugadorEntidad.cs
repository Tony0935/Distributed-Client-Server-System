using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoServidor.Entidades
{
    public class JugadorEntidad
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nivel { get; set; } // 1-Novato, 2-Estudiante, 3-Maestro, 4-Supremo
        public int Cristales { get; set; }
        public int BatallasGanadas { get; set; }
    }
}
