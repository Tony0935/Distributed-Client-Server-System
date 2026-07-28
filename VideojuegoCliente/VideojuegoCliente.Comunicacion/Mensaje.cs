using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoCliente.Comunicacion
{
    public class Mensaje
    {
        public string Accion { get; set; } //CRUD
        public string Tipo { get; set; } // Entidad
        public string Datos { get; set; } // Datos de entidad

        public Mensaje()
        {
            Accion = string.Empty;
            Tipo = string.Empty;
            Datos = string.Empty;
        }

        public Mensaje(string accion, string tipo, string datos)
        {
            Accion = accion;
            Tipo = tipo;
            Datos = datos;
        }
    }
}