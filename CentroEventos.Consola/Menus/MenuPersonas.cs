using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Consola.Menus;

public class MenuPersonas(int idUsuario,
    IPersonaRepositorio personaRepo,
    PersonaValidador validador,
    IServicioAutorizacion auth)
{
    private readonly IPersonaRepositorio _personaRepo = personaRepo;
    private readonly PersonaValidador _validador = validador;
    private readonly IServicioAutorizacion _auth = auth;
    private readonly int _idUsuario = idUsuario;

    public void Ejecutar()
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
                    CrearPersona(_idUsuario, _personaRepo, _validador, _auth);
                    break;
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

    public static void CrearPersona(int _idUsuario,
        IPersonaRepositorio _personaRepo,
        PersonaValidador _validador,
        IServicioAutorizacion _auth)
    {
        try
        {
            if (!_auth.PoseeElPermiso(_idUsuario, Permiso.UsuarioAlta))
                throw new FalloAutorizacionException("No tiene permiso para crear personas.");

            Console.WriteLine("Ingrese los datos de la persona:");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine() ?? "";
            Console.Write("DNI: ");
            string dni = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Telefono: ");
            string telefono = Console.ReadLine() ?? "";

            Persona persona = new Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                DNI = dni,
                Email = email,
                Telefono = telefono
            };

            new CrearPersonaUseCase(_personaRepo, _validador).Ejecutar(persona);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }



}