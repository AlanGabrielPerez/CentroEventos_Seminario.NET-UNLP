using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IReservaRepositorio
{
    public int ContarReservasDeEvento(int eventoId)
    {
        throw new NotImplementedException();
    }

    public void Crear(Reserva reserva)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public bool EventoTieneReservas(int eventoId)
    {
        throw new NotImplementedException();
    }

    public bool ExisteReserva(int personaId, int eventoId)
    {
        throw new NotImplementedException();
    }

    public void Modificar(Reserva reserva)
    {
        throw new NotImplementedException();
    }

    public List<Reserva> ObtenerPorEventoId(int eventoId)
    {
        throw new NotImplementedException();
    }

    public Reserva? ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Reserva> ObtenerPorPersonaId(int personaId)
    {
        throw new NotImplementedException();
    }

    public List<Reserva> ObtenerTodas()
    {
        throw new NotImplementedException();
    }

    public bool TieneReservasAsociadas(int personaId)
    {
        throw new NotImplementedException();
    }
}
