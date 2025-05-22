using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarPersonasUseCase
{
    private readonly IPersonaRepositorio _personaRepo;

    public ListarPersonasUseCase(IPersonaRepositorio personaRepo)
    {
        _personaRepo = personaRepo;
    }

    public List<Persona> Ejecutar()
    {
        return _personaRepo.ObtenerTodas();
    }
}
