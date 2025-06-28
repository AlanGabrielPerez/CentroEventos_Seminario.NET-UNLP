using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioReservasActivasUseCase(IReservaRepositorio reservaRepo, IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    public List<Reserva> Ejecutar(int idUsuario,int idSesion)
    {
        VerificarPermiso(idSesion, Permiso.Lectura);
        return _reservaRepo.ObtenerPorUsuarioId(idUsuario);
    }
}