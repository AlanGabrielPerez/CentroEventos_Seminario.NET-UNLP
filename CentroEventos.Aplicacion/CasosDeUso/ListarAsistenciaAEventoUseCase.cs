using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase
{
    public List<Reserva> Ejecutar(
        int eventoId,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
    {
        var evento = eventoRepo.ObtenerPorId(eventoId);
        if (evento == null)
            throw new EntidadNotFoundException($"No existe el evento con ID {eventoId}.");
        
        if (evento.FechaHoraInicio > DateTime.Now)
            throw new OperacionInvalidaException("Este evento aun no ocurrio.");

        var reservas = reservaRepo.ObtenerPorEventoId(eventoId);
        return reservas.Where(r => r.EstadoAsistencia == EstadoAsistencia.Presente).ToList();
    }
}
