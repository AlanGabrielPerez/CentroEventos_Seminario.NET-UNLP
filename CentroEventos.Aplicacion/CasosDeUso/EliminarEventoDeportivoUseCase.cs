using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarEventoDeportivoUseCase
{
    public void Ejecutar(
        int id,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
    {
        var evento = eventoRepo.ObtenerPorId(id);
        if (evento == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {id}.");

        if (reservaRepo.EventoTieneReservas(id))
            throw new OperacionInvalidaException("No se puede eliminar un evento con reservas asociadas.");

        eventoRepo.Eliminar(id);
    }
}