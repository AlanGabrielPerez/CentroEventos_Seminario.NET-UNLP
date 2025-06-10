using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarReservaUseCase(IReservaRepositorio reservaRepo,IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaModificacion);

        if (reserva == null)
            throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");

        var reservaExistente = _reservaRepo.ObtenerPorId(reserva.Id);
        if (reservaExistente == null)
            throw new EntidadNotFoundException($"No se encontró la reserva con ID {reserva.Id}.");

        _reservaRepo.Modificar(reserva);
    }
}
