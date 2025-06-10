using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarReservaUseCase(IReservaRepositorio reservaRepo,IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{

    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaBaja);

        var reserva = _reservaRepo.ObtenerPorId(id);
        if (reserva == null)
            throw new EntidadNotFoundException("No se encontró la reserva.");

        _reservaRepo.Eliminar(id);
    }
}