using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class SolicitudesUsuariosRechazadasUseCase(
    IUsuarioRepositorio UsuarioRepo,
    IServicioAutorizacion auth) : UsuarioUseCase(UsuarioRepo, auth)
{
    public List<Usuario>? Ejecutar(int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioAlta);
        return _UsuarioRepo.ObtenerSolicitudesRechazadas();
    }
}