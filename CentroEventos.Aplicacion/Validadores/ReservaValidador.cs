using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ReservaValidador
{
    public bool Validar(
        Reserva reserva,
        IPersonaRepositorio personaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (personaRepo.ObtenerPorId(reserva.PersonaId) == null)
            mensajeError += $"No existe una persona con ID {reserva.PersonaId}.\n";


        var evento = eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento == null)
            mensajeError += $"No existe un evento deportivo con ID {reserva.EventoDeportivoId}.\n";


        if (evento != null)
        {
            int cantidadActual = reservaRepo.ContarReservasDeEvento(evento.Id);
            if (cantidadActual >= evento.CupoMaximo)
                mensajeError += "El evento no tiene cupo disponible.\n";
        }

        if (reservaRepo.ExisteReserva(reserva.PersonaId, reserva.EventoDeportivoId))
            mensajeError += "Ya existe una reserva para esta persona en este evento.\n";

        return string.IsNullOrEmpty(mensajeError);
    }
}