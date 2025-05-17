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

var personaRepo = new RepositorioPersona();
var validador = new PersonaValidador();
var useCase = new CrearPersonaUseCase();

try
{
    useCase.Ejecutar(persona, personaRepo, validador);
    Console.WriteLine("Persona creada con éxito.");
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}