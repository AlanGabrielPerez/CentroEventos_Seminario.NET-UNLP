using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ActualizarEventoDeportivoUseCase(
        IEventoDeportivoRepositorio eventoRepo,IServicioAutorizacion auth,
        IUsuarioRepositorio UsuarioRepo,EventoDeportivoValidador validador): EventoDeportivoUseCase(eventoRepo, auth)
{
    private readonly IUsuarioRepositorio _UsuarioRepo= UsuarioRepo;
    private readonly EventoDeportivoValidador _validador = validador;

    public void Ejecutar(EventoDeportivo evento,int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.EventoModificacion);

        var eventoExistente = _eventoRepo.ObtenerPorId(evento.Id);
        if (eventoExistente == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {evento.Id}.");

        if (eventoExistente.FechaHoraInicio < DateTime.Now)
            throw new OperacionInvalidaException("No se puede modificar un evento pasado.");

        if (!_validador.Validar(evento, _UsuarioRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        _eventoRepo.Actualizar(evento);
    }
}