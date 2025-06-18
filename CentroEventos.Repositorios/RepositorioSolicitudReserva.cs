using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Repositorios;

public class RepositorioSolicitudReserva(CentroEventoContext context) : RepositorioDbContext(context), ISolicitudReservaRepositorio
{
    public void CrearSolicitud(SolicitudReserva solicitudReserva) => Create(solicitudReserva);

    public void ActualizarSolicitud(SolicitudReserva solicitudReserva) => Update(solicitudReserva);

    public List<SolicitudReserva>? ObtenerSolicitudesPendientesPorEvento(int idEvento) => _context.SolicitudesReservas
        .Where(s => s.Estado == EstadoSolicitud.Pendiente && s.EventoDeportivoId == idEvento)
        .OrderBy(s => s.FechaSolicitud)
        .ToList();

    public SolicitudReserva? ObtenerPorId(int id) => GetByID<SolicitudReserva>(id);
}