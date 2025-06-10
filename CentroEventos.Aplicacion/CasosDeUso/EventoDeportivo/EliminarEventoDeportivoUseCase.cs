using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarEventoDeportivoUseCase(
        IEventoDeportivoRepositorio eventoRepo,
        IServicioAutorizacion auth,
        IReservaRepositorio reservaRepo): EventoDeportivoUseCase(eventoRepo, auth)
{
    private readonly IReservaRepositorio _reservaRepo = reservaRepo;


    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.EventoBaja);

       var evento = _eventoRepo.ObtenerPorId(id);
       
        if (evento == null)
            throw new EntidadNotFoundException($"No se encontró un evento con ID {id}.");

        if (_reservaRepo.EventoTieneReservas(id))
            throw new OperacionInvalidaException("No se puede eliminar un evento con reservas asociadas.");

        _eventoRepo.Eliminar(id);
    }
}