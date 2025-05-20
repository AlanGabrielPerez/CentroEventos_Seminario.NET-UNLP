namespace CentroEventos.Aplicacion.Entidades;

public enum EstadoAsistencia
{
    Pendiente,
    Presente,
    Ausente
}

public class Reserva
{
    public int Id { get; set; }

    public int PersonaId { get; set; }

    public int EventoDeportivoId { get; set; }

    public DateTime FechaAltaReserva { get; set; }

    public EstadoAsistencia EstadoAsistencia { get; set; }

    public override string ToString()
    {
        return $"{Id};{PersonaId};{EventoDeportivoId};{FechaAltaReserva};{EstadoAsistencia}";
    }

}