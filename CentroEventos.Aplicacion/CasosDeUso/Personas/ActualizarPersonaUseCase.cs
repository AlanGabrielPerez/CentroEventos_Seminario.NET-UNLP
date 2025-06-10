using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ActualizarPersonaUseCase(IPersonaRepositorio personaRepo,
            IServicioAutorizacion auth, PersonaValidador validador) : PersonaUseCase(personaRepo,auth)
{
    private readonly PersonaValidador _validador = validador;

    public void Ejecutar(Persona persona, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioModificacion);

        if (!_validador.Validar(persona, _personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        _personaRepo.Actualizar(persona);
    }
}