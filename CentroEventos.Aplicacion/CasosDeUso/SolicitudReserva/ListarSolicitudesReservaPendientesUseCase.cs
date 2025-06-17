using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

class ListarSolicitudesReservaPendientesUseCase(
    ISolicitudReservaRepositorio solicitudRepo, IServicioAutorizacion auth) : SolicitudReservaUseCase(solicitudRepo, auth)
{
    
    public List<SolicitudReserva> Ejecutar(int idEvento, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);
        var solicitudes = _solicitudRepo.ObtenerSolicitudesPendientesPorEvento(idEvento);
        if (solicitudes == null || solicitudes.Count == 0)
            throw new KeyNotFoundException("No se encontraron solicitudes pendientes.");
        
        return solicitudes;
    }
}