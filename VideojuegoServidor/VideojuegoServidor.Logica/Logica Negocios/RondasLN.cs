using System;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;

namespace VideojuegoServidor.Logica
{
    public static class RondasLN
    {
        public const int CRISTALES_RONDA = 10;
        public const int INCREMENTO_PODER = 5;
        private static Random rnd = new Random();

        // Juega las 3 rondas de una batalla y devuelve el ID del jugador ganador
        public static int JugarRondas(int idBatalla, int idJugador1, int idEquipo1, int idJugador2, int idEquipo2)
        {
            EquipoEntidad equipo1 = EquipoLN.BuscarEquipoPorId(idEquipo1);
            EquipoEntidad equipo2 = EquipoLN.BuscarEquipoPorId(idEquipo2);

            InventarioEntidad c1j1 = ObtenerOCrearInventario(idJugador1, equipo1.IdCriatura1);
            InventarioEntidad c2j1 = ObtenerOCrearInventario(idJugador1, equipo1.IdCriatura2);
            InventarioEntidad c3j1 = ObtenerOCrearInventario(idJugador1, equipo1.IdCriatura3);

            InventarioEntidad c1j2 = ObtenerOCrearInventario(idJugador2, equipo2.IdCriatura1);
            InventarioEntidad c2j2 = ObtenerOCrearInventario(idJugador2, equipo2.IdCriatura2);
            InventarioEntidad c3j2 = ObtenerOCrearInventario(idJugador2, equipo2.IdCriatura3);

            int rondasGanadasJ1 = 0;
            int rondasGanadasJ2 = 0;

            if (JugarRondaIndividual(1, idBatalla, idJugador1, c1j1, idJugador2, c1j2) == idJugador1) rondasGanadasJ1++; else rondasGanadasJ2++;
            if (JugarRondaIndividual(2, idBatalla, idJugador1, c2j1, idJugador2, c2j2) == idJugador1) rondasGanadasJ1++; else rondasGanadasJ2++;
            if (JugarRondaIndividual(3, idBatalla, idJugador1, c3j1, idJugador2, c3j2) == idJugador1) rondasGanadasJ1++; else rondasGanadasJ2++;

            return rondasGanadasJ1 >= 2 ? idJugador1 : idJugador2;
        }

        // Método para obtener o crear el inventario para una criatura de un jugador
        private static InventarioEntidad ObtenerOCrearInventario(int idJugador, int idCriatura)
        {
            var inventario = InventarioLN.ConsultarCriaturaInventario(idJugador, idCriatura);
            if (inventario == null)
            {
                inventario = new InventarioEntidad
                {
                    IdJugador = idJugador,
                    IdCriatura = idCriatura,
                    Poder = 10,
                    Resistencia = 10
                };

                bool exito = InventarioLN.InsertarInventario(inventario);
                if (!exito)
                    throw new Exception("No se pudo insertar el inventario.");

                inventario = InventarioLN.ConsultarCriaturaInventario(idJugador, idCriatura);
                if (inventario == null)
                    throw new Exception("No se pudo obtener el inventario creado.");
            }
            return inventario;
        }

        // Juega una ronda individual entre dos criaturas
        private static int JugarRondaIndividual(int numeroRonda, int idBatalla,
                                int idJugador1, InventarioEntidad criJ1,
                                int idJugador2, InventarioEntidad criJ2)
        {
            RondasEntidad ronda = new RondasEntidad
            {
                IdBatalla = idBatalla,
                NumeroRonda = numeroRonda,
                IdInventarioAtacante = criJ1.IdInventario,
                IdInventarioDefensor = criJ2.IdInventario,
                GanadorRonda = 0
            };

            bool jugador1AtacaPrimero = rnd.Next(2) == 0;
            int ganador = CalcularGanadorRonda(idJugador1, criJ1, idJugador2, criJ2, jugador1AtacaPrimero);
            ronda.GanadorRonda = ganador;

            JugadorLN.AsignarCristales(JugadorLN.ConsultarJugadorPorId(ganador), CRISTALES_RONDA);

            if (ganador == idJugador1)
                InventarioLN.ActualizarPoderCriatura(idJugador1, criJ1.IdCriatura, INCREMENTO_PODER);
            else
                InventarioLN.ActualizarPoderCriatura(idJugador2, criJ2.IdCriatura, INCREMENTO_PODER);

            if (RondasAD.ExisteRonda(idBatalla, numeroRonda))
                throw new Exception($"Ya existe una ronda {numeroRonda} para la batalla {idBatalla}");

            bool exito = RondasAD.InsertarRonda(ronda);
            if (!exito)
                throw new Exception("Error al registrar la ronda en la base de datos.");

            return ganador;
        }

        // Calcula el ganador de la ronda
        private static int CalcularGanadorRonda(int idJugador1, InventarioEntidad criJ1,
                                                int idJugador2, InventarioEntidad criJ2,
                                                bool jugador1AtacaPrimero)
        {
            InventarioEntidad atacante = jugador1AtacaPrimero ? criJ1 : criJ2;
            InventarioEntidad defensor = jugador1AtacaPrimero ? criJ2 : criJ1;

            int jugadorAtacante = jugador1AtacaPrimero ? idJugador1 : idJugador2;
            int jugadorDefensor = jugador1AtacaPrimero ? idJugador2 : idJugador1;

            if (defensor.Resistencia - atacante.Poder <= 0)
                return jugadorAtacante;

            if (atacante.Resistencia - defensor.Poder <= 0)
                return jugadorDefensor;

            int remanenteAtacante = atacante.Poder - defensor.Resistencia;
            int remanenteDefensor = defensor.Poder - atacante.Resistencia;

            if (remanenteAtacante > remanenteDefensor)
                return jugadorAtacante;
            if (remanenteDefensor > remanenteAtacante)
                return jugadorDefensor;

            return rnd.Next(2) == 0 ? jugadorAtacante : jugadorDefensor;
        }

        // Consulta todas las rondas registradas
        public static RondasEntidad[] ConsultarRondas()
        {
            return RondasAD.ObtenerRondas().ToArray();
        }
    }
}