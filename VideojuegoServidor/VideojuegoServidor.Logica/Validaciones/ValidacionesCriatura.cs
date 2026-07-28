using System;
using System.Linq;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica;

namespace VideojuegoServidor.Logica.Validaciones
{
    public static class ValidacionesCriatura
    {
        public static CriaturasEntidad CrearDesdeCampos(
            string nombre,
            string tipoStr,
            string nivelStr,
            string poderStr,
            string resistenciaStr,
            string costoStr)
        {
            // Validar nombre
            string nombreValido = ValidacionesGlobales.ValidarNombre(nombre, "nombre de criatura", 3);

            string tipo = tipoStr?.Trim().ToLower();
            var tiposValidos = new[] { "fuego", "agua", "tierra", "aire" };
            if (!tiposValidos.Contains(tipo))
                throw new Exception("Seleccione un tipo válido de criatura: Fuego, Agua, Tierra o Aire.");

            int nivel = NivelDescripcion(nivelStr);
            int poder = ValidacionesGlobales.ValidarPositivo(poderStr, "Poder");
            int resistencia = ValidacionesGlobales.ValidarPositivo(resistenciaStr, "Resistencia");
            int costo = ValidacionesGlobales.ValidarPositivo(costoStr, "Costo");

            // Validación de rango de costo según nivel
            if (!CriaturasLN.CostoValido(nivel, costo))
                throw new Exception($"El costo no corresponde al rango permitido para el nivel {nivel}. Rango válido: {CriaturasLN.ObtenerRangoCosto(nivel)}");

            return new CriaturasEntidad
            {
                Nombre = nombreValido,
                Tipo = tipo,
                Nivel = nivel,
                Poder = poder,
                Resistencia = resistencia,
                Costo = costo
            };
        }
        public static int NivelDescripcion(string nivelStr)
        {
            return nivelStr?.Trim().ToLower() switch
            {
                "1 - iniciado" => 1,
                "2 - aprendiz" => 2,
                "3 - estudiante" => 3,
                "4 - avanzado" => 4,
                "5 - maestro" => 5,
                _ => throw new Exception("Seleccione un nivel válido.")
            };
        }
    }
}
