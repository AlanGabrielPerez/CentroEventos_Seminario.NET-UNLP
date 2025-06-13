namespace CentroEventos.Aplicacion.Entidades;

public enum Estado
{
    Pendiente,
    Aceptada,
    Rechazada
}
public class SolicitudUsuario : Usuario
{
    public Estado Estado { get; set; }
}