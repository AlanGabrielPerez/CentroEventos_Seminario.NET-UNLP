using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearReservaUseCase
{
    public void Ejecutar(
        Reserva reserva,
        IReservaRepositorio reservaRepo,
        IPersonaRepositorio personaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        ReservaValidador validador)
    {
        if (!validador.Validar(reserva, personaRepo, eventoRepo, reservaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        reservaRepo.Crear(reserva);
    }

}