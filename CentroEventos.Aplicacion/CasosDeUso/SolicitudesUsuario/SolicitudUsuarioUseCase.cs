using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class SolicitudUsuarioUseCase(
    ISolicitudUsuarioRepositorio solicitudRepo,
    IServicioAutorizacion auth)
{
    protected readonly ISolicitudUsuarioRepositorio _solicitudRepo = solicitudRepo;
    protected readonly IServicioAutorizacion _auth = auth;

    protected void VerificarPermiso(int idUsuario, Permiso permiso)
    {
        if (!_auth.PoseeElPermiso(idUsuario, permiso))
            throw new UnauthorizedAccessException($"El usuario {idUsuario} no tiene permiso para realizar esta acción.");
    }
}