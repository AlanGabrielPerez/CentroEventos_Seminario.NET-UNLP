using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearUsuarioUseCase(IUsuarioRepositorio UsuarioRepo, IServicioAutorizacion auth, UsuarioValidador validador) : UsuarioUseCase(UsuarioRepo,auth)
{
    private readonly UsuarioValidador _validador = validador;

    public void Ejecutar(Usuario Usuario,int idUsuario)
    {
       VerificarPermiso(idUsuario, Permiso.UsuarioAlta);

        if (!_validador.Validar(Usuario, _UsuarioRepo, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(Usuario, _UsuarioRepo, out mensajeError))
            throw new DuplicadoException(mensajeError);

        _UsuarioRepo.Crear(Usuario);
    }
}
