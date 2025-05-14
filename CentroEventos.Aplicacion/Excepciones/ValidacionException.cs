using System;

namespace CentroEventos.Aplicacion.Excepciones
{
    public class ValidacionException : Exception
    {
        public ValidacionException()
            : base("Error de validación.") { }

        public ValidacionException(string mensaje)
            : base(mensaje) { }

        public ValidacionException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}