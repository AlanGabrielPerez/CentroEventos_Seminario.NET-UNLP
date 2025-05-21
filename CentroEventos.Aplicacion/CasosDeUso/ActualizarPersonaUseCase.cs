using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ActualizarPersonaUseCase
{
    public void Ejecutar(
        Persona persona,
        IPersonaRepositorio personaRepo,
        PersonaValidador validador)
    {
        var personaExistente = personaRepo.ObtenerPorId(persona.Id);

        if (personaExistente == null)
            throw new EntidadNotFoundException($"No se encontró una persona con ID {persona.Id}.");

        if (!validador.Validar(persona, personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        bool cambioDNI = persona.DNI != personaExistente.DNI;
        bool cambioEmail = persona.Email != personaExistente.Email;

        if ((cambioDNI || cambioEmail) && !validador.ValidarDuplicados(persona, personaRepo, out mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }

        personaRepo.Actualizar(persona);
    }
}