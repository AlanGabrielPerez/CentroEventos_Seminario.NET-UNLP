using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearEventoDeportivoUseCase
{
    public void Ejecutar(
        EventoDeportivo evento,
        IEventoDeportivoRepositorio eventoRepo,
        IPersonaRepositorio personaRepo,
        EventoDeportivoValidador validador)
    {
        if (!validador.Validar(evento, personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        eventoRepo.Agregar(evento);
    }
}