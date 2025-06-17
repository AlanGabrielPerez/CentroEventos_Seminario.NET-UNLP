using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades;
public class SolicitudReserva : Reserva
{
    public EstadoSolicitud Estado { get; set; }

}