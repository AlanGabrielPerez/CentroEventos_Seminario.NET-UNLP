using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Entidades;

public class ServicioAutorizacionRepositorio(CentroEventoContext context) :RepositorioDbContext(context),IServicioAutorizacion
{
   

    public void AgregarPermisoUsuario(PermisoUsuario permisoUsuario)=> Create(permisoUsuario);
    public void EliminarPermisoUsuario(int idPermisoUsuario)
    { 
        var permisoUsuario = GetByID<PermisoUsuario>(idPermisoUsuario);
        if(permisoUsuario!=null)
            Delete(permisoUsuario);
    }

    public bool PoseeElPermiso(int idUsuario, Permiso permiso)
    {
        return _context.PermisosUsuario.Any(p => p.PersonaId == idUsuario && p.Permiso == permiso);
    }
}
