using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IReservaRepositorio
{
    void Crear(Reserva reserva);

    void Modificar(Reserva reserva);

    void Eliminar(int id);

    Reserva? ObtenerPorId(int id);

    List<Reserva> ObtenerTodas();

    List<Reserva> ObtenerPorUsuarioId(int usuarioId);

    List<Reserva> ObtenerPorEventoId(int eventoId);

    bool ExisteReserva(int usuarioId, int eventoId);

    bool TieneReservasAsociadas(int usuarioId);

    bool EventoTieneReservas(int eventoId);

    int ContarReservasDeEvento(int eventoId);

}
