using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IEventoDeportivoRepositorio
{
    EventoDeportivo? ObtenerPorId(int id);

    List<EventoDeportivo> ObtenerTodos();

    void Agregar(EventoDeportivo evento);

    void Actualizar(EventoDeportivo evento);

    void Eliminar(int id);
    bool EsResponsableDeEventos(int UsuarioId);

}