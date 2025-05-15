namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IEventoDeportivoRepositorio
{
    EventoDeportivo? ObtenerPorId(int id);

    List<EventoDeportivo> ObtenerTodos();

    void Agregar(EventoDeportivo evento);

    void Actualizar(EventoDeportivo evento);

    void Eliminar(int id);

    bool TieneReservasAsociadas(int eventoId);

    bool EsResponsableDeEventos(int personaId);
    
}