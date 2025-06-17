using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Repositorios;

public class RepositorioSolicitudReserva(CentroEventoContext context) : RepositorioDbContext(context), ISolicitudReservaRepositorio
{
    public void CrearSolicitud(SolicitudReserva solicitudReserva) => Create(solicitudReserva);

    public void AceptarSolicitud(int id)
    {
        var solicitud = GetByID<SolicitudReserva>(id);
        if (solicitud != null)
        {
            solicitud.Estado = EstadoSolicitud.Aceptada;
            Update(solicitud);
        }
    }

    public void RechazarSolicitud(int id)
    {
        var solicitud = GetByID<SolicitudReserva>(id);
        if (solicitud != null)
        {
            solicitud.Estado = EstadoSolicitud.Rechazada;
            Update(solicitud);
        }
    }

    public List<SolicitudReserva>? ObtenerSolicitudesPendientesPorEvento(int idEvento) => _context.SolicitudesReservas
        .Where(s => s.Estado == EstadoSolicitud.Pendiente && s.EventoDeportivoId == idEvento)
        .ToList();

    public SolicitudReserva? ObtenerPorId(int id) => GetByID<SolicitudReserva>(id);
}