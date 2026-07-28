using System;

namespace VideojuegoServidor.Logica.Validaciones
{
    public static class ValidacionesGlobales
    {
        // Valida que un número sea entero positivo (Ids y valores de criaturas)
        public static int ValidarPositivo(string idStr, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(idStr))
                throw new Exception($"Debe ingresar el {nombreCampo}");

            if (!int.TryParse(idStr, out int id) || id <= 0)
                throw new Exception($"El {nombreCampo} debe ser un número entero positivo.");

            return id;
        }

        // Valida que un campo de texto no esté vacío
        public static string ValidarNombre(string valor, string nombreCampo, int longitudMinima = 1)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new Exception($"El {nombreCampo} es obligatorio.");

            valor = valor.Trim();

            if (valor.Length < longitudMinima)
                throw new Exception($"El {nombreCampo} debe tener al menos {longitudMinima} caracteres.");

            return valor;
        }

        // Valida la fecha
        public static DateTime ValidarFecha(DateTime fecha, string nombreCampo)
        {
            if (fecha > DateTime.Now)
                throw new Exception($"La {nombreCampo} no puede ser futura.");

            if (fecha < new DateTime(1900, 1, 1))
                throw new Exception($"La {nombreCampo} no puede ser tan antigua.");

            return fecha;
        }

        // Calcula la edad basada en fecha de nacimiento
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            // Si aún no ha llegado el cumpleaños en este año se resta 1
            if (DateTime.Now.Month < fechaNacimiento.Month ||
               (DateTime.Now.Month == fechaNacimiento.Month && DateTime.Now.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad;
        }
    }
}