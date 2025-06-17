using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarSolicitudesUsuarioPendientesUseCase(
    ISolicitudUsuarioRepositorio solicitudRepo,
    IServicioAutorizacion auth) : SolicitudUsuarioUseCase(solicitudRepo, auth)
{
    public List<SolicitudUsuario>? Ejecutar(int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioAlta);
        return _solicitudRepo.ObtenerSolicitudesPendientes();
    }
}