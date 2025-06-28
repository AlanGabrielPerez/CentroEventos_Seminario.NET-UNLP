using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioReservaPendientesUseCase(
    IReservaRepositorio reservaRepo, IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    
    public List<Reserva> Ejecutar(int idUsuario, int idSesion)
    {
        VerificarPermiso(idSesion, Permiso.Lectura);
        var solicitudes = _reservaRepo.ObtenerSolicitudesPendientesPorUsuario(idUsuario);
        if (solicitudes == null || solicitudes.Count == 0)
            solicitudes = new List<Reserva>();
        
        return solicitudes;
    }
}