namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int Id { get; set; }

    private string? _nombre;
    private string? _descripcion;

    private int _cupoMaximo;


    public string? Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }

    public DateTime FechaHoraInicio { get; set; }

    public double DuracionHoras { get; set; }

    public int CupoMaximo
    {
        get => _cupoMaximo;
        set => _cupoMaximo = value;
    }

    public int ResponsableId { get; set; }

    public override string ToString()
    {
        return $"{Id};{Nombre};{Descripcion};{FechaHoraInicio:yyyy-MM-ddTHH:mm:ss};{DuracionHoras};{CupoMaximo};{ResponsableId}";
    }

    public Usuario Responsable { get; set; } = null!;

    public List<Reserva> Reservas { get; set; } = new List<Reserva>();

}