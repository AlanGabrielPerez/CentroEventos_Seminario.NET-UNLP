using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ActualizarUsuarioUseCase(IUsuarioRepositorio UsuarioRepo,
            IServicioAutorizacion auth, UsuarioValidador validador) : UsuarioUseCase(UsuarioRepo,auth)
{
    private readonly UsuarioValidador _validador = validador;

    public void Ejecutar(Usuario Usuario, int idSesion)
    {
        if (Usuario.Id != idSesion)
        {
            VerificarPermiso(idSesion, Permiso.UsuarioModificacion);
        }
        if (!_validador.Validar(Usuario, out string mensajeError))
            throw new ValidacionException(mensajeError);

        _UsuarioRepo.Actualizar(Usuario);
    }
}