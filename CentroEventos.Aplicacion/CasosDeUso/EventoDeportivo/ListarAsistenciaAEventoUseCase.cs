using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth,
        IReservaRepositorio reservaRepo) : EventoDeportivoUseCase(eventoRepo, auth)
{
    private readonly IReservaRepositorio _reservaRepo = reservaRepo;

    public List<Reserva> Ejecutar(int eventoId, int idUsuaro)
    {
        VerificarPermiso(idUsuaro, Permiso.Lectura);
        var evento = _eventoRepo.ObtenerPorId(eventoId);
        if (evento == null)
            throw new EntidadNotFoundException($"No existe el evento con ID {eventoId}.");

        if (evento.FechaHoraInicio > DateTime.Now)
            throw new OperacionInvalidaException("Este evento aun no ocurrio.");

        var reservas = _reservaRepo.ObtenerPorEventoId(eventoId);
        return reservas.Where(r => r.EstadoAsistencia == EstadoAsistencia.Presente).ToList();
    }
}