using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;


namespace CentroEventos.Aplicacion.Validadores;

public class EventoDeportivoValidador
{
    public bool Validar(
        EventoDeportivo evento,
        IUsuarioRepositorio UsuarioRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(evento.Nombre))
            mensajeError += "El nombre del evento no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(evento.Descripcion))
            mensajeError += "La descripción del evento no puede estar vacía.\n";

        if (evento.FechaHoraInicio < DateTime.Now)
            mensajeError += "La fecha de inicio debe ser igual o posterior a la fecha actual.\n";

        if (evento.CupoMaximo <= 0)
            mensajeError += "El cupo máximo debe ser mayor que cero.\n";

        if (evento.DuracionHoras <= 0)
            mensajeError += "La duración del evento debe ser mayor que cero.\n";

        if (UsuarioRepo.ObtenerPorId(evento.ResponsableId) == null)
            mensajeError += $"No existe una Usuario con ID {evento.ResponsableId} como responsable.\n";

        return string.IsNullOrEmpty(mensajeError);
    }
}