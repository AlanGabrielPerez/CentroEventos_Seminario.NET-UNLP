using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class CrearUsuarioUseCase(IUsuarioRepositorio UsuarioRepo, IServicioAutorizacion auth, UsuarioValidador validador) : UsuarioUseCase(UsuarioRepo, auth)
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
            CrearAdmin(usuario);
        else
        {
            usuario.EstadoSolicitud = EstadoSolicitud.Pendiente;
            _UsuarioRepo.Crear(usuario);
        }
    }

    private void CrearAdmin(Usuario usuario)
    {
        usuario.EstadoSolicitud = EstadoSolicitud.Aceptada;
        _UsuarioRepo.Crear(usuario);

        var permisos = new[]
        {
            Permiso.Administrador,
            Permiso.Lectura,
            Permiso.UsuarioAlta,
            Permiso.UsuarioBaja,
            Permiso.UsuarioModificacion,
            Permiso.ReservaAlta,
            Permiso.ReservaBaja,
            Permiso.ReservaModificacion,
            Permiso.EventoAlta,
            Permiso.EventoBaja,
            Permiso.EventoModificacion
        };

        foreach (var permiso in permisos)
        {
            var nuevoPermiso = new PermisoUsuario
            {
                UsuarioId = 1,
                Permiso = permiso
            };
            _auth.AgregarPermisoUsuario(nuevoPermiso);
            usuario.Permisos.Add(nuevoPermiso);
        }
    }
}
