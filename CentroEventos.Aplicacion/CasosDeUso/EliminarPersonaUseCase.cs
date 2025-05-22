using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarPersonaUseCase
{
    private readonly IPersonaRepositorio _personaRepo;
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly IReservaRepositorio _reservaRepo;

    public EliminarPersonaUseCase(
        IPersonaRepositorio personaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
    {
        _personaRepo = personaRepo;
        _eventoRepo = eventoRepo;
        _reservaRepo = reservaRepo;
    }

    public void Ejecutar(int id)
    {
        var persona = _personaRepo.ObtenerPorId(id);
        if (persona == null)
            throw new EntidadNotFoundException($"No se encontró una persona con ID {id}.");

        bool tieneEventos = _eventoRepo.EsResponsableDeEventos(id);
        bool tieneReservas = _reservaRepo.TieneReservasAsociadas(id);

        if (tieneEventos || tieneReservas)
            throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene dependencias.");

        _personaRepo.Eliminar(id);
    }
}