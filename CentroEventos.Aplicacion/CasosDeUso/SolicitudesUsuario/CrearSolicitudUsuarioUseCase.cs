using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearSolicitudUsuarioUseCase(
     UsuarioValidador validador,
     ISolicitudUsuarioRepositorio solicitudRepo,
     IServicioAutorizacion auth) : SolicitudUsuarioUseCase(solicitudRepo, auth)

{
    private readonly UsuarioValidador _validador = validador;
    public void Ejecutar(SolicitudUsuario usuario)
    {
        if (!_validador.Validar(usuario, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(usuario, out mensajeError))
            throw new DuplicadoException(mensajeError);

        if (usuario.PasswordHash != null)
            usuario.PasswordHash = ServicioHash.ConvertirASha256(usuario.PasswordHash);

        usuario.Estado = EstadoSolicitud.Pendiente;
        _solicitudRepo.CrearSolicitud(usuario);
    }
}
