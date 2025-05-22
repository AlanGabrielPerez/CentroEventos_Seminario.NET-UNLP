using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase
{
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly IReservaRepositorio _reservaRepo;

    public ListarAsistenciaAEventoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
    {
        _eventoRepo = eventoRepo;
        _reservaRepo = reservaRepo;
    }

    public List<Reserva> Ejecutar(int eventoId)
    {
        var evento = _eventoRepo.ObtenerPorId(eventoId);
        if (evento == null)
            throw new EntidadNotFoundException($"No existe el evento con ID {eventoId}.");
        
        if (evento.FechaHoraInicio > DateTime.Now)
            throw new OperacionInvalidaException("Este evento aun no ocurrio.");

        var reservas = _reservaRepo.ObtenerPorEventoId(eventoId);
        return reservas.Where(r => r.EstadoAsistencia == EstadoAsistencia.Presente).ToList();
    }
}