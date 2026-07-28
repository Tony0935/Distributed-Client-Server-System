using System;
using System.Collections.Generic;
using System.Linq;
using Videojuego.Negocio;
using Videojuego.Negocio.Validaciones;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica.Validaciones;

namespace VideojuegoServidor.Logica
{
    public static class BatallaLN
    {
        public const int CRISTALES_BATALLA = 30;

        // REGISTRAR BATALLA 
        public static string RegistrarBatalla(BatallaEntidad batalla)
        {
            if (batalla == null)
                throw new Exception("La batalla no puede ser nula.");

            EquipoEntidad equipo1 = EquipoLN.BuscarEquipoPorId(batalla.IdEquipo1);
            EquipoEntidad equipo2 = EquipoLN.BuscarEquipoPorId(batalla.IdEquipo2);

            if (equipo1 == null || equipo2 == null)
                throw new Exception("Uno o ambos equipos no están registrados.");

            JugadorEntidad jugador1 = JugadorLN.ConsultarJugadorPorId(equipo1.IdJugador);
            JugadorEntidad jugador2 = JugadorLN.ConsultarJugadorPorId(equipo2.IdJugador);

            if (jugador1 == null || jugador2 == null)
                throw new Exception("Uno o ambos jugadores no están registrados.");

            // Inserta la batalla en BD
            int idBatalla = BatallaAD.InsertarBatalla(batalla);
            batalla.IdBatalla = idBatalla;

            // Ejecuta las rondas de batalla
            int ganadorBatalla = RondasLN.JugarRondas(
                idBatalla,
                jugador1.IdJugador, batalla.IdEquipo1,
                jugador2.IdJugador, batalla.IdEquipo2
            );

            // Determina el equipo ganador
            int idJugadorGanador = ganadorBatalla;
            EquipoEntidad equipoGanador;

            if (equipo1.IdJugador == idJugadorGanador)
                equipoGanador = equipo1;
            else if (equipo2.IdJugador == idJugadorGanador)
                equipoGanador = equipo2;
            else
                throw new Exception("No se pudo determinar el equipo ganador.");

            batalla.Ganador = equipoGanador.IdEquipo;

            // Actualiza al jugador ganador
            JugadorEntidad ganador = idJugadorGanador == jugador1.IdJugador ? jugador1 : jugador2;
            JugadorLN.ActualizarBatallas(ganador);
            JugadorLN.AsignarCristales(ganador, CRISTALES_BATALLA);

            // Actualiza la batalla en BD con el ganador
            BatallaAD.ActualizarGanadorBatalla(batalla);

            // Calcular recompensas totales
            int cristalesRondas = 3 * RondasLN.CRISTALES_RONDA; // 3 rondas jugadas
            int cristalesTotales = cristalesRondas + CRISTALES_BATALLA;

            // Mensaje final 
            string mensajeResultado =
                $"Ganador: {ganador.Nombre} con el equipo {equipoGanador.NombreEquipo}.\n" +
                $"Recompensa: {cristalesTotales} cristales.";

            return mensajeResultado;

        }

        // CONSULTAR TODAS LAS BATALLAS 
        public static BatallaEntidad[] ConsultarBatallas()
        {
            return BatallaAD.ObtenerBatallas().ToArray();
        }

        // CONSULTAR BATALLAS POR JUGADOR 
        public static List<BatallaEntidad> ConsultarBatallasPorJugador(int idJugador)
        {
            var todas = BatallaAD.ObtenerBatallas();

            return todas.Where(b =>
                EsEquipoDeJugador(b.IdEquipo1, idJugador) ||
                EsEquipoDeJugador(b.IdEquipo2, idJugador)
            ).ToList();
        }

        // Verifica si un equipo pertenece a un jugador
        private static bool EsEquipoDeJugador(int idEquipo, int idJugador)
        {
            var equipo = EquipoAD.ObtenerEquipos()
                .FirstOrDefault(e => e.IdEquipo == idEquipo);

            return equipo != null && equipo.IdJugador == idJugador;
        }
    }
}
