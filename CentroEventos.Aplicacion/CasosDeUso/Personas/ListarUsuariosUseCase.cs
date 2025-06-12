using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarUsuariosUseCase(IUsuarioRepositorio UsuarioRepo,IServicioAutorizacion auth): UsuarioUseCase(UsuarioRepo, auth)
{
    public List<Usuario> Ejecutar()
    {
        return _UsuarioRepo.ObtenerTodas();
    }
}
