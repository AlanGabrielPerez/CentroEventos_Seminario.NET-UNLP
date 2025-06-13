namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string? _password { get; set; }
    private string? _dni;
    private string? _nombre;
    private string? _apellido;
    private string? _email;
    private string? _telefono;
    public List<PermisoUsuario> Permisos { get; set; } = new List<PermisoUsuario>();
    
    public string? Password
    {
        get => _password;
        set => _password = value;
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