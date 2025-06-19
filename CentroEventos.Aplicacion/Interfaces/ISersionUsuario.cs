using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Interfaces;

public interface ISesionUsuario
{
    int? UsuarioId { get; }
    List<Permiso> Permisos { get; }
    void IniciarSesion(int usuarioId,string nombre, List<Permiso> permisos);
    void CerrarSesion();
    bool TienePermiso(Permiso permiso);
}