namespace CentroEventos.Aplicacion.Entidades;
public class PermisoUsuario
{
    public int PersonaId { get; set; }
    public Usuario Persona { get; set; } = null!;

    public Permiso Permiso { get; set; }
}