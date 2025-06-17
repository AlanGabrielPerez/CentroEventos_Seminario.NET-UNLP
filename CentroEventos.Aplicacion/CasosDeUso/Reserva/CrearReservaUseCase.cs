using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearReservaUseCase(
        IReservaRepositorio reservaRepo, IServicioAutorizacion auth,
        ReservaValidador validador): ReservaUseCase(reservaRepo, auth) 
    
{
    private readonly ReservaValidador _validador  = validador;

    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);

        if (reserva == null)
            throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");
     
       if (!_validador.Validar(out string mensajeError))
            throw new ValidacionException(mensajeError);

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        _reservaRepo.Crear(reserva);
    }
}