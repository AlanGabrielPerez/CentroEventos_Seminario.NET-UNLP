using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarPersonaUseCase
{
    public void Ejecutar(
        int id,
        IPersonaRepositorio personaRepo,
        IReservaRepositorio reservaRepo,
        IEventoDeportivoRepositorio eventoRepo)
    {
        var persona = personaRepo.ObtenerPorId(id);
        if (persona == null)
            throw new EntidadNotFoundException($"No se encontró la persona con ID {id}.");

        if (reservaRepo.TieneReservasAsociadas(id))
            throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene reservas asociadas.");

        if (eventoRepo.EsResponsableDeEventos(id))
            throw new OperacionInvalidaException("No se puede eliminar la persona porque es responsable de uno o más eventos.");

        personaRepo.Eliminar(id);
    }
}