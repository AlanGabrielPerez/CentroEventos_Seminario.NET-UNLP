using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasUseCase
{
    public List<Reserva> Ejecutar(IReservaRepositorio reservaRepo)
    {
        return reservaRepo.ObtenerTodas();
    }
}