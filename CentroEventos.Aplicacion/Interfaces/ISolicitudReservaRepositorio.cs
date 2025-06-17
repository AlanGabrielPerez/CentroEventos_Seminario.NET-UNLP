using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface ISolicitudReservaRepositorio
{
    SolicitudReserva? ObtenerPorId(int id);
    void CrearSolicitud(SolicitudReserva solicitudReserva);
    void ActualizarSolicitud(SolicitudReserva solicitudReserva);
   
    List<SolicitudReserva>? ObtenerSolicitudesPendientesPorEvento(int idEvento);
}