using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public abstract class EventoDeportivoUseCase(IEventoDeportivoRepositorio eventoRepo, IServicioAutorizacion auth)
{
    protected readonly IServicioAutorizacion _auth = auth;
    protected readonly IEventoDeportivoRepositorio _eventoRepo = eventoRepo;
    protected void VerificarPermiso(int idUsuario, Permiso permiso)
    {
        if (!_auth.PoseeElPermiso(idUsuario, permiso))
            throw new FalloAutorizacionException($"No tiene permiso para {permiso}.");
    }
}