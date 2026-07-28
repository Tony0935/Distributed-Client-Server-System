using System;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica.Validaciones;

namespace VideojuegoServidor.Logica.Validaciones
{
    public static class ValidacionesJugador
    {
        // Crea un jugador desde los campos del formulario con todas las validaciones
        public static JugadorEntidad CrearDesdeCampos(string nombre, string usuario, string password, DateTime fechaNacimiento)
        {
            // Valida el nombre
            string nombreValido = ValidacionesGlobales.ValidarNombre(nombre, "nombre del jugador", 2);

            // Valida el usuario
            string usuarioValido = ValidacionesGlobales.ValidarNombre(usuario, "usuario", 3);

            // Valida la contraseña
            string passwordValido = ValidacionesGlobales.ValidarNombre(password, "contraseña", 4);

            // Valida la fecha de nacimiento
            DateTime fechaValida = ValidacionesGlobales.ValidarFecha(fechaNacimiento, "fecha de nacimiento");

            // Valida que la edad sea mayor a 10 años
            int edad = ValidacionesGlobales.CalcularEdad(fechaValida);
            if (edad <= 10)
                throw new Exception("El jugador debe tener más de 10 años para registrarse.");

            // Crea el jugador
            return new JugadorEntidad
            {
                Nombre = nombreValido,
                Usuario = usuarioValido,
                Password = passwordValido,
                FechaNacimiento = fechaValida,
                Nivel = 1,          // Novato
                Cristales = 100,    // Iniciales
            };
        }
    }
}