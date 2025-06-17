using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

class RechazarSolicitudReservaUseCase(
    ISolicitudReservaRepositorio solicitudRepo,
    IServicioAutorizacion auth) : SolicitudReservaUseCase(solicitudRepo, auth)
{
    
    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);
        var solicitud = _solicitudRepo.ObtenerPorId(id);
        if (solicitud == null)
            throw new KeyNotFoundException($"No se encontró una solicitud con el ID {id}.");
            
        solicitud.Estado = EstadoSolicitud.Rechazada;
        _solicitudRepo.ActualizarSolicitud(solicitud); 
    }
}