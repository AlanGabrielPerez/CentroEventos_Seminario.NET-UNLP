using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IEventoDeportivoRepositorio
{
    public void Actualizar(EventoDeportivo evento)
    {
        throw new NotImplementedException();
    }

    public void Agregar(EventoDeportivo evento)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public bool EsResponsableDeEventos(int personaId)
    {
        throw new NotImplementedException();
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> ObtenerTodos()
    {
        throw new NotImplementedException();
    }

    public bool TieneReservasAsociadas(int eventoId)
    {
        throw new NotImplementedException();
    }
}
