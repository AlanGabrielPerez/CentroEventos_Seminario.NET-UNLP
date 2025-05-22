using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ActualizarEventoDeportivoUseCase
{
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly IPersonaRepositorio _personaRepo;
    private readonly EventoDeportivoValidador _validador;

    public ActualizarEventoDeportivoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IPersonaRepositorio personaRepo,
        EventoDeportivoValidador validador)
    {
        _eventoRepo = eventoRepo;
        _personaRepo = personaRepo;
        _validador = validador;
    }

    public void Ejecutar(EventoDeportivo evento)
    {
        var eventoExistente = _eventoRepo.ObtenerPorId(evento.Id);
        if (eventoExistente == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {evento.Id}.");

        if (eventoExistente.FechaHoraInicio < DateTime.Now)
            throw new OperacionInvalidaException("No se puede modificar un evento pasado.");

        if (!_validador.Validar(evento, _personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        _eventoRepo.Actualizar(evento);
    }
}