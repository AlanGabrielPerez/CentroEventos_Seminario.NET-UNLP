using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AceptarUsuarioUseCase(
    IUsuarioRepositorio UsuarioRepo,
    IServicioAutorizacion auth) : UsuarioUseCase(UsuarioRepo, auth)
{
   
    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioAlta);
        var usuario = _UsuarioRepo.ObtenerPorId(id);
        if (usuario != null)
        {
            usuario.EstadoSolicitud = EstadoSolicitud.Aceptada;
            var _permisoUsuario = new PermisoUsuario
                {
                    UsuarioId = id,
                    Permiso = Permiso.Lectura
                };
                _auth.AgregarPermisoUsuario(_permisoUsuario);
                usuario.Permisos.Add(_permisoUsuario);
                
            _UsuarioRepo.Actualizar(usuario);
        }
    }
}