using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearEventoDeportivoUseCase
{
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly IPersonaRepositorio _personaRepo;
    private readonly EventoDeportivoValidador _validador;

    public CrearEventoDeportivoUseCase(
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
        if (!_validador.Validar(evento, _personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        _eventoRepo.Agregar(evento);
    }
}