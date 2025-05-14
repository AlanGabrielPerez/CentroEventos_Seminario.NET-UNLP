using System;

namespace CentroEventos.Aplicacion.Excepciones
{
    public class FalloAutorizacionException : Exception
    {
        public FalloAutorizacionException()
            : base("Operación no autorizada.") { }

        public FalloAutorizacionException(string mensaje)
            : base(mensaje) { }

        public FalloAutorizacionException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }

}