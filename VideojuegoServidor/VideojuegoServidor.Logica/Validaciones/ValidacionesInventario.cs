using System;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica;
using VideojuegoServidor.Logica.Validaciones;

namespace Videojuego.Negocio.Validaciones
{
    public static class ValidacionesInventario
    {
        // Valida la compra de una criatura
        public static void ValidarCompra(int idJugador, int idCriatura)
        {
            // Valida IDs positivos
            ValidacionesGlobales.ValidarPositivo(idJugador.ToString(), "ID del jugador");
            ValidacionesGlobales.ValidarPositivo(idCriatura.ToString(), "ID de la criatura");

            // Valida que el jugador exista
            JugadorEntidad jugador = JugadorLN.ConsultarJugadorPorId(idJugador);
            if (jugador == null)
                throw new Exception("El jugador no existe.");

            // Valida que la criatura exista
            CriaturasEntidad criatura = CriaturasLN.ConsultarCriaturaPorId(idCriatura);
            if (criatura == null)
                throw new Exception("La criatura especificada no existe.");

            // Valida que el jugador no cuente ya con la criatura
            if (InventarioAD.JugadorPoseeCriatura(idJugador, idCriatura))
                throw new Exception("El jugador ya posee esa criatura.");

            // Valida cristales suficientes
            if (jugador.Cristales < criatura.Costo)
                throw new Exception("Cristales insuficientes para comprar la criatura.");
        }
    }
}
