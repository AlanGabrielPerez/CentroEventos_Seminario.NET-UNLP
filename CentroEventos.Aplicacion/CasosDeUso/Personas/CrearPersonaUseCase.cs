using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearPersonaUseCase(IPersonaRepositorio personaRepo, IServicioAutorizacion auth, PersonaValidador validador) : PersonaUseCase(personaRepo,auth)
{
    private readonly PersonaValidador _validador = validador;

    public void Ejecutar(Persona persona,int idUsuario)
    {
       VerificarPermiso(idUsuario, Permiso.UsuarioAlta);

        if (!_validador.Validar(persona, _personaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(persona, _personaRepo, out mensajeError))
            throw new DuplicadoException(mensajeError);

        _personaRepo.Crear(persona);
    }
}
