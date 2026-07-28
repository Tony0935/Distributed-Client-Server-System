using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using VideojuegoServidor.Entidades;
using static VideojuegoServidor.AccesoDatos.ConexionBD;

namespace VideojuegoServidor.AccesoDatos
{
    public static class BatallaAD
    {
        // Inserta una nueva batalla en la base de datos y devuelve el Id generado
        public static int InsertarBatalla(BatallaEntidad batalla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();

                    string query = @"
                        INSERT INTO Batalla (IdEquipo1, IdEquipo2, Fecha, Ganador, EstadoBatalla)
                        VALUES (@IdEquipo1, @IdEquipo2, @Fecha, @Ganador, @EstadoBatalla);
                        SELECT CAST(SCOPE_IDENTITY() AS int);";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEquipo1", batalla.IdEquipo1);
                        comando.Parameters.AddWithValue("@IdEquipo2", batalla.IdEquipo2 == 0 ? (object)DBNull.Value : batalla.IdEquipo2);
                        comando.Parameters.AddWithValue("@Fecha", batalla.Fecha);
                        comando.Parameters.AddWithValue("@Ganador", batalla.Ganador == 0 ? (object)DBNull.Value : batalla.Ganador);
                        comando.Parameters.AddWithValue("@EstadoBatalla", string.IsNullOrEmpty(batalla.EstadoBatalla) ? (object)DBNull.Value : batalla.EstadoBatalla);

                        int idGenerado = (int)comando.ExecuteScalar();
                        return idGenerado;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar batalla: " + ex.Message, ex);
            }
        }

        // Consulta todas las batallas (robusto con valores NULL)
        public static List<BatallaEntidad> ObtenerBatallas()
        {
            List<BatallaEntidad> lista = new List<BatallaEntidad>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT IdBatalla, IdEquipo1, IdEquipo2, Fecha, Ganador, EstadoBatalla FROM Batalla ORDER BY Fecha DESC";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var batalla = new BatallaEntidad
                        {
                            IdBatalla = Convert.ToInt32(reader["IdBatalla"]),
                            IdEquipo1 = reader["IdEquipo1"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEquipo1"]),
                            IdEquipo2 = reader["IdEquipo2"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEquipo2"]),
                            Fecha = reader["Fecha"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["Fecha"]),
                            Ganador = reader["Ganador"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Ganador"]),
                            EstadoBatalla = reader["EstadoBatalla"] == DBNull.Value ? null : reader["EstadoBatalla"].ToString()
                        };

                        lista.Add(batalla);
                    }
                }
            }

            return lista;
        }

        // Actualiza el ganador de una batalla existente
        public static bool ActualizarGanadorBatalla(BatallaEntidad batalla)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = "UPDATE Batalla SET Ganador = @Ganador WHERE IdBatalla = @IdBatalla";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Ganador", batalla.Ganador == 0 ? (object)DBNull.Value : batalla.Ganador);
                        comando.Parameters.AddWithValue("@IdBatalla", batalla.IdBatalla);

                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar ganador de batalla: " + ex.Message, ex);
            }
        }
    }
}