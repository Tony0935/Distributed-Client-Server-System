using System;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;

namespace VideojuegoServidor.Logica
{
    public static class EquipoLN
    {
        public static void RegistrarEquipo(EquipoEntidad equipo)
        {
            if (equipo == null)
                throw new Exception("El equipo no puede ser nulo.");

            JugadorEntidad jugador = JugadorLN.ConsultarJugadorPorId(equipo.IdJugador);
            if (jugador == null)
                throw new Exception("El jugador asignado no está registrado.");

            if (!InventarioAD.JugadorPoseeCriatura(jugador.IdJugador, equipo.IdCriatura1) ||
                !InventarioAD.JugadorPoseeCriatura(jugador.IdJugador, equipo.IdCriatura2) ||
                !InventarioAD.JugadorPoseeCriatura(jugador.IdJugador, equipo.IdCriatura3))
            {
                throw new Exception("Una o más criaturas no pertenecen al inventario del jugador.");
            }

            if (equipo.IdCriatura1 == equipo.IdCriatura2 ||
                equipo.IdCriatura1 == equipo.IdCriatura3 ||
                equipo.IdCriatura2 == equipo.IdCriatura3)
            {
                throw new Exception("No se permiten criaturas repetidas en el mismo equipo.");
            }

            bool exito = EquipoAD.InsertarEquipo(equipo);
            if (!exito)
                throw new Exception("Error al registrar el equipo en la base de datos.");
        }

        // Consulta un equipo por su ID
        public static EquipoEntidad BuscarEquipoPorId(int idEquipo)
        {
            return EquipoAD.BuscarPorId(idEquipo);
        }

        // Consulta todos los equipos
        public static EquipoEntidad[] ConsultarEquipos()
        {
            return EquipoAD.ObtenerEquipos().ToArray();
        }
    }
}
