using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using VideojuegoServidor.Entidades;
using static VideojuegoServidor.AccesoDatos.ConexionBD;

namespace VideojuegoServidor.AccesoDatos
{
    public static class EquipoAD
    {
        // Inserta un nuevo equipo en la base de datos
        public static bool InsertarEquipo(EquipoEntidad equipo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = @"INSERT INTO dbo.Equipo 
                        (IdJugador, NombreEquipo,IdInventarioCriatura1, 
                        IdInventarioCriatura2, IdInventarioCriatura3)
                        VALUES (@IdJugador, @NombreEquipo, @IdInventarioCriatura1, 
                        @IdInventarioCriatura2, @IdInventarioCriatura3)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdJugador", equipo.IdJugador);
                        comando.Parameters.AddWithValue("@NombreEquipo", equipo.NombreEquipo);
                        comando.Parameters.AddWithValue("@IdInventarioCriatura1", equipo.IdCriatura1);
                        comando.Parameters.AddWithValue("@IdInventarioCriatura2", equipo.IdCriatura2);
                        comando.Parameters.AddWithValue("@IdInventarioCriatura3", equipo.IdCriatura3);

                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar equipo: " + ex.Message, ex);
            }
        }

        // Consulta todos los equipos
        public static List<EquipoEntidad> ObtenerEquipos()
        {
            List<EquipoEntidad> lista = new List<EquipoEntidad>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT * FROM dbo.Equipo";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new EquipoEntidad
                        {
                            IdEquipo = Convert.ToInt32(reader["IdEquipo"]),
                            IdJugador = Convert.ToInt32(reader["IdJugador"]),
                            NombreEquipo = reader["NombreEquipo"].ToString(),
                            IdCriatura1 = Convert.ToInt32(reader["IdInventarioCriatura1"]),
                            IdCriatura2 = Convert.ToInt32(reader["IdInventarioCriatura2"]),
                            IdCriatura3 = Convert.ToInt32(reader["IdInventarioCriatura3"])
                        });
                    }
                }
            }

            return lista;
        }

        // Busca un equipo por su ID
        public static EquipoEntidad BuscarPorId(int idEquipo)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string query = "SELECT * FROM dbo.Equipo WHERE IdEquipo = @IdEquipo";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEquipo", idEquipo);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EquipoEntidad
                            {
                                IdEquipo = Convert.ToInt32(reader["IdEquipo"]),
                                IdJugador = Convert.ToInt32(reader["IdJugador"]),
                                NombreEquipo = reader["NombreEquipo"].ToString(),
                                IdCriatura1 = Convert.ToInt32(reader["IdInventarioCriatura1"]),
                                IdCriatura2 = Convert.ToInt32(reader["IdInventarioCriatura2"]),
                                IdCriatura3 = Convert.ToInt32(reader["IdInventarioCriatura3"])
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}