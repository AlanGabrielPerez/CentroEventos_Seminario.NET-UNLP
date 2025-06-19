using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Servicios;

public class SesionUsuario : ISesionUsuario
{
    public int? UsuarioId { get; private set; }
    public string? Nombre { get; private set; } 
    public List<Permiso> Permisos { get; private set; } = [];

    public void IniciarSesion(int usuarioId,string nombre, List<Permiso> permisos)
    {
        UsuarioId = usuarioId;
        Nombre = nombre;
        Permisos = permisos;
    }

    public void CerrarSesion()
    {
        UsuarioId = null;
        Permisos.Clear();
    }

    public bool TienePermiso(Permiso permiso) => Permisos.Contains(permiso);
}