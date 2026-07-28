using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using VideojuegoServidor.Entidades;
using static VideojuegoServidor.AccesoDatos.ConexionBD;

namespace VideojuegoServidor.AccesoDatos
{
    public static class InventarioAD
    {
        // Inserta una criatura en el inventario del jugador
        public static bool InsertarInventario(InventarioEntidad inventario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = @"INSERT INTO InventarioJugador 
                        (IdJugador, IdCriatura, Poder, Resistencia)
                        VALUES (@IdJugador, @IdCriatura, @Poder, @Resistencia)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdJugador", inventario.IdJugador);
                        comando.Parameters.AddWithValue("@IdCriatura", inventario.IdCriatura);
                        comando.Parameters.AddWithValue("@Poder", inventario.Poder);
                        comando.Parameters.AddWithValue("@Resistencia", inventario.Resistencia);

                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar en el inventario: " + ex.Message, ex);
            }
        }

        // Consulta todo el inventario
        public static List<InventarioEntidad> ObtenerInventario()
        {
            List<InventarioEntidad> lista = new List<InventarioEntidad>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT IdInventario, IdJugador, IdCriatura, Poder, Resistencia FROM InventarioJugador";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new InventarioEntidad
                        {
                            IdInventario = Convert.ToInt32(reader["IdInventario"]),
                            IdJugador = Convert.ToInt32(reader["IdJugador"]),
                            IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                            Poder = Convert.ToInt32(reader["Poder"]),
                            Resistencia = Convert.ToInt32(reader["Resistencia"])
                        });
                    }
                }
            }

            return lista;
        }

        // Consulta el inventario de un jugador específico
        public static List<InventarioEntidad> ObtenerInventarioPorJugador(int idJugador)
        {
            List<InventarioEntidad> lista = new List<InventarioEntidad>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT IdInventario, IdJugador, IdCriatura, Poder, Resistencia FROM InventarioJugador WHERE IdJugador = @IdJugador";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdJugador", idJugador);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InventarioEntidad
                            {
                                IdInventario = Convert.ToInt32(reader["IdInventario"]),
                                IdJugador = Convert.ToInt32(reader["IdJugador"]),
                                IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                                Poder = Convert.ToInt32(reader["Poder"]),
                                Resistencia = Convert.ToInt32(reader["Resistencia"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Verifica si el jugador ya posee la criatura
        public static bool JugadorPoseeCriatura(int idJugador, int idCriatura)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = @"SELECT COUNT(*) FROM InventarioJugador 
                                 WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdJugador", idJugador);
                    comando.Parameters.AddWithValue("@IdCriatura", idCriatura);
                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }

        // Consulta una criatura específica en el inventario
        public static InventarioEntidad BuscarCriaturaEnInventario(int idJugador, int idCriatura)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = @"SELECT IdInventario, IdJugador, IdCriatura, Poder, Resistencia 
                         FROM InventarioJugador 
                         WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdJugador", idJugador);
                    comando.Parameters.AddWithValue("@IdCriatura", idCriatura);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InventarioEntidad
                            {
                                IdInventario = Convert.ToInt32(reader["IdInventario"]),
                                IdJugador = Convert.ToInt32(reader["IdJugador"]),
                                IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                                Poder = Convert.ToInt32(reader["Poder"]),
                                Resistencia = Convert.ToInt32(reader["Resistencia"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Actualiza el poder de una criatura en el inventario
        public static bool ActualizarPoder(int idJugador, int idCriatura, int incremento)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = @"UPDATE InventarioJugador 
                                 SET Poder = Poder + @Incremento 
                                 WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Incremento", incremento);
                    comando.Parameters.AddWithValue("@IdJugador", idJugador);
                    comando.Parameters.AddWithValue("@IdCriatura", idCriatura);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
