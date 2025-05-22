using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Consola.Menus;

public static class MenuPersonas
{
    public static void Ejecutar(
        int idUsuario,
        IPersonaRepositorio personaRepo,
        PersonaValidador validador,
        IServicioAutorizacion auth)
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("1. Crear persona");
            Console.WriteLine("2. Listar personas");
            Console.WriteLine("3. Modificar persona");
            Console.WriteLine("4. Eliminar persona");
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
                    Console.WriteLine("Opcion invalida.Intente de nuevo\n");
                    break;
            }
        }
    }
}