namespace CentroEventos.Repositorios;
public static class CentroEventosDbInitializer
{
    public static void Inicializar()
    {
        using var context = new CentroEventoContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("base de datos creada.");
        }
    }
}
