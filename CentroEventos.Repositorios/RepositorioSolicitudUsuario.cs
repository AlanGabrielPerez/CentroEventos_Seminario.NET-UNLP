using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Repositorios;

public class RepositorioSolicitudUsuario(CentroEventoContext context) : RepositorioDbContext(context), ISolicitudUsuarioRepositorio
{
    public void CrearSolicitud(SolicitudUsuario solicitudUsuario) => Create(solicitudUsuario);

    public void AceptarSolicitud(int id)
    {
        var solicitud = GetByID<SolicitudUsuario>(id);
        if (solicitud != null)
        {
            solicitud.Estado = EstadoSolicitud.Aceptada;
            Update(solicitud);
        }

    }

    public void RechazarSolicitud(int id)
    {
        var solicitud = GetByID<SolicitudUsuario>(id);
        if (solicitud != null)
        {
            solicitud.Estado = EstadoSolicitud.Rechazada;
            Update(solicitud);
        }
    }

    public List<SolicitudUsuario>? ObtenerSolicitudesPendientes() => _context.SolicitudesUsuario
        .Where(s => s.Estado == EstadoSolicitud.Pendiente)
        .ToList();

    public SolicitudUsuario? ObtenerPorId(int id) => GetByID<SolicitudUsuario>(id);


}