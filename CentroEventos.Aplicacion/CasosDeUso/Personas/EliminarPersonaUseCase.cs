using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarPersonaUseCase(IPersonaRepositorio personaRepo,
            IServicioAutorizacion auth,IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo) : PersonaUseCase(personaRepo,auth)
{
    private readonly IEventoDeportivoRepositorio _eventoRepo = eventoRepo;
    private readonly IReservaRepositorio _reservaRepo = reservaRepo;

    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioBaja);

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