using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AceptarSolicitudReservaUseCase(
        ISolicitudReservaRepositorio solicitudRepo,
        IServicioAutorizacion auth,
        ReservaAltaUseCase reservaAltaUseCase): SolicitudReservaUseCase(solicitudRepo,auth)
{
    
    private readonly ReservaAltaUseCase _reservaAltaUseCase = reservaAltaUseCase;

    public void Ejecutar(int idSolicitud, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);
        var solicitud = _solicitudRepo.ObtenerPorId(idSolicitud);
        if (solicitud == null)
            throw new KeyNotFoundException($"No se encontró una solicitud con el ID {idSolicitud}.");

        var reserva = new Reserva
        {
        UsuarioId = solicitud.UsuarioId,
        EventoDeportivoId = solicitud.EventoDeportivoId
        };

        try
        {
            _reservaAltaUseCase.Ejecutar(reserva, idUsuario);
            solicitud.Estado = EstadoSolicitud.Aceptada;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar reserva: {ex.Message}");
            solicitud.Estado = EstadoSolicitud.Rechazada;
        }

        _solicitudRepo.ActualizarSolicitud(solicitud);
    }
}
