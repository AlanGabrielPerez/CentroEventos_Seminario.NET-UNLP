using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

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

        _solicitudRepo.CrearSolicitud(usuario);
    }
}
