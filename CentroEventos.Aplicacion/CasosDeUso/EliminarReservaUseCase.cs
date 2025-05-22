using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarReservaUseCase
{
    public void Ejecutar(int id, IReservaRepositorio reservaRepo)
    {
        var reserva = reservaRepo.ObtenerPorId(id);
        if (reserva == null)
            throw new EntidadNotFoundException($"No se encontró la reserva con ID {id}.");

        reservaRepo.Eliminar(id);
    }
}