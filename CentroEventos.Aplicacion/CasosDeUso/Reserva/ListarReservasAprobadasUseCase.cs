using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasAprobadasUseCase(
    IReservaRepositorio reservaRepo, IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    
    public List<Reserva> Ejecutar(int idEvento, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.Lectura);
        var solicitudes = _reservaRepo.ObtenerPorEventoId(idEvento);
        if (solicitudes == null || solicitudes.Count == 0)
           solicitudes = new List<Reserva>();
        
        return solicitudes;
    }
}