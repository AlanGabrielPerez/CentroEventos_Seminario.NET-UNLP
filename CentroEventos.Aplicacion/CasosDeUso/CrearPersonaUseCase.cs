using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearPersonaUseCase
{
    private readonly IPersonaRepositorio _personaRepo;
    private readonly PersonaValidador _validador;

    public CrearPersonaUseCase(IPersonaRepositorio personaRepo, PersonaValidador validador)
    {
        _personaRepo = personaRepo;
        _validador = validador;
    }

    public void Ejecutar(Persona persona)
    {
        if (!_validador.Validar(persona, _personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(persona, _personaRepo, out mensajeError))
            throw new DuplicadoException(mensajeError);

        _personaRepo.Crear(persona);
    }
}
