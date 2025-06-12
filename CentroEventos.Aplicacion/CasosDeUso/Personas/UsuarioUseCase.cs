using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;
public abstract class UsuarioUseCase(IUsuarioRepositorio UsuarioRepo, IServicioAutorizacion auth)
{
    protected readonly IUsuarioRepositorio _UsuarioRepo = UsuarioRepo;
    protected readonly IServicioAutorizacion _auth = auth;

    protected void VerificarPermiso(int idUsuario, Permiso permiso)
    {
        if (_auth == null)
            throw new FalloAutorizacionException("Servicio de autorización no disponible.");
        if (!_auth.PoseeElPermiso(idUsuario, permiso))
            throw new FalloAutorizacionException($"No tiene permiso para {permiso}.");
    }
}