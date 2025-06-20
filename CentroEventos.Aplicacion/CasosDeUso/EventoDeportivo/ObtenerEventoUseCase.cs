using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Entidades;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerEventoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth): EventoDeportivoUseCase(eventoRepo, auth)
{
  
    public EventoDeportivo Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.Lectura);

        var evento = _eventoRepo.ObtenerPorId(id);

        if (evento == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {id}.");

        return evento;
    
    }
}