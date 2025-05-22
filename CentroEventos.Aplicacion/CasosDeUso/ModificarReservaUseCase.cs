using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarReservaUseCase
{
    public void Ejecutar(Reserva reserva, IReservaRepositorio reservaRepo)
    {
        var reservaExistente = reservaRepo.ObtenerPorId(reserva.Id);
        if (reservaExistente == null)
            throw new EntidadNotFoundException($"No se encontró la reserva con ID {reserva.Id}.");

        reservaRepo.Modificar(reserva);
    }
}