using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AceptarSolicitudUsuarioUseCase(
    ISolicitudUsuarioRepositorio solicitudRepo,
    IServicioAutorizacion auth,
    CrearUsuarioUseCase crearUsuarioUseCase) : SolicitudUsuarioUseCase(solicitudRepo, auth)
{
    private readonly CrearUsuarioUseCase _crearUsuarioUseCase = crearUsuarioUseCase;
    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioAlta);
        var solicitud = _solicitudRepo.ObtenerPorId(id);
        if (solicitud == null)
            throw new KeyNotFoundException($"No se encontró una solicitud con el ID {id}.");

        var usuario = new Usuario
        {
            Nombre = solicitud.Nombre,
            Apellido = solicitud.Apellido,
            Email = solicitud.Email,
            PasswordHash = solicitud.PasswordHash,
            DNI = solicitud.DNI,
        };

        try
        {
            _crearUsuarioUseCase.Ejecutar(usuario, idUsuario);
            solicitud.Estado = EstadoSolicitud.Aceptada;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear usuario: {ex.Message}");
            solicitud.Estado = EstadoSolicitud.Rechazada;  
        }

        _solicitudRepo.ActualizarSolicitud(solicitud);
    }
}