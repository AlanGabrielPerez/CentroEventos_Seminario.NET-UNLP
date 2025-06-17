using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades;

public class SolicitudReserva : Reserva
{
    public DateTime FechaSolicitud { get; set; }
    public EstadoSolicitud Estado { get; set; }

}