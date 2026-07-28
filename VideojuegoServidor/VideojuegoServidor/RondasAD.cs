using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using VideojuegoServidor.Entidades;
using static VideojuegoServidor.AccesoDatos.ConexionBD;

namespace VideojuegoServidor.AccesoDatos
{
    public static class RondasAD
    {
        // Inserta una nueva ronda en la base de datos
        public static bool InsertarRonda(RondasEntidad ronda)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();

                    string query = @"INSERT INTO Rondas 
                        (IdBatalla, NumeroRonda, IdInventarioAtacante, IdInventarioDefensor, GanadorRonda)
                        VALUES (@IdBatalla, @NumeroRonda, @IdInventarioAtacante, @IdInventarioDefensor, @GanadorRonda)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdBatalla", ronda.IdBatalla);
                        comando.Parameters.AddWithValue("@NumeroRonda", ronda.NumeroRonda);
                        comando.Parameters.AddWithValue("@IdInventarioAtacante", ronda.IdInventarioAtacante);
                        comando.Parameters.AddWithValue("@IdInventarioDefensor", ronda.IdInventarioDefensor);
                        comando.Parameters.AddWithValue("@GanadorRonda", ronda.GanadorRonda);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Puedes agregar aquí un log específico para errores SQL si lo deseas
                throw new Exception("Error al insertar ronda (SQL): " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al insertar ronda: " + ex.Message, ex);
            }
        }

        // Consulta todas las rondas
        public static List<RondasEntidad> ObtenerRondas()
        {
            List<RondasEntidad> lista = new List<RondasEntidad>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT * FROM Rondas ORDER BY IdBatalla, IdRonda";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RondasEntidad
                        {
                            IdRonda = Convert.ToInt32(reader["IdRonda"]),
                            IdBatalla = Convert.ToInt32(reader["IdBatalla"]),
                            NumeroRonda = Convert.ToInt32(reader["NumeroRonda"]),
                            IdInventarioAtacante = Convert.ToInt32(reader["IdInventarioAtacante"]),
                            IdInventarioDefensor = Convert.ToInt32(reader["IdInventarioDefensor"]),
                            GanadorRonda = Convert.ToInt32(reader["GanadorRonda"])
                        });
                    }
                }
            }

            return lista;
        }

        // Verifica si ya existe una ronda con el mismo IdBatalla y NumeroRonda
        public static bool ExisteRonda(int idBatalla, int numeroRonda)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Rondas WHERE IdBatalla = @IdBatalla AND NumeroRonda = @NumeroRonda";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdBatalla", idBatalla);
                    comando.Parameters.AddWithValue("@NumeroRonda", numeroRonda);
                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
    }
}