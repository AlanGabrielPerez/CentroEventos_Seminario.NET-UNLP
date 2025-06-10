using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosConCupoDisponibleUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth,
        IReservaRepositorio reservaRepo): EventoDeportivoUseCase(eventoRepo, auth)
{
    private readonly IReservaRepositorio _reservaRepo = reservaRepo;

    public List<EventoDeportivo> Ejecutar()
    {
        var fechaActual = DateTime.Now;
        var listaEventos = _eventoRepo.ObtenerTodos();

        var eventosDisponibles = new List<EventoDeportivo>();

        foreach (var evento in listaEventos)
        {
            if (evento.FechaHoraInicio > fechaActual)
            {
                int reservas = _reservaRepo.ContarReservasDeEvento(evento.Id);
                if (reservas < evento.CupoMaximo)
                    eventosDisponibles.Add(evento);
            }
        }

        return eventosDisponibles;
    }
}