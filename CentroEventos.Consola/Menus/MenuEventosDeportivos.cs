using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Consola.Menus;

public static class MenuEventos
{
    public static void Ejecutar(
        int idUsuario,
        IEventoDeportivoRepositorio eventoRepo,
        EventoDeportivoValidador validador,
        IPersonaRepositorio personaRepo,
        IServicioAutorizacion auth)
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("1. Crear evento deportivo");
            Console.WriteLine("2. Listar eventos deportivos");
            Console.WriteLine("3. Modificar evento deportivo");
            Console.WriteLine("4. Eliminar evento deportivo");
            Console.WriteLine("0. Volver al menu principal");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine() ?? "";
           

            switch (opcion)
            {
                case "1":
                    throw new NotImplementedException();
                case "2":
                    throw new NotImplementedException();
                case "3":
                    throw new NotImplementedException();
                case "4":
                    throw new NotImplementedException();
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opcion invalida. Intente de nuevo\n");
                    break;
            }
        }
    }
}