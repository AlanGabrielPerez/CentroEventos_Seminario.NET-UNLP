using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface ISolicitudUsuarioRepositorio
{
    SolicitudUsuario? ObtenerPorId(int id);
    void CrearSolicitud(SolicitudUsuario solicitudUsuario);
    void ActualizarSolicitud(SolicitudUsuario solicitudUsuario);
    List<SolicitudUsuario>? ObtenerSolicitudesPendientes();
    
}