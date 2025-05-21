using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearPersonaUseCase
{
    public void Ejecutar(
        Persona persona,
        IPersonaRepositorio personaRepo,
        PersonaValidador validador)
    {
        if (!validador.Validar(persona, personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

         if (!validador.ValidarDuplicados(persona, personaRepo, out string mensajeError))
            throw new DuplicadoException(mensajeError);

        personaRepo.Crear(persona);
    }
}