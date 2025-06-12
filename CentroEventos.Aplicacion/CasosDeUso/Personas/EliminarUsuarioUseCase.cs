using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarUsuarioUseCase(IUsuarioRepositorio UsuarioRepo,
            IServicioAutorizacion auth,IEventoDeportivoRepositorio eventoRepo,
        IReservaRepositorio reservaRepo) : UsuarioUseCase(UsuarioRepo,auth)
{
    private readonly IEventoDeportivoRepositorio _eventoRepo = eventoRepo;
    private readonly IReservaRepositorio _reservaRepo = reservaRepo;

    public void Ejecutar(int id, int idUsuario)
    {
        VerificarPermiso(idUsuario, Permiso.UsuarioBaja);

        var Usuario = _UsuarioRepo.ObtenerPorId(id);
        if (Usuario == null)
            throw new EntidadNotFoundException($"No se encontró una Usuario con ID {id}.");

        bool tieneEventos = _eventoRepo.EsResponsableDeEventos(id);
        bool tieneReservas = _reservaRepo.TieneReservasAsociadas(id);

        if (tieneEventos || tieneReservas)
            throw new OperacionInvalidaException("No se puede eliminar la Usuario porque tiene dependencias.");

        _UsuarioRepo.Eliminar(id);
    }
}