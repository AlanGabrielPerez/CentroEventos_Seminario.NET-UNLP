using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class SolicitudUsuarioUseCase(
    IUsuarioRepositorio UsuarioRepo,
     UsuarioValidador validador,
     ISolicitudUsuarioRepositorio solicitudRepo)
    
{
    private readonly IUsuarioRepositorio _usuarioRepo = UsuarioRepo;
    private readonly UsuarioValidador _validador = validador;
    private readonly ISolicitudUsuarioRepositorio _solicitudRepo = solicitudRepo;

    public void Ejecutar(SolicitudUsuario usuario)
    {
        if (!_validador.Validar(usuario, _usuarioRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(usuario, _usuarioRepo, out mensajeError))
            throw new DuplicadoException(mensajeError);

        _solicitudRepo.CrearSolicitud(usuario);
    }
}
