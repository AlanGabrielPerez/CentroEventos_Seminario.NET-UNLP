using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades;

public class PermisoUsuario

{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Permiso Permiso { get; set; }
    public Usuario Usuario { get; set; } = null!;

} 