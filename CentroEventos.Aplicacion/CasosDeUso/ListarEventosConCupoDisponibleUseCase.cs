using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosConCupoDisponibleUseCase
{
    public List<EventoDeportivo> Ejecutar(
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
    {
        var fechaActual = DateTime.Now;
        var listaEventos = eventoRepo.ObtenerTodos();

        var eventosDisponibles = new List<EventoDeportivo>();

        foreach (var evento in listaEventos)
        {
            if (evento.FechaHoraInicio > fechaActual)
            {
                int reservas = reservaRepo.ContarReservasDeEvento(evento.Id);
                if (reservas < evento.CupoMaximo)
                    eventosDisponibles.Add(evento);
            }
        }

        return eventosDisponibles;
    }
}
