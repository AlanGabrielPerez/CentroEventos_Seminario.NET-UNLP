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
                    ListarPersonas(_personaRepo);
                    break;
                case "3":
                    ModificarPersona(_idUsuario, _personaRepo, _validador, _auth);
                    break;
                case "4":
                    EliminarPersona(_idUsuario, _personaRepo, _auth);
                    break;
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
            Console.WriteLine("Persona creada exitosamente.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void ListarPersonas(IPersonaRepositorio _personaRepo)
    {
        try
        {
            var personas = _personaRepo.ObtenerTodas();
            if (personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            Console.WriteLine("Lista de personas:");
            foreach (var persona in personas)
            {
                Console.WriteLine($"ID: {persona.Id}, Nombre: {persona.Nombre}, Apellido: {persona.Apellido}, DNI: {persona.DNI}, Email: {persona.Email}, Telefono: {persona.Telefono}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar personas: {ex.Message}");
        }
    }

    public static void ModificarPersona(int _idUsuario,
        IPersonaRepositorio _personaRepo,
        PersonaValidador _validador,
        IServicioAutorizacion _auth)
    {
        try
        {
            if (!_auth.PoseeElPermiso(_idUsuario, Permiso.UsuarioModificacion))
                throw new FalloAutorizacionException("No tiene permiso para modificar personas.");

            Console.Write("Ingrese el ID de la persona a modificar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var persona = _personaRepo.ObtenerPorId(id);
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada.");
                return;
            }

            Console.WriteLine("Ingrese los nuevos datos de la persona (deje en blanco para no modificar):");
            Console.Write($"Nombre ({persona.Nombre}): ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write($"Apellido ({persona.Apellido}): ");
            string apellido = Console.ReadLine() ?? "";
            Console.Write($"DNI ({persona.DNI}): ");
            string dni = Console.ReadLine() ?? "";
            Console.Write($"Email ({persona.Email}): ");
            string email = Console.ReadLine() ?? "";
            Console.Write($"Telefono ({persona.Telefono}): ");
            string telefono = Console.ReadLine() ?? "";

            if (!string.IsNullOrEmpty(nombre)) persona.Nombre = nombre;
            if (!string.IsNullOrEmpty(apellido)) persona.Apellido = apellido;
            if (!string.IsNullOrEmpty(dni)) persona.DNI = dni;
            if (!string.IsNullOrEmpty(email)) persona.Email = email;
            if (!string.IsNullOrEmpty(telefono)) persona.Telefono = telefono;

            new ActualizarPersonaUseCase(_personaRepo, _validador).Ejecutar(persona);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void EliminarPersona(int _idUsuario,
        IPersonaRepositorio _personaRepo,
        IServicioAutorizacion _auth)
    {
        try
        {
            if (!_auth.PoseeElPermiso(_idUsuario, Permiso.UsuarioBaja))
                throw new FalloAutorizacionException("No tiene permiso para eliminar personas.");
            Console.Write("Ingrese el ID de la persona a eliminar: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var persona = _personaRepo.ObtenerPorId(id);
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada.");
                return;
            }
            _personaRepo.Eliminar(id);
            Console.WriteLine("Persona eliminada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}