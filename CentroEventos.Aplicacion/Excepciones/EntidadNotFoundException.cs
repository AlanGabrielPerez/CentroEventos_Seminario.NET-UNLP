using System;

namespace CentroEventos.Aplicacion.Excepciones
{
    public class EntidadNotFoundException : Exception
    {
        public EntidadNotFoundException()
            : base("Entidad no encontrada.") { }

        public EntidadNotFoundException(string mensaje)
            : base(mensaje) { }

        public EntidadNotFoundException(string entidad, int id)
            : base($"No se encontró la entidad '{entidad}' con ID {id}.") { }

        public EntidadNotFoundException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}