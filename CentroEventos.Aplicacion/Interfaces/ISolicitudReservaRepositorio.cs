using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface ISolicitudReservaRepositorio
{
    SolicitudReserva? ObtenerPorId(int id);
    void CrearSolicitud(SolicitudReserva solicitudReserva);
    void AceptarSolicitud(int id);
    void RechazarSolicitud(int id);
    List<SolicitudReserva>? ObtenerSolicitudesPendientesPorEvento(int idEvento);
}