using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearUsuarioUseCase(IUsuarioRepositorio UsuarioRepo, IServicioAutorizacion auth, UsuarioValidador validador) : UsuarioUseCase(UsuarioRepo,auth)
{
    private readonly UsuarioValidador _validador = validador;

    public void Ejecutar(Usuario usuario)
    {
        if (!_validador.Validar(usuario, out string mensajeError))
                throw new ValidacionException(mensajeError);

        if (!_validador.ValidarDuplicados(usuario, out mensajeError))
               throw new DuplicadoException(mensajeError);

        if (usuario.PasswordHash != null)
            usuario.PasswordHash = ServicioHash.ConvertirASha256(usuario.PasswordHash);
        
        if (_UsuarioRepo.ObtenerPorId(1) == null)
        {
            usuario.EstadoSolicitud = EstadoSolicitud.Aceptada;
            _UsuarioRepo.Crear(usuario);

            foreach (Permiso permiso in Enum.GetValues(typeof(Permiso)))
            {
                var _permisoUsuario = new PermisoUsuario
                {
                    UsuarioId = usuario.Id,
                    Permiso = permiso
                };
                _auth.AgregarPermisoUsuario(_permisoUsuario);
                usuario.Permisos.Add(_permisoUsuario);
            }
        }

        else
        {

            usuario.EstadoSolicitud = EstadoSolicitud.Pendiente;

            _UsuarioRepo.Crear(usuario);
        }
    }
}
