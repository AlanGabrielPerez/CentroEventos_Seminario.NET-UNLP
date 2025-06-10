using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarPersonasUseCase(IPersonaRepositorio personaRepo,IServicioAutorizacion auth): PersonaUseCase(personaRepo, auth)
{
    public List<Persona> Ejecutar()
    {
        return _personaRepo.ObtenerTodas();
    }
}
