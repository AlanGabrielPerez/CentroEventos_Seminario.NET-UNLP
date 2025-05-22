using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase
{
    private readonly IServicioAutorizacion _servicioAuth;
    private readonly IReservaRepositorio _reservaRepo;
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly IPersonaRepositorio _personaRepo;
    private readonly ReservaValidador _validador;

    public ReservaAltaUseCase(
        IServicioAutorizacion servicioAuth,
        IReservaRepositorio reservaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IPersonaRepositorio personaRepo,
        ReservaValidador validador)
    {
        _servicioAuth = servicioAuth;
        _reservaRepo = reservaRepo;
        _eventoRepo = eventoRepo;
        _personaRepo = personaRepo;
        _validador = validador;
    }

    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        if (!_servicioAuth.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new FalloAutorizacionException("No tiene permiso para registrar reservas.");

        var persona = _personaRepo.ObtenerPorId(reserva.PersonaId);
        if (persona == null)
            throw new EntidadNotFoundException($"no existe la persona con ID {reserva.PersonaId}.");

        var evento = _eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento == null)
            throw new EntidadNotFoundException($"No existe el evento con ID {reserva.EventoDeportivoId}.");

        int reservasActuales = _reservaRepo.ContarReservasDeEvento(evento.Id);
        if (reservasActuales >= evento.CupoMaximo)
            throw new CupoExcedidoException("El evento no tiene cupo disponible.");

        if (_reservaRepo.ExisteReserva(reserva.PersonaId, reserva.EventoDeportivoId))
            throw new DuplicadoException("La persona ya tiene una reserva para este evento");

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        _reservaRepo.Crear(reserva);
    }
}