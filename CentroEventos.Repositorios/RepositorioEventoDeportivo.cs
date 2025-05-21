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
        var listaEventos = ObtenerTodos();
        int indice = listaEventos.FindIndex(e => e.Id == evento.Id);
        if (indice == -1) throw new Exception($"No se encontró un evento con ID {evento.Id}.");
        listaEventos[indice] = evento;
        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var e in listaEventos)
            sw.WriteLine(e.ToString());
    }

    public void Agregar(EventoDeportivo evento)
    {
        var repoID = new RepositorioGestorIDs("eventoDeportivo");
        evento.Id = repoID.ObtenerSiguienteId();
        using var sw = new StreamWriter(_rutaArchivo,true);
        sw.WriteLine(evento.ToString());
    }

    public void Eliminar(int id)
    {
        var listaEventos = ObtenerTodos();
        listaEventos.RemoveAll(e => e.Id == id);
        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var e in listaEventos)
            sw.WriteLine(e.ToString());
    }

    public bool EsResponsableDeEventos(int personaId)
    {
        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (datos.Length >= 6 && int.TryParse(datos[5], out int responsableId)
                && responsableId == personaId)
            {
                return true;
            }
    }

    return false;
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (int.TryParse(datos[0], out int eventoId) && eventoId == id)
            {
                return new EventoDeportivo
                {
                    Id = eventoId,
                    Nombre = datos[1],
                    Descripcion = datos[2],
                    FechaHoraInicio = DateTime.Parse(datos[3]),
                    DuracionHoras = double.Parse(datos[4]),
                    CupoMaximo = int.Parse(datos[5]),
                    ResponsableId = int.Parse(datos[6])
                };
            }
        }
        return null;
    }

    public List<EventoDeportivo> ObtenerTodos()
    {
        var listaEventos = new List<EventoDeportivo>();
        using var sr = new StreamReader(_rutaArchivo);
       while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
           var datos = linea.Split(';');
            if (datos.Length >= 7)
            {
                var evento = new EventoDeportivo
                {
                    Id = int.Parse(datos[0]),
                    Nombre = datos[1],
                    Descripcion = datos[2],
                    FechaHoraInicio = DateTime.Parse(datos[3]),
                    DuracionHoras = double.Parse(datos[4]),
                    CupoMaximo = int.Parse(datos[5]),
                    ResponsableId = int.Parse(datos[6])
                };
                listaEventos.Add(evento);
            }
        }
        return listaEventos;
    }

}
