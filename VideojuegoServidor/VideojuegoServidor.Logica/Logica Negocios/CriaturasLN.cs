using System;
using System.Collections.Generic;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Entidades;

namespace VideojuegoServidor.Logica
{
    public class CriaturasLN
    {
        // Registra una nueva criatura en la base de datos
        public static int RegistrarCriatura(CriaturasEntidad criatura)
        {
            if (criatura == null)
                throw new ArgumentException("La criatura no puede ser nula.");

            if (!CostoValido(criatura.Nivel, criatura.Costo))
                throw new Exception($"El costo no corresponde al rango permitido para el nivel {criatura.Nivel}. Rango válido: {ObtenerRangoCosto(criatura.Nivel)}");

            int nuevoId = CriaturasAD.Insertar(criatura);
            if (nuevoId <= 0)
                throw new Exception("Error al registrar la criatura en la base de datos.");

            return nuevoId;
        }

        // Consulta una criatura por su ID
        public static CriaturasEntidad ConsultarCriaturaPorId(int id)
        {
            return CriaturasAD.BuscarPorId(id);
        }

        // Lista todas las criaturas registradas
        public static CriaturasEntidad[] ConsultarCriaturas()
        {
            return CriaturasAD.ObtenerCriaturas().ToArray();
        }

        // Valida si el costo está dentro del rango permitido para el nivel
        public static bool CostoValido(int nivel, int costo)
        {
            return nivel switch
            {
                1 => costo < 100,
                2 => costo >= 100 && costo < 300,
                3 => costo >= 300 && costo < 600,
                4 => costo >= 600 && costo < 1200,
                5 => costo >= 1200,
                _ => false
            };
        }

        // Devuelve la descripción textual del nivel
        public static string ObtenerNivelCriatura(int nivel)
        {
            return nivel switch
            {
                1 => "Iniciado",
                2 => "Aprendiz",
                3 => "Estudiante",
                4 => "Avanzado",
                5 => "Maestro",
                _ => "Desconocido"
            };
        }

        // Devuelve el rango de costo permitido para un nivel
        public static string ObtenerRangoCosto(int nivel)
        {
            return nivel switch
            {
                1 => "0 - 99",
                2 => "100 - 299",
                3 => "300 - 599",
                4 => "600 - 1199",
                5 => "1200 o más",
                _ => "Nivel desconocido"
            };
        }
    }
}
