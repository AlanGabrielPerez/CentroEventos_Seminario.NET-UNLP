using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface ISolicitudUsuarioRepositorio
{
    SolicitudUsuario ObtenerPorId(int id);
    void CrearSolicitud(SolicitudUsuario solicitudUsuario);
    void AceptarSolicitud(int id);
    void RechazarSolicitud(int id);
    List<SolicitudUsuario> ObtenerSolicitudesPendientes();

}