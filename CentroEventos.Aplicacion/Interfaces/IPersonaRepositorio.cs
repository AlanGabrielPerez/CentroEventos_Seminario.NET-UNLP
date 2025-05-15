namespace CentroEventos.Aplicacion.Repositorios;

using CentroEventos.Aplicacion.Entidades;

public interface IPersonaRepositorio
{
    Persona ObtenerPorId(int id);

    Persona ObtenerPorDni(string dni);

    Persona ObtenerPorEmail(string email);

    List<Persona> ObtenerTodas();

    void Crear(Persona persona);

    void Actualizar(Persona persona);

    void Eliminar(int id);

    bool ExisteDni(string dni);

    bool ExisteEmail(string email);

    bool TieneReservas(int personaId);

}