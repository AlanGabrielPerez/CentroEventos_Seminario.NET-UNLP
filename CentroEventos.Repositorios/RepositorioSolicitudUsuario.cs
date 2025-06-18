using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Repositorios;

public class RepositorioSolicitudUsuario(CentroEventoContext context) : RepositorioDbContext(context), ISolicitudUsuarioRepositorio
{
    public void CrearSolicitud(SolicitudUsuario solicitudUsuario) => Create(solicitudUsuario);

    public void ActualizarSolicitud(SolicitudUsuario solicitudUsuario) => Update(solicitudUsuario);


    public List<SolicitudUsuario>? ObtenerSolicitudesPendientes() => _context.SolicitudesUsuario
        .Where(s => s.Estado == EstadoSolicitud.Pendiente)
        .ToList();

    public SolicitudUsuario? ObtenerPorId(int id) => GetByID<SolicitudUsuario>(id);


}