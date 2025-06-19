using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class LoginUseCase(IUsuarioRepositorio usuarioRepo, ISesionUsuario sesion)
{
    public bool Ejecutar(string email, string password)
    {
        var usuario = usuarioRepo.ObtenerPorEmail(email);
        if (usuario != null && usuario.EstadoSolicitud == EstadoSolicitud.Aceptada)
        {
            password = ServicioHash.ConvertirASha256(password);
            if (usuario.PasswordHash == password)
            {
                
                var permisos = usuario.Permisos.Select(p => p.Permiso).ToList();
                sesion.IniciarSesion(usuario.Id,usuario.Nombre??"", permisos);
                return true;
            }
        }
        return false;
    }
}