using System;
using System.Collections.Generic;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica.Validaciones;

namespace VideojuegoServidor.Logica
{
    public class JugadorLN
    {
        // Registro de un nuevo jugador
        public static int RegistrarJugador(JugadorEntidad jugador)
        {
            if (jugador == null)
                throw new Exception("El jugador no puede ser nulo.");

            //Validar que el usuario no esté repetido
            if (JugadorAD.ExisteUsuario(jugador.Usuario))
                throw new Exception("Ya existe un jugador con ese nombre de usuario.");

            //Insertar el jugador a la base de datos
            bool exito = JugadorAD.InsertarJugador(jugador);
            if (!exito)
                throw new Exception("Error al registrar el jugador en la base de datos.");

            return jugador.IdJugador;
        }

        // Consulta todos los jugadores 
        public static JugadorEntidad[] ConsultarJugadores()
        {
            return JugadorAD.ObtenerJugadores().ToArray();
        }

        // Consulta un jugador por su ID
        public static JugadorEntidad ConsultarJugadorPorId(int idJugador)
        {
            return JugadorAD.BuscarPorId(idJugador);
        }

        // Obtiene la descripción del nivel del jugador
        public static string ObtenerNivelJugador(int nivel)
        {
            return nivel switch
            {
                1 => "1 - Novato",
                2 => "2 - Estudiante",
                3 => "3 - Maestro",
                4 => "4 - Supremo",
                _ => "Desconocido",
            };
        }

        // Actualiza las batallas ganadas y el nivel del jugador
        public static void ActualizarBatallas(JugadorEntidad jugador)
        {
            if (jugador == null) return;
            jugador.BatallasGanadas++;

            if (jugador.BatallasGanadas >= 20) jugador.Nivel = 4;       // Supremo
            else if (jugador.BatallasGanadas >= 10) jugador.Nivel = 3; // Maestro  
            else if (jugador.BatallasGanadas >= 5) jugador.Nivel = 2; // Estudiante
        }

        // Actualiza los cristales del jugador
        public static void AsignarCristales(JugadorEntidad jugador, int cantidad)
        {
            if (jugador == null)
                throw new Exception("Jugador no válido.");

            bool exito = JugadorAD.ActualizarCristales(jugador.IdJugador, cantidad);
            if (!exito)
                throw new Exception("No se pudo actualizar los cristales del jugador.");
        }

        // Consulta el top 10 de jugadores con más batallas ganadas
        public static JugadorEntidad[] ConsultarTop10Ganadores()
        {
            return JugadorAD.ListarTop10Ganadores().ToArray();
        }

        // Valida las credenciales del jugador
        public static bool ValidarCredenciales(string usuario, string password)
        {
            return JugadorAD.ValidarCredenciales(usuario, password);
        }

        // Valida credenciales y retorna el jugador completo si son válidas
        public static JugadorEntidad ValidarYObtenerJugador(string usuario, string password)
        {
            // Primero valida las credenciales
            bool valido = ValidarCredenciales(usuario, password);

            // Si es válido, busca y retorna el jugador completo
            if (valido)
            {
                return JugadorAD.BuscarPorNombre(usuario); 
            }

            return null;
        }
    }
}

