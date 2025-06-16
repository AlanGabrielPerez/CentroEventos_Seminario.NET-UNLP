using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo(CentroEventoContext context):RepositorioDbContext(context) ,IEventoDeportivoRepositorio
{
    public void Actualizar(EventoDeportivo evento) => Update(evento);

    public void Agregar(EventoDeportivo evento)=> Create(evento);

    public void Eliminar(int id)
    {
        var evento = GetByID<EventoDeportivo>(id);
        if (evento != null)
        {
            Delete(evento);
        }
    }

    public bool EsResponsableDeEventos(int personaId)=> _context.EventosDeportivos.Any(e => e.ResponsableId == personaId);
    
    public EventoDeportivo? ObtenerPorId(int id) => GetByID<EventoDeportivo>(id);

    public List<EventoDeportivo> ObtenerTodos() => GetAll<EventoDeportivo>();

}
