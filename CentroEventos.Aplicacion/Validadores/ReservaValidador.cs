using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class ReservaValidador(
        Reserva reserva,
        IUsuarioRepositorio UsuarioRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo)
{
    private readonly IUsuarioRepositorio _usuarioRepo = UsuarioRepo;
    private readonly IEventoDeportivoRepositorio _eventoRepo = eventoRepo;
    private readonly IReservaRepositorio _reservaRepo = reservaRepo;

    public bool Validar(out string mensajeError)
    {
        mensajeError = "";

        if (_usuarioRepo.ObtenerPorId(reserva.UsuarioId) == null)
            mensajeError += $"No existe una Usuario con ID {reserva.UsuarioId}.\n";

        var evento = _eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento == null)
            mensajeError += $"No existe un evento deportivo con ID {reserva.EventoDeportivoId}.\n";

        return string.IsNullOrEmpty(mensajeError);
    }

    public bool ValidarCupo(out string mensajeError)
    {
        mensajeError = "";
        var evento = _eventoRepo.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento != null)
        {
            int cantidadActual = _reservaRepo.ContarReservasDeEvento(evento.Id);
            if (cantidadActual >= evento.CupoMaximo)
                mensajeError += "El evento no tiene cupo disponible.\n";
        }
        return string.IsNullOrEmpty(mensajeError);
    }
    
    public bool ValidarDuplicado(out string mensajeError)
    {
        mensajeError = "";
        if (_reservaRepo.ExisteReserva(reserva.UsuarioId, reserva.EventoDeportivoId))
            mensajeError += "Ya existe una reserva para esta Usuario en este evento.\n";
        return string.IsNullOrEmpty(mensajeError);
    }

}