using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearReservaUseCase
{
    private readonly IReservaRepositorio _reservaRepo;
    private readonly IPersonaRepositorio _personaRepo;
    private readonly IEventoDeportivoRepositorio _eventoRepo;
    private readonly ReservaValidador _validador;

    public CrearReservaUseCase(
        IReservaRepositorio reservaRepo,
        IPersonaRepositorio personaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        ReservaValidador validador)
    {
        _reservaRepo = reservaRepo;
        _personaRepo = personaRepo;
        _eventoRepo = eventoRepo;
        _validador = validador;
    }

    public void Ejecutar(Reserva reserva)
    {
        if (!_validador.Validar(reserva, _personaRepo, _eventoRepo, _reservaRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

        _reservaRepo.Crear(reserva);
    }
}