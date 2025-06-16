using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarUsuariosUseCase(IUsuarioRepositorio UsuarioRepo, IServicioAutorizacion auth) : UsuarioUseCase(UsuarioRepo, auth)
{
    public List<Usuario>? Ejecutar(int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.Lectura);
        return _UsuarioRepo.ObtenerTodas();
    }
}
