using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;


public class ListarEventosDeportivosUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth): EventoDeportivoUseCase(eventoRepo, auth)
{
    public List<EventoDeportivo> Ejecutar(int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.Lectura);
        return _eventoRepo.ObtenerTodos();
    }
}