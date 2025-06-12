using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearReservaUseCase(
        IReservaRepositorio reservaRepo, IServicioAutorizacion auth,
        IUsuarioRepositorio UsuarioRepo, IEventoDeportivoRepositorio eventoRepo,
        ReservaValidador validador): ReservaUseCase(reservaRepo, auth) 
    
{
    private readonly IUsuarioRepositorio _UsuarioRepo = UsuarioRepo;
    private readonly IEventoDeportivoRepositorio _eventoRepo = eventoRepo;
    private readonly ReservaValidador _validador  = validador;

    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);

        if (reserva == null)
            throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");
     
       if (!_validador.Validar(reserva, _UsuarioRepo, _eventoRepo, _reservaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        _reservaRepo.Crear(reserva);
    }
}