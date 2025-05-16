using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IReservaRepositorio
{
    void Crear(Reserva reserva);

    void Modificar(Reserva reserva);

    void Eliminar(int id);

    Reserva? ObtenerPorId(int id);

    List<Reserva> ObtenerTodas();

    List<Reserva> ObtenerPorPersonaId(int personaId);

    List<Reserva> ObtenerPorEventoId(int eventoId);

    bool ExisteReserva(int personaId, int eventoId);

    bool TieneReservasAsociadas(int personaId);

    bool EventoTieneReservas(int eventoId);

    int ContarReservasDeEvento(int eventoId);

}
