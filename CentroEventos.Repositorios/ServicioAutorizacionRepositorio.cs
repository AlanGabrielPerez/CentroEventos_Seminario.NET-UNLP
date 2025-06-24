using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class ServicioAutorizacionRepositorio(CentroEventoContext context) : RepositorioDbContext(context), IServicioAutorizacion
{


    public void AgregarPermisoUsuario(PermisoUsuario permisoUsuario) => Create(permisoUsuario);
    public void EliminarPermisoUsuario(int idPermisoUsuario)
    {
        var permisoUsuario = GetByID<PermisoUsuario>(idPermisoUsuario);
        if (permisoUsuario != null)
            Delete(permisoUsuario);
    }

    public bool PoseeElPermiso(int idUsuario, Permiso permiso)
    {
        return _context.PermisosUsuario.Any(p => p.UsuarioId == idUsuario && p.Permiso == permiso);
    }

    public PermisoUsuario? ObtenerPermisoPorId(int idPermisoUsuario) => GetByID<PermisoUsuario>(idPermisoUsuario);
    
    public int ObtenerIdPorUsuarioYPermiso(int idUsuario, Permiso permiso) =>
        _context.PermisosUsuario
            .Where(p => p.UsuarioId == idUsuario && p.Permiso == permiso)
            .Select(p => p.Id)
            .FirstOrDefault();

}
