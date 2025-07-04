using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades;


public class Reserva
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int EventoDeportivoId { get; set; }

    public DateTime FechaAltaReserva { get; set; }

    public EstadoAsistencia EstadoAsistencia { get; set; }

    public DateTime FechaSolicitud { get; set; }
    public EstadoSolicitud EstadoSolicitud { get; set; }

    public override string ToString()
    {
        return $"{Id};{UsuarioId};{EventoDeportivoId};{FechaAltaReserva:yyyy-MM-ddTHH:mm:ss};{EstadoAsistencia}";
    }

    public Usuario Usuario { get; set; } = null!;
    public EventoDeportivo EventoDeportivo { get; set; } = null!;

}