using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase(
        IReservaRepositorio reservaRepo,IServicioAutorizacion auth,
        ReservaValidador validador): ReservaUseCase(reservaRepo,auth)
{

    private readonly ReservaValidador _validador = validador;

    public void Ejecutar(int id, int idUsuario)
    {
        var reserva = _reservaRepo.ObtenerPorId(id);
        if (reserva != null)
        {
            VerificarPermiso(idUsuario, Permiso.ReservaAlta);
            
            if (!_validador.Validar(reserva, out string mensajeError))
                throw new EntidadNotFoundException("Error"+ mensajeError);
            if (!_validador.ValidarCupo(reserva, out string mensajeCupo))
                throw new CupoExcedidoException("Error"+ mensajeCupo);
           
            reserva.EstadoSolicitud = EstadoSolicitud.Aceptada;

            reserva.FechaAltaReserva = DateTime.Now;
            reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

            _reservaRepo.Crear(reserva);
        }
    }
}