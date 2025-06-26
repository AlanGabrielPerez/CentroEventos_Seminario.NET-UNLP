using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CambiarContrasenaUseCase(IUsuarioRepositorio usuarioRepo)
{
    public bool Ejecutar(int idSesion, string nuevaContrasena, string contrasenaVieja)
    {
        var usuario = usuarioRepo.ObtenerPorId(idSesion);
        if (usuario != null && usuario.EstadoSolicitud == EstadoSolicitud.Aceptada)
        {
            contrasenaVieja = ServicioHash.ConvertirASha256(contrasenaVieja);
            if (usuario.PasswordHash == contrasenaVieja)
            {
                usuario.PasswordHash = ServicioHash.ConvertirASha256(nuevaContrasena);
                usuarioRepo.Actualizar(usuario);
                return true;
            }else
            {
                throw new ValidacionException("La contraseña actual no coincide.");
            }
        }
        return false;
    }
}