using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearReservaUseCase
{
    public void Ejecutar(
        Reserva reserva,
        IPersonaRepositorio personaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo,
        ReservaValidador validador)
    {
        if (!validador.Validar(reserva, personaRepo, eventoRepo, reservaRepo, out string errores))
            throw new ValidacionException(errores);

        reservaRepo.Crear(reserva);
    }
}