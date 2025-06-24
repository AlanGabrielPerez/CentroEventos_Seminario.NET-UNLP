using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarPermisoUseCase(IUsuarioRepositorio usuarioRepo,
              IServicioAutorizacion auth)  : UsuarioUseCase(usuarioRepo,auth)
{

    public void Ejecutar(int idUsuario, Permiso permiso, int idSesion)
    {
        VerificarPermiso(idSesion, Permiso.Administrador);


        if (!_auth.PoseeElPermiso(idUsuario, permiso))
        {
            throw new EntidadNotFoundException($"El usuario no poesee le permmiso: {permiso}");
        }
        else
        {
            var idPermisoUsuario = _auth.ObtenerIdPorUsuarioYPermiso(idUsuario, permiso);
            _auth.EliminarPermisoUsuario(idPermisoUsuario);
           
            var permisoUsuario = _auth.ObtenerPermisoPorId(idPermisoUsuario);
            if (permisoUsuario == null)
                throw new EntidadNotFoundException($"No se encontró el permiso con ID: {idPermisoUsuario}");
            
            var usuario = _UsuarioRepo.ObtenerPorId(permisoUsuario.UsuarioId);
            if (usuario != null)
            {
                usuario.Permisos.Remove(permisoUsuario);
                _UsuarioRepo.Actualizar(usuario);
            }
        }
    }
}