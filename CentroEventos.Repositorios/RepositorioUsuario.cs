using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario(CentroEventoContext context) : RepositorioDbContext(context), IUsuarioRepositorio

{
    public void Crear(Usuario Usuario) => Create(Usuario);

    public void Eliminar(int id)
    {
        var usuario = GetByID<Usuario>(id);
        if (usuario != null)
            Delete(usuario);
    }
    public void Actualizar(Usuario usuario) => Update(usuario); 
 
    public bool ExisteDni(string? dni) => _context.Usuarios.Any(u => u.DNI == dni);
   
    public bool ExisteEmail(string? email) => _context.Usuarios.Any(u => u.Email == email);

    public Usuario? ObtenerPorDni(string dni) => _context.Usuarios.FirstOrDefault(u => u.DNI == dni);

    public Usuario? ObtenerPorEmail(string email) => _context.Usuarios.FirstOrDefault(u => u.Email == email);
 
    public Usuario? ObtenerPorId(int id) => GetByID<Usuario>(id);

    public List<Usuario>? ObtenerTodas() => GetAll<Usuario>();

    public List<Usuario>? ObtenerSolicitudesPendientes() => _context.Usuarios
        .Where(u => u.EstadoSolicitud == EstadoSolicitud.Pendiente)
        .ToList();
    
}