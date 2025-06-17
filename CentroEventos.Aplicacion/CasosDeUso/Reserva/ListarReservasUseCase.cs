using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasUseCase(IReservaRepositorio reservaRepo, IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    public List<Reserva> Ejecutar(int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.Lectura);

        return _reservaRepo.ObtenerTodas();
    }
}