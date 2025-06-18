using Microsoft.EntityFrameworkCore;

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

        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }

    }
}
