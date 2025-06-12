using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase(
        IReservaRepositorio reservaRepo,IServicioAutorizacion auth,
        IEventoDeportivoRepositorio eventoRepo,IUsuarioRepositorio UsuarioRepo,
        ReservaValidador validador): ReservaUseCase(reservaRepo,auth)
{
    private readonly IEventoDeportivoRepositorio _eventoRepo = eventoRepo;
    private readonly IUsuarioRepositorio _UsuarioRepo = UsuarioRepo;
    private readonly ReservaValidador _validador = validador;

    public void Ejecutar(Reserva reserva, int idUsuario)
    {

        VerificarPermiso(idUsuario, Permiso.ReservaAlta);

        var Usuario = _UsuarioRepo.ObtenerPorId(reserva.UsuarioId);
        if (Usuario == null)
            throw new EntidadNotFoundException($"no existe la Usuario con ID {reserva.UsuarioId}.");

        var evento = _eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento == null)
            throw new EntidadNotFoundException($"No existe el evento con ID {reserva.EventoDeportivoId}.");

        int reservasActuales = _reservaRepo.ContarReservasDeEvento(evento.Id);
        if (reservasActuales >= evento.CupoMaximo)
            throw new CupoExcedidoException("El evento no tiene cupo disponible.");

        if (_reservaRepo.ExisteReserva(reserva.UsuarioId, reserva.EventoDeportivoId))
            throw new DuplicadoException("La Usuario ya tiene una reserva para este evento");

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        _reservaRepo.Crear(reserva);
    }
}