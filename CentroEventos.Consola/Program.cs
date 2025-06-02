using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Consola.Menus;

IPersonaRepositorio personaRepo = new RepositorioPersona();
IEventoDeportivoRepositorio eventoRepo = new RepositorioEventoDeportivo();
IReservaRepositorio reservaRepo = new RepositorioReserva();

var personaValidador = new PersonaValidador();
var eventoValidador = new EventoDeportivoValidador();
var reservaValidador = new ReservaValidador();

IServicioAutorizacion auth = new ServicioAutorizacionProvisorio();

 
/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */



int idUsuario = -1;

while (idUsuario == -1)
{   
    Console.Write("Email: ");
    string email = Console.ReadLine()?.Trim() ?? "";
    Console.Write("DNI: ");
    string dni = Console.ReadLine()?.Trim() ?? "";

    var persona = personaRepo.ObtenerPorEmail(email);
    if (persona != null && persona.DNI==dni)
    {
        idUsuario = persona.Id;
        Console.WriteLine($"Bienvenido {persona.Nombre} {persona.Apellido}\n");
    }
    else
    {
        Console.WriteLine("intente de nuevo.\n");
    }
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */


bool salir = false;
while (!salir)
{
    Console.WriteLine("1. Gestión de Personas");
    Console.WriteLine("2. Gestión de Eventos Deportivos");
    Console.WriteLine("3. Gestión de Reservas");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine() ?? "";


    switch (opcion)
    {
        case "1":
            new MenuPersonas(idUsuario, personaRepo, personaValidador, auth).Ejecutar();
            break;
        case "2":
            MenuEventos.Ejecutar(idUsuario, eventoRepo, eventoValidador, personaRepo, auth);
            break;
        case "3":
            MenuReservas.Ejecutar(idUsuario, reservaRepo, reservaValidador, personaRepo, eventoRepo, auth);
            break;
        case "0":
            salir = true;
            Console.WriteLine("Ejecución finalizada.");
            break;
        default:
            Console.WriteLine("Opción invalida. Intente de nuevo.\n");
            break;
    }
}