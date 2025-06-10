using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosDeportivosUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth): EventoDeportivoUseCase(eventoRepo, auth)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return _eventoRepo.ObtenerTodos();
    }
}