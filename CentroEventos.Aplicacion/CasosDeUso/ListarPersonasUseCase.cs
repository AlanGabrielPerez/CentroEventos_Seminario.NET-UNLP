using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarPersonasUseCase
{
    public List<Persona> Ejecutar(IPersonaRepositorio personaRepo)
    {
        return personaRepo.ObtenerTodas();
    }
}