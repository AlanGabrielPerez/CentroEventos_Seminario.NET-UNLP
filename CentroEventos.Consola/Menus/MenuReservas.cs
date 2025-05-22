using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Consola.Menus;

public static class MenuReservas
{
    public static void Ejecutar(
        int idUsuario,
        IReservaRepositorio reservaRepo,
        ReservaValidador validador,
        IPersonaRepositorio personaRepo,
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth)
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("1. Crear reserva");
            Console.WriteLine("2. Listar reservas");
            Console.WriteLine("3. Modificar reserva");
            Console.WriteLine("4. Eliminar reserva");
            Console.WriteLine("5. Listar eventos con cupo disponible");
            Console.WriteLine("6. Listar asistentes a evento pasado");
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
                case "5":
                    throw new NotImplementedException();
                case "6":
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