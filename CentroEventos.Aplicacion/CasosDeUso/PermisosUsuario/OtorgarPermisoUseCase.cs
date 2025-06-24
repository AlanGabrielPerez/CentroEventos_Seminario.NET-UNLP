using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class OtorgarPermisoUseCase(IUsuarioRepositorio usuarioRepo,
             IServicioAutorizacion auth)  : UsuarioUseCase(usuarioRepo,auth)
{

    public void Ejecutar(int usuarioId, Permiso permiso, int idSesion)
    {
        VerificarPermiso(idSesion,Permiso.Administrador);
        
        var usuario = _UsuarioRepo.ObtenerPorId(usuarioId);
        if (usuario == null)
            throw new EntidadNotFoundException($"Usuario con ID {usuarioId} no encontrado.");

        var permisoUsuario = new PermisoUsuario
        {
            UsuarioId = usuarioId,
            Permiso = permiso
        };

        _auth.AgregarPermisoUsuario(permisoUsuario);
        usuario.Permisos.Add(permisoUsuario);
        _UsuarioRepo.Actualizar(usuario);
    }
}