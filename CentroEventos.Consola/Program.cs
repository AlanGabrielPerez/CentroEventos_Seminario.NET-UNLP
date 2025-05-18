using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Repositorios;

var persona = new Persona
{
    Id = 1,
    DNI = "222920",
    Nombre = "Alan",
    Apellido = "Perez",
    Email = "alanPerez@mail.com",
    Telefono = "221222920"
};
var evento = new EventoDeportivo
{
    Id = 1,
    Nombre = "Yoga",
    Descripcion = "Clase de yoga funcional",
    FechaHoraInicio =new DateTime(2025, 6, 1, 15, 30, 00),
    DuracionHoras = 5,
    CupoMaximo= 30,
    ResponsableId = 1, 
};


var personaRepo = new RepositorioPersona();
var validadorPersona = new PersonaValidador();
var useCasePersona = new CrearPersonaUseCase();
var eventoRepo = new RepositorioEventoDeportivo();
var validadorEvento = new EventoDeportivoValidador();
var useCaseEvento = new CrearEventoDeportivoUseCase();


try
{
    useCasePersona.Ejecutar(persona, personaRepo, validadorPersona);
    Console.WriteLine("Persona creada con éxito.");
    useCaseEvento.Ejecutar(evento, eventoRepo, personaRepo, validadorEvento);
    Console.WriteLine("Evento creado");
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}