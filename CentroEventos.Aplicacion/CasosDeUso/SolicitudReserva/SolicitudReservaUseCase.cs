using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class SolicitudReservaUseCase(
    ISolicitudReservaRepositorio solicitudRepo,
    IServicioAutorizacion auth)
{
    protected readonly IServicioAutorizacion _auth= auth;
    protected readonly ISolicitudReservaRepositorio _solicitudRepo = solicitudRepo;

    protected void VerificarPermiso(int idUsuario, Permiso permiso)
    {
        if (!_auth.PoseeElPermiso(idUsuario, permiso))
            throw new FalloAutorizacionException($"No tiene permiso para {permiso}.");
    }
}