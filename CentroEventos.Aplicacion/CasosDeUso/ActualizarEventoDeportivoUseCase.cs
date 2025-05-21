using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ActualizarEventoDeportivoUseCase
{
    public void Ejecutar(
        EventoDeportivo evento,
        IEventoDeportivoRepositorio eventoRepo,
        IPersonaRepositorio personaRepo,
        EventoDeportivoValidador validador)
    {
        var eventoExistente = eventoRepo.ObtenerPorId(evento.Id);
        if (eventoExistente == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {evento.Id}.");

        if (eventoExistente.FechaHoraInicio < DateTime.Now)
            throw new OperacionInvalidaException("No se puede modificar un evento pasado.");

        if (!validador.Validar(evento, personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        eventoRepo.Actualizar(evento);
    }
}