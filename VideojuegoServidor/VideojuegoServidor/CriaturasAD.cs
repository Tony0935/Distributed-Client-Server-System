using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using VideojuegoServidor.Entidades;
using static VideojuegoServidor.AccesoDatos.ConexionBD;

namespace VideojuegoServidor.AccesoDatos
{
    public static class CriaturasAD
    {
        // Inserta una nueva criatura en la tienda y devuelve el ID generado
        public static int Insertar(CriaturasEntidad criatura)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();

                    string query = @"INSERT INTO TiendaCriaturas 
                             (Nombre, Tipo, Nivel, Poder, Resistencia, Costo)
                             OUTPUT INSERTED.IdCriatura
                             VALUES (@Nombre, @Tipo, @Nivel, @Poder, @Resistencia, @Costo)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", criatura.Nombre);
                        comando.Parameters.AddWithValue("@Tipo", criatura.Tipo);
                        comando.Parameters.AddWithValue("@Nivel", criatura.Nivel);
                        comando.Parameters.AddWithValue("@Poder", criatura.Poder);
                        comando.Parameters.AddWithValue("@Resistencia", criatura.Resistencia);
                        comando.Parameters.AddWithValue("@Costo", criatura.Costo);

                        return (int)comando.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar criatura: " + ex.Message);
                return -1;
            }
        }

        // Obtiene todas las criaturas en la tienda
        public static List<CriaturasEntidad> ObtenerCriaturas()
        {
            try
            {
                List<CriaturasEntidad> lista = new List<CriaturasEntidad>();

                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT IdCriatura, Nombre, Tipo, Nivel, Poder, Resistencia, Costo FROM TiendaCriaturas";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new CriaturasEntidad
                                {
                                    IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                                    Nombre = reader.GetString(1),
                                    Tipo = reader.GetString(2),
                                    Nivel = reader.GetInt32(3),
                                    Poder = reader.GetInt32(4),
                                    Resistencia = reader.GetInt32(5),
                                    Costo = reader.GetInt32(6)
                                });
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar criaturas: " + ex.Message);
                return new List<CriaturasEntidad>();
            }
        }

        // Busca una criatura por su ID
        public static CriaturasEntidad BuscarPorId(int idCriatura)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    string query = "SELECT * FROM TiendaCriaturas WHERE IdCriatura = @IdCriatura";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdCriatura", idCriatura);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CriaturasEntidad
                                {
                                    IdCriatura = idCriatura,
                                    Nombre = reader.GetString(1),
                                    Tipo = reader.GetString(2),
                                    Nivel = reader.GetInt32(3),
                                    Poder = reader.GetInt32(4),
                                    Resistencia = reader.GetInt32(5),
                                    Costo = reader.GetInt32(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar criatura: " + ex.Message);
            }

            return null;
        }
    }
}
