using System;

namespace CentroEventos.Aplicacion.Excepciones
{
    public class DuplicadoException : Exception
    {
        public DuplicadoException()
            : base("Ya existe un registro con los mismos datos.") { }

        public DuplicadoException(string mensaje)
            : base(mensaje) { }

        public DuplicadoException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}