using CentroEventos.Aplicacion.Entidades;


namespace CentroEventos.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    Usuario? ObtenerPorId(int id);

    Usuario? ObtenerPorDni(string dni);

    Usuario? ObtenerPorEmail(string email);

    List<Usuario> ObtenerTodas();

    void Crear(Usuario usuario);

    void Actualizar(Usuario usuario);

    void Eliminar(int id);

    bool ExisteDni(string? dni);

    bool ExisteEmail(string? email);

}