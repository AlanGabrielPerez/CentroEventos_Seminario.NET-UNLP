using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosDeportivosUseCase
{
    public List<EventoDeportivo> Ejecutar(IEventoDeportivoRepositorio eventoRepo)
    {
        return eventoRepo.ObtenerTodos();
    }
}