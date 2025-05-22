using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasUseCase
{
    private readonly IReservaRepositorio _reservaRepo;

    public ListarReservasUseCase(IReservaRepositorio reservaRepo)
    {
        _reservaRepo = reservaRepo;
    }

    public List<Reserva> Ejecutar()
    {
        return _reservaRepo.ObtenerTodas();
    }
}