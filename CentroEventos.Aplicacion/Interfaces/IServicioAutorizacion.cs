using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
        void AgregarPermisoUsuario(PermisoUsuario permisoUsuario);
        void EliminarPermisoUsuario(int idPermisoUsuario);
        bool PoseeElPermiso(int idUsuario, Permiso permiso);
        PermisoUsuario? ObtenerPermisoPorId(int idPermisoUsuario);
        int ObtenerIdPorUsuarioYPermiso(int idUsuario, Permiso permiso);


}