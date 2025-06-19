using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

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
            _UsuarioRepo.Actualizar(usuario);
        }
    }
}