using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class VerificarPermisosUseCase(IServicioAutorizacion auth)
{
    private readonly IServicioAutorizacion _auth = auth;

    public bool Ejecutar(int idUsuario, Permiso permiso) => _auth.PoseeElPermiso(idUsuario, permiso);

}