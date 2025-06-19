using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearSolicitudReservaUseCase(
        ISolicitudReservaRepositorio solicitudRepo,
        ReservaValidador validador, IServicioAutorizacion auth): SolicitudReservaUseCase(solicitudRepo, auth) 
    
{
    private readonly ReservaValidador _validador = validador;

    public void Ejecutar(SolicitudReserva reserva)
    {
       if (reserva == null)
            throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");
     
        if (!_validador.Validar(reserva, out string mensajeError))
            throw new ValidacionException(mensajeError);
        if (!_validador.ValidarCupo(reserva, out string mensajeCupo))
            throw new CupoExcedidoException(mensajeCupo);
        if (!_validador.ValidarDuplicado(reserva, out string mensajeDuplicado))
            throw new DuplicadoException(mensajeDuplicado);

        reserva.FechaSolicitud = DateTime.Now;
        reserva.Estado = EstadoSolicitud.Pendiente;

        _solicitudRepo.CrearSolicitud(reserva);
    }
}