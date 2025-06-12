using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

public class UsuarioValidador
{
    public bool Validar(
        Usuario Usuario,
        IUsuarioRepositorio UsuarioRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(Usuario.Nombre))
            mensajeError += "El nombre no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(Usuario.Apellido))
            mensajeError += "El apellido no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(Usuario.DNI))
            mensajeError += "El DNI no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(Usuario.Email))
            mensajeError += "El email no puede estar vacío.\n";

        return string.IsNullOrEmpty(mensajeError);
    }

    public bool ValidarDuplicados(
        Usuario Usuario,
        IUsuarioRepositorio UsuarioRepo,
        out string mensajeError)
    {
        mensajeError = "";

        if (UsuarioRepo.ExisteDni(Usuario.DNI))
            mensajeError += $"Ya existe una Usuario con el DNI {Usuario.DNI}.\n";

        if (UsuarioRepo.ExisteEmail(Usuario.Email))
            mensajeError += $"Ya existe una Usuario con el email {Usuario.Email}.\n";

        return string.IsNullOrEmpty(mensajeError);
    }
    
}
