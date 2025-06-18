using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearEventoDeportivoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth,
        IUsuarioRepositorio UsuarioRepo,
        EventoDeportivoValidador validador) : EventoDeportivoUseCase(eventoRepo, auth)
{
    private readonly IUsuarioRepositorio _UsuarioRepo = UsuarioRepo;
    private readonly EventoDeportivoValidador _validador = validador;

    public void Ejecutar(EventoDeportivo evento, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.EventoAlta);

        var usuario = _UsuarioRepo.ObtenerPorId(evento.ResponsableId);
        if (usuario == null)
            throw new EntidadNotFoundException($"Usuario con ID {evento.ResponsableId} no encontrado.");

        if (!_validador.Validar(out string mensajeError))
            throw new ValidacionException(mensajeError);

        evento.Responsable = usuario;
        _eventoRepo.Agregar(evento);
                
        usuario.EventosOrganizados.Add(evento);
        _UsuarioRepo.Actualizar(usuario);

    }
}