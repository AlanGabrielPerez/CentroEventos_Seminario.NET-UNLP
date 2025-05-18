using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IEventoDeportivoRepositorio
{

    readonly string _rutaArchivo;
    public RepositorioEventoDeportivo()
    {
        string _carpetaArchivos = Path.Combine(Environment.CurrentDirectory,
                "..", "..", "..", "..",
                "CentroEventos.Repositorios", "Archivos");

        _rutaArchivo = Path.Combine(_carpetaArchivos, "eventoDeportivo.txt");
    }
    public void Actualizar(EventoDeportivo evento)
    {
        throw new NotImplementedException();
    }

    public void Agregar(EventoDeportivo evento)
    {
        using var sw = new StreamWriter(_rutaArchivo,true);
        sw.WriteLine(evento.ToString());
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public bool EsResponsableDeEventos(int personaId)
    {
        return false;
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> ObtenerTodos()
    {
        throw new NotImplementedException();
    }

    public bool TieneReservasAsociadas(int eventoId)
    {
        return false;
    }
}
