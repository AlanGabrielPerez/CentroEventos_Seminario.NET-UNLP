using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarSolicitudesReservaPendientesUseCase(
    IReservaRepositorio reservaRepo, IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    
    public List<Reserva> Ejecutar(int idEvento, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);
        var solicitudes = _reservaRepo.ObtenerSolicitudesPendientesPorEvento(idEvento);
        if (solicitudes == null || solicitudes.Count == 0)
            solicitudes = new List<Reserva>();
        
        return solicitudes;
    }
}