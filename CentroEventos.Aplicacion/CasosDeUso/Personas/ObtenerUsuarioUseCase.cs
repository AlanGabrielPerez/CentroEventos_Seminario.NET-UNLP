using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Entidades;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerUsuarioUseCase(IUsuarioRepositorio UsuarioRepo, IServicioAutorizacion auth) : UsuarioUseCase(UsuarioRepo, auth)
{
    public Usuario? Ejecutar(int idUsuario, int idSesion)
    {
        VerificarPermiso(idSesion, Permiso.Lectura);
        var usuario = _UsuarioRepo.ObtenerPorId(idUsuario);
        if (usuario == null)
        {
            throw new EntidadNotFoundException($"No se encontró el usuario con ID {idUsuario}");
        }
        return usuario;
    }
}