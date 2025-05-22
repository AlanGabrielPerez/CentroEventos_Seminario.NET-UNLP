using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarReservaUseCase
{
    private readonly IReservaRepositorio _reservaRepo;

    public EliminarReservaUseCase(IReservaRepositorio reservaRepo)
    {
        _reservaRepo = reservaRepo;
    }

    public void Ejecutar(int id)
    {
        var reserva = _reservaRepo.ObtenerPorId(id);
        if (reserva == null)
            throw new EntidadNotFoundException($"No se encontró la reserva con ID {id}.");

        _reservaRepo.Eliminar(id);
    }
}