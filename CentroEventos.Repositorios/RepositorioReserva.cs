using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Repositorios;

public class RepositorioReserva(CentroEventoContext context) : RepositorioDbContext(context), IReservaRepositorio
{
    public void Crear(Reserva reserva) => Create(reserva);
    public void Eliminar(int id)
    {
        var reserva = GetByID<Reserva>(id);
        if (reserva != null)
            Delete(reserva);
    }

    public void Modificar(Reserva reserva) => Update(reserva);

    public Reserva? ObtenerPorId(int id) => GetByID<Reserva>(id);

    public bool EventoTieneReservas(int eventoId) => _context.Reservas.Any(r => r.EventoDeportivoId == eventoId);

    public int ContarReservasDeEvento(int eventoId)
        => _context.Reservas.Count(r => r.EventoDeportivoId == eventoId && r.EstadoSolicitud == EstadoSolicitud.Aceptada);

    public bool ExisteReserva(int UsuarioId, int eventoId)
        => _context.Reservas.Any(r => r.UsuarioId == UsuarioId && r.EventoDeportivoId == eventoId && r.EstadoSolicitud == EstadoSolicitud.Aceptada);

    public bool TieneReservasAsociadas(int UsuarioId) =>
     _context.Reservas.Any(r => r.UsuarioId == UsuarioId && r.EstadoSolicitud == EstadoSolicitud.Aceptada);

    public List<Reserva> ObtenerTodas() => GetAll<Reserva>();

    public List<Reserva> ObtenerPorUsuarioId(int usuarioId) => _context.Reservas.Where(r => r.UsuarioId == usuarioId && r.EstadoSolicitud == EstadoSolicitud.Aceptada).ToList();

    public List<Reserva> ObtenerPorEventoId(int eventoId) =>
        _context.Reservas.Where(r => r.EventoDeportivoId == eventoId && r.EstadoSolicitud == EstadoSolicitud.Aceptada)
        .ToList();

    public List<Reserva>? ObtenerSolicitudesPendientesPorEvento(int idEvento) =>
        _context.Reservas.Where(r => r.EventoDeportivoId == idEvento && r.EstadoSolicitud == EstadoSolicitud.Pendiente)
        .ToList();

    public List<Reserva>? ObtenerSolicitudesPendientesPorUsuario(int idUsuario) =>
        _context.Reservas.Where(r => r.UsuarioId == idUsuario && r.EstadoSolicitud == EstadoSolicitud.Pendiente)
        .ToList();
}