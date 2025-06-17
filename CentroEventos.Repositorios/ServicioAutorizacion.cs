using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Repositorios;

public class ServicioAutorizacion(CentroEventoContext context) : IServicioAutorizacion
{
    private readonly CentroEventoContext _context = context;

    public bool PoseeElPermiso(int idUsuario, Permiso permiso)
    {
        return _context.PermisosUsuario.Any(p => p.PersonaId == idUsuario && p.Permiso == permiso);
    }
}
