using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearSolicitudUsuarioUseCase(
     UsuarioValidador validador,
     ISolicitudUsuarioRepositorio solicitudRepo,
     IServicioAutorizacion auth) : SolicitudUsuarioUseCase(solicitudRepo, auth)
    
{
    private readonly UsuarioValidador _validador = validador;
    public void Ejecutar(SolicitudUsuario usuario)
    {
        if (!_validador.Validar(out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(out mensajeError))
            throw new DuplicadoException(mensajeError);
            
        if (usuario.PasswordHash != null)
            usuario.PasswordHash = ServicioHash.ConvertirASha256(usuario.PasswordHash);

        _solicitudRepo.CrearSolicitud(usuario);
    }
}
