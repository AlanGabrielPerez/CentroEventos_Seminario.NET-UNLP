using System;

namespace CentroEventos.Aplicacion.Excepciones
{
    public class OperacionInvalidaException : Exception
    {
        public OperacionInvalidaException()
            : base("La operación no está permitida por el sistema.") { }

        public OperacionInvalidaException(string mensaje)
            : base(mensaje) { }

        public OperacionInvalidaException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}