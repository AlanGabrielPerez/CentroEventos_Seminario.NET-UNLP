using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ReservaValidador
{
    public bool Validar(
        Reserva reserva,
        IUsuarioRepositorio UsuarioRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (UsuarioRepo.ObtenerPorId(reserva.UsuarioId) == null)
            mensajeError += $"No existe una Usuario con ID {reserva.UsuarioId}.\n";


        var evento = eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento == null)
            mensajeError += $"No existe un evento deportivo con ID {reserva.EventoDeportivoId}.\n";


        if (evento != null)
        {
            int cantidadActual = reservaRepo.ContarReservasDeEvento(evento.Id);
            if (cantidadActual >= evento.CupoMaximo)
                mensajeError += "El evento no tiene cupo disponible.\n";
        }

        if (reservaRepo.ExisteReserva(reserva.UsuarioId, reserva.EventoDeportivoId))
            mensajeError += "Ya existe una reserva para esta Usuario en este evento.\n";

        return string.IsNullOrEmpty(mensajeError);
    }
}