using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class RechazarSolicitudUsuarioUseCase(
    ISolicitudUsuarioRepositorio soliocitudRepo,
    IServicioAutorizacion auth) : SolicitudUsuarioUseCase(soliocitudRepo, auth)
{
    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioAlta);
        var solicitud = _solicitudRepo.ObtenerPorId(id);
        if (solicitud == null)
            throw new KeyNotFoundException($"No se encontró una solicitud con el ID {id}.");

        solicitud.Estado = EstadoSolicitud.Rechazada;
        _solicitudRepo.ActualizarSolicitud(solicitud);
    }
}
