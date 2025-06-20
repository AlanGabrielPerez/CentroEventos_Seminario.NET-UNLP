using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class RechazarSolicitudReservaUseCase(
    IReservaRepositorio reservaRepo,
    IServicioAutorizacion auth) : ReservaUseCase(reservaRepo, auth)
{
    
    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.ReservaAlta);
        var solicitud = _reservaRepo.ObtenerPorId(id);
        if (solicitud == null)
            throw new KeyNotFoundException($"No se encontró una solicitud con el ID {id}.");
        
        solicitud.EstadoSolicitud = EstadoSolicitud.Rechazada;
        _reservaRepo.Modificar(solicitud); 
    }
}