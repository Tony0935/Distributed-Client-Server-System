using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VideojuegoServidor.AccesoDatos
{
    public static class ConexionBD
    {
        //Lee desde App.config
        public static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["BatallasDB"].ConnectionString;

        // Método para probar si la conexión con la base de datos está activa
        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    return conexion.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}