using System;

namespace CentroEventos.Aplicacion.Excepciones
{
    public class CupoExcedidoException : Exception
    {
        public CupoExcedidoException()
            : base("No hay cupo disponible para este evento.") { }

        public CupoExcedidoException(string mensaje)
            : base(mensaje) { }

        public CupoExcedidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}