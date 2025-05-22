using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarReservaUseCase
{
    private readonly IReservaRepositorio _reservaRepo;

    public ModificarReservaUseCase(IReservaRepositorio reservaRepo)
    {
        _reservaRepo = reservaRepo;
    }

    public void Ejecutar(Reserva reserva)
    {
        var reservaExistente = _reservaRepo.ObtenerPorId(reserva.Id);
        if (reservaExistente == null)
            throw new EntidadNotFoundException($"No se encontró la reserva con ID {reserva.Id}.");

        _reservaRepo.Modificar(reserva);
    }
}
