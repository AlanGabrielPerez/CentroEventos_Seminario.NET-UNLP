using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Repositorios;

public class RepositorioSolicitudUsuario(ISolicitudUsuarioRepositorio solicitudRepo) : ISolicitudUsuarioRepositorio
{
    private readonly ISolicitudUsuarioRepositorio _solicitudRepo = solicitudRepo;

    public void CrearSolicitud(SolicitudUsuario solicitudUsuario)
    {
        
    }

    public void AceptarSolicitud(int id)
    {
        var solicitud = _solicitudRepo.ObtenerPorId(id);
        solicitud.Estado = Estado.Aceptada;
    }

    public void RechazarSolicitud(int id)
    {
        var solicitud = _solicitudRepo.ObtenerPorId(id);
            solicitud.Estado = Estado.Rechazada;
    }

    public List<SolicitudUsuario> ObtenerSolicitudesPendientes()
    {
        return null;
    }

    public SolicitudUsuario ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }
}