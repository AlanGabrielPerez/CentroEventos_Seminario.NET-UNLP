using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase
{
    public void Ejecutar(
        Reserva reserva,
        int idUsuario,
        IServicioAutorizacion servicioAuth,
        IReservaRepositorio reservaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IPersonaRepositorio personaRepo,
        ReservaValidador validador)
    {
        if (!servicioAuth.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new FalloAutorizacionException("No tiene permiso para registrar reservas.");

        var persona = personaRepo.ObtenerPorId(reserva.PersonaId);
        if (persona == null)
            throw new EntidadNotFoundException($"no existe la persona con ID {reserva.PersonaId}.");

        var evento = eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento == null)
            throw new EntidadNotFoundException($"no existe el evento con ID {reserva.EventoDeportivoId}.");

        int reservasActuales = reservaRepo.ContarReservasDeEvento(evento.Id);
        if (reservasActuales >= evento.CupoMaximo)
            throw new CupoExcedidoException("el evento no tiene cupo  disponible.");

        if (reservaRepo.ExisteReserva(reserva.PersonaId, reserva.EventoDeportivoId))
            throw new DuplicadoException("La persona ya tiene una reserva para este evento");

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        reservaRepo.Crear(reserva);
    }
}
