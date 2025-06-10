using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasUseCase(IReservaRepositorio reservaRepo, IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    public List<Reserva> Ejecutar()
    {
        return _reservaRepo.ObtenerTodas();
    }
}