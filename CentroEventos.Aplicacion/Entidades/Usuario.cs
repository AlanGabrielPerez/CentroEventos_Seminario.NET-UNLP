using CentroEventos.Aplicacion.Enums;
namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    private string? _passwordHash { get; set; }
    private string? _dni;
    private string? _nombre;
    private string? _apellido;
    private string? _email;
    private string? _telefono;    
    public List<PermisoUsuario> Permisos { get; set; } = new List<PermisoUsuario>();
    public List<EventoDeportivo> EventosOrganizados { get; set; } = new List<EventoDeportivo>();
    public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    private EstadoSolicitud _estadoSolicitud;
    public EstadoSolicitud EstadoSolicitud
    {
        get => _estadoSolicitud;
        set => _estadoSolicitud = value;
    }
    public string? PasswordHash
    {
        get => _passwordHash;
        set => _passwordHash = value;
    }

    public string? DNI
    {
        get => _dni;
        set => _dni = value;
    }

    public string? Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string? Apellido
    {
        get => _apellido;
        set => _apellido = value;
    }

    public string? Email
    {
        get => _email;
        set => _email = value;
    }

    public string? Telefono
    {
        get => _telefono;
        set => _telefono = value;
    }


    public override string ToString()
    {
        return $"{Id};{DNI};{Nombre};{Apellido};{Email};{Telefono}";
    }

}