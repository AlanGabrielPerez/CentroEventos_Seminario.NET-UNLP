using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarEventoDeportivoUseCase
{
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly IReservaRepositorio _reservaRepo;

    public EliminarEventoDeportivoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
    {
        _eventoRepo = eventoRepo;
        _reservaRepo = reservaRepo;
    }

    public void Ejecutar(int id)
    {
        var evento = _eventoRepo.ObtenerPorId(id);
        if (evento == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {id}.");

        if (_reservaRepo.EventoTieneReservas(id))
            throw new OperacionInvalidaException("No se puede eliminar un evento con reservas asociadas.");

        _eventoRepo.Eliminar(id);
    }
}