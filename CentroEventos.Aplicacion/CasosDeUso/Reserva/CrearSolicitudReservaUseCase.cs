using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearReservaUseCase(
        IReservaRepositorio reservaRepo,
        ReservaValidador validador,
        IServicioAutorizacion auth): ReservaUseCase(reservaRepo, auth) 
    
{
    private readonly ReservaValidador _validador = validador;

    public void Ejecutar(Reserva reserva)
    {
       if (reserva == null)
            throw new ArgumentNullException("La reserva no puede ser nula.");
     
        if (!_validador.Validar(reserva, out string mensajeError))
            throw new ValidacionException(mensajeError);
        if (!_validador.ValidarDuplicado(reserva, out string mensajeDuplicado))
            throw new DuplicadoException(mensajeDuplicado);

        reserva.FechaSolicitud = DateTime.Now;
        reserva.EstadoSolicitud = EstadoSolicitud.Pendiente;

        _reservaRepo.Crear(reserva);
    }
}