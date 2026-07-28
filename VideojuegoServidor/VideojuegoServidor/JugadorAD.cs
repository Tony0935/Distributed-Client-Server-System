using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using VideojuegoServidor.Entidades;
using static VideojuegoServidor.AccesoDatos.ConexionBD;

namespace VideojuegoServidor.AccesoDatos
{
    public static class JugadorAD
    {
        // Inserta un nuevo jugador a la base de datos
        public static bool InsertarJugador(JugadorEntidad jugador)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = @"INSERT INTO Jugadores 
                 (Nombre, Usuario, Password, FechaNacimiento, Nivel, Cristales)
                 OUTPUT INSERTED.IdJugador
                 VALUES (@Nombre, @Usuario, @Password, @FechaNacimiento, @Nivel, @Cristales)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", jugador.Nombre ?? (object)DBNull.Value);
                        comando.Parameters.AddWithValue("@Usuario", jugador.Usuario ?? (object)DBNull.Value);
                        comando.Parameters.AddWithValue("@Password", jugador.Password ?? (object)DBNull.Value);
                        comando.Parameters.AddWithValue("@FechaNacimiento", jugador.FechaNacimiento);
                        comando.Parameters.AddWithValue("@Nivel", jugador.Nivel);
                        comando.Parameters.AddWithValue("@Cristales", jugador.Cristales);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 1)
                        {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar jugador en la base de datos: " + ex.Message, ex);
            }
        }

        // Obtiene todos los jugadores adpatado de: III Sesión Virtual Johan Figueroa https://www.youtube.com/watch?v=64m_afGunoQ
        public static List<JugadorEntidad> ObtenerJugadores()
        {
            try
            {
                //Lista para almacenar los jugadores
                List<JugadorEntidad> lista = new List<JugadorEntidad>();

                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT IdJugador, Nombre, FechaNacimiento, Nivel, Cristales, Usuario, Password FROM Jugadores";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {

                        using (SqlDataReader Reader = comando.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                JugadorEntidad jugador = new JugadorEntidad
                                {
                                    IdJugador = Convert.ToInt32(Reader["IdJugador"]),
                                    Nombre = Reader["Nombre"].ToString(),
                                    FechaNacimiento = Convert.ToDateTime(Reader["FechaNacimiento"]),
                                    Nivel = Convert.ToInt32(Reader["Nivel"]),
                                    Cristales = Convert.ToInt32(Reader["Cristales"]),
                                    Usuario = Reader["Usuario"].ToString(),
                                    Password = Reader["Password"].ToString()
                                };

                                lista.Add(jugador);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener jugadores: " + ex.Message, ex);
            }
        }

        // Verifica si un usuario ya existe en la base de datos
        public static bool ExisteUsuario(string usuario)
        {
            string query = "SELECT COUNT(*) FROM Jugadores WHERE Usuario = @Usuario";

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                conexion.Open();
                int cantidad = (int)comando.ExecuteScalar();
                return cantidad > 0;
            }
        }

        //Valida las credenciales de un jugador
        public static bool ValidarCredenciales(string usuario, string password)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Jugadores 
        WHERE Usuario = @Usuario COLLATE Latin1_General_CS_AS 
          AND Password = @Password COLLATE Latin1_General_CS_AS"; //Asegura que la comparación sea sensible a mayúsculas y minúsculas

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Password", password);
                conexion.Open();

                int cantidad = (int)comando.ExecuteScalar();
                return cantidad > 0;
            }
        }


        // Actualiza los cristales de un jugador
        public static bool ActualizarCristales(int idJugador, int cantidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConexionBD.ConnectionString))
            {
                conexion.Open();
                string query = @"UPDATE Jugadores SET Cristales = Cristales + @Cantidad WHERE IdJugador = @IdJugador";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Cantidad", cantidad);
                    comando.Parameters.AddWithValue("@IdJugador", idJugador);
                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        // Busca un jugador por ID
        public static JugadorEntidad BuscarPorId(int idJugador)
        {
            string query = "SELECT IdJugador, Nombre, Usuario, Password, FechaNacimiento, Nivel, Cristales FROM Jugadores WHERE IdJugador = @IdJugador";

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdJugador", idJugador);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new JugadorEntidad
                    {
                        IdJugador = Convert.ToInt32(reader["IdJugador"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Password = reader["Password"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                        Cristales = Convert.ToInt32(reader["Cristales"]),
                        BatallasGanadas = 0
                    };
                }
            }
            return null;
        }

        // Busca un jugador por su nombre de usuario
        public static JugadorEntidad BuscarPorNombre(string nombreUsuario)
        {
            string query = @"
        SELECT IdJugador, Nombre, Usuario, Password, FechaNacimiento, Nivel, Cristales
        FROM Jugadores
        WHERE Usuario = @Usuario COLLATE Latin1_General_CS_AS"; // Asegura que la comparación sea sensible a mayúsculas y minúsculas

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Usuario", nombreUsuario);
                conexion.Open();

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new JugadorEntidad
                        {
                            IdJugador = Convert.ToInt32(reader["IdJugador"]),
                            Nombre = reader["Nombre"].ToString(),
                            Usuario = reader["Usuario"].ToString(),
                            Password = reader["Password"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Cristales = Convert.ToInt32(reader["Cristales"])
                        };
                    }
                }
            }
            return null;
        }


        // Lista el Top 10 de jugadores con más victorias
        public static List<JugadorEntidad> ListarTop10Ganadores()
        {
            try
            {
                List<JugadorEntidad> lista = new List<JugadorEntidad>();

                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = @"
                SELECT TOP 10
                    j.IdJugador,
                    j.Nombre,
                    j.Usuario,
                    j.Password,
                    j.FechaNacimiento,
                    j.Nivel,
                    j.Cristales,
                    ISNULL(COUNT(b.Ganador), 0) AS BatallasGanadas
                FROM
                    Jugadores j
                LEFT JOIN Equipo e ON e.IdJugador = j.IdJugador
                LEFT JOIN Batalla b ON b.Ganador = e.IdEquipo
                GROUP BY
                    j.IdJugador,
                    j.Nombre,
                    j.Usuario,
                    j.Password,
                    j.FechaNacimiento,
                    j.Nivel,
                    j.Cristales
                ORDER BY
                    BatallasGanadas DESC;
            ";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new JugadorEntidad
                                {
                                    IdJugador = Convert.ToInt32(reader["IdJugador"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Usuario = reader["Usuario"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                    Nivel = Convert.ToInt32(reader["Nivel"]),
                                    Cristales = Convert.ToInt32(reader["Cristales"]),
                                    BatallasGanadas = Convert.ToInt32(reader["BatallasGanadas"])
                                });
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener Top 10: " + ex.Message, ex);
            }
        }
    }
}