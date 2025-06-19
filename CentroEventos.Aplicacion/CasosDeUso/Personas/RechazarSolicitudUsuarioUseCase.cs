using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class RechazarUsuarioUseCase(
    IUsuarioRepositorio UsuarioRepo,
    IServicioAutorizacion auth) : UsuarioUseCase(UsuarioRepo, auth)
{
    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioAlta);
        var usuario = _UsuarioRepo.ObtenerPorId(id);
        if (usuario == null)
            throw new KeyNotFoundException($"No se encontró una usuario con el ID {id}.");

        usuario.EstadoSolicitud = EstadoSolicitud.Rechazada;
        _UsuarioRepo.Actualizar(usuario);
    }
}
