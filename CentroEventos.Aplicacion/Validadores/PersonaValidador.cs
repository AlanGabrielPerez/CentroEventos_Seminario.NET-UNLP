using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class PersonaValidador
{
    public bool Validar(
        Persona persona,
        IPersonaRepositorio personaRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(persona.Nombre))
            mensajeError += "El nombre no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(persona.Apellido))
            mensajeError += "El apellido no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(persona.DNI))
            mensajeError += "El DNI no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(persona.Email))
            mensajeError += "El email no puede estar vacío.\n";

        return string.IsNullOrEmpty(mensajeError);
    }

    public bool ValidarDuplicados(
        Persona persona,
        IPersonaRepositorio personaRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (personaRepo.ExisteDni(persona.DNI))
            mensajeError += $"Ya existe una persona con el DNI {persona.DNI}.\n";

        if (personaRepo.ExisteEmail(persona.Email))
            mensajeError += $"Ya existe una persona con el email {persona.Email}.\n";

        return string.IsNullOrEmpty(mensajeError);
    }
    
}
