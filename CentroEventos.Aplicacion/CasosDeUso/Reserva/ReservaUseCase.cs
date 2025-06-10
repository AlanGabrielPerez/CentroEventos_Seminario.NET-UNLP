using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class ReservaUseCase( IReservaRepositorio reservaRepo,IServicioAutorizacion auth)
{
    protected readonly IServicioAutorizacion _auth= auth;
    protected readonly IReservaRepositorio _reservaRepo = reservaRepo;

    protected void VerificarPermiso(int idUsuario, Permiso permiso)
    {
        if (!_auth.PoseeElPermiso(idUsuario, permiso))
            throw new FalloAutorizacionException($"No tiene permiso para {permiso}.");
    }
}