using Videojuego.Negocio.Validaciones;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica;
public static class InventarioLN
{
    public static string ComprarCriatura(int idJugador, int idCriatura)
    {
        try
        {
            ValidacionesInventario.ValidarCompra(idJugador, idCriatura);

            JugadorEntidad jugador = JugadorLN.ConsultarJugadorPorId(idJugador);
            CriaturasEntidad criatura = CriaturasLN.ConsultarCriaturaPorId(idCriatura);

            if (jugador.Cristales < criatura.Costo)
                throw new Exception("No posee la cantidad de cristales suficientes para obtener la criatura.");

            jugador.Cristales -= criatura.Costo;
            JugadorLN.AsignarCristales(jugador, -criatura.Costo);

            InventarioEntidad inventario = new InventarioEntidad
            {
                IdJugador = idJugador,
                IdCriatura = idCriatura,
                Poder = criatura.Poder,
                Resistencia = criatura.Resistencia
            };

            bool exito = InventarioAD.InsertarInventario(inventario);
            if (!exito)
                return "Error al agregar la criatura al inventario";

            return "OK";
        }
        catch (Exception ex)
        {
            return "Error en la compra: " + ex.Message;
        }
    }

    // Consulta el inventario de un jugador específico
    public static InventarioEntidad[] ConsultarInventarioPorJugador(int idJugador)
    {
        return InventarioAD.ObtenerInventarioPorJugador(idJugador).ToArray();
    }

    // Consulta todo el inventario de todos los jugadores
    public static InventarioEntidad[] ConsultarInventario()
    {
        return InventarioAD.ObtenerInventario().ToArray();
    }

    // Consulta una criatura específica en el inventario de un jugador
    public static InventarioEntidad ConsultarCriaturaInventario(int idJugador, int idCriatura)
    {
        return InventarioAD.BuscarCriaturaEnInventario(idJugador, idCriatura);
    }

    // Actualiza el poder de una criatura en el inventario de un jugador
    public static void ActualizarPoderCriatura(int idJugador, int idCriatura, int incremento)
    {
        InventarioAD.ActualizarPoder(idJugador, idCriatura, incremento);
    }

    // Inserta un nuevo inventario
    public static bool InsertarInventario(InventarioEntidad inventario)
    {
        return InventarioAD.InsertarInventario(inventario);
    }

    // Obtiene las criaturas disponibles para un jugador 
    public static CriaturasEntidad[] CriaturasDispJugador(int idJugador)
    {
        // Obtiene todas las criaturas del juego
        var todasCriaturas = CriaturasLN.ConsultarCriaturas();

        // Obtiene las criaturas que ya tiene el jugador
        var inventarioJugador = InventarioAD.ObtenerInventarioPorJugador(idJugador);
        var idsCriaturasJugador = new HashSet<int>(inventarioJugador.Select(i => i.IdCriatura));

        // Filtrar las criaturas que no tiene el jugador
        var disponibles = todasCriaturas.Where(c => !idsCriaturasJugador.Contains(c.IdCriatura)).ToArray();

        return disponibles;
    }
}