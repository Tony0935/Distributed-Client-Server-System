using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoServidor.Entidades
{
    public class CriaturasEntidad
    {
        public int IdCriatura { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Nivel { get; set; } // 1-5 (Iniciado, Aprendiz, Estudiante, Avanzado, Maestro)
        public int Poder { get; set; }
        public int Resistencia { get; set; }
        public int Costo { get; set; }
    }
}
