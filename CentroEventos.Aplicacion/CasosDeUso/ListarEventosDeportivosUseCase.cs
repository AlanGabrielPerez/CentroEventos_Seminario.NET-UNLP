using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosDeportivosUseCase
{
    private readonly IEventoDeportivoRepositorio _eventoRepo;

    public ListarEventosDeportivosUseCase(IEventoDeportivoRepositorio eventoRepo)
    {
        _eventoRepo = eventoRepo;
    }

    public List<EventoDeportivo> Ejecutar()
    {
        return _eventoRepo.ObtenerTodos();
    }
}