using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IReservaRepositorio
{
    readonly string _rutaArchivo;
    public RepositorioReserva()
    {
        string _carpetaArchivos = Path.Combine(Environment.CurrentDirectory,
                "..", "..", "..", "..",
                "CentroEventos.Repositorios", "Archivos");

        _rutaArchivo = Path.Combine(_carpetaArchivos, "reserva.txt");
    }

    public void Crear(Reserva reserva)
    {
        var repoID = new RepositorioGestorIDs("reserva");
        reserva.Id = repoID.ObtenerSiguienteId();
        using var sw = new StreamWriter(_rutaArchivo,true);
        sw.WriteLine(reserva.ToString());
    }

    public void Eliminar(int id)
    {
        var listaReservas = ObtenerTodas();
        listaReservas.RemoveAll(r => r.Id == id);
        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var r in listaReservas)
            sw.WriteLine(r.ToString());
    }

    public void Modificar(Reserva reserva)
    {
        var reservas = ObtenerTodas();
        int indice = reservas.FindIndex(r => r.Id == reserva.Id);
        if (indice == -1) throw new Exception($"No se encontró la reserva con ID {reserva.Id}.");
        reservas[indice] = reserva;
        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var r in reservas)
            sw.WriteLine(r.ToString());
    }

    public Reserva? ObtenerPorId(int id)
    {
        using var sr = new StreamReader(_rutaArchivo);
        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (int.TryParse(datos[0], out int reservaId) && reservaId == id)
            {
                return new Reserva
                {
                    Id = reservaId,
                    PersonaId = int.Parse(datos[1]),
                    EventoDeportivoId = int.Parse(datos[2]),
                    FechaAltaReserva = DateTime.Parse(datos[3]),
                    EstadoAsistencia = Enum.Parse<EstadoAsistencia>(datos[4])
                };
            }
        }
        return null;
    }

    public bool EventoTieneReservas(int eventoId)
    {
        using var sr = new StreamReader(_rutaArchivo);
        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (datos.Length >= 3 && int.Parse(datos[2]) == eventoId)
                return true;
        }
       return false;
    }

    public int ContarReservasDeEvento(int eventoId)
    {
        int contador = 0;
        using var sr = new StreamReader(_rutaArchivo);
        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (datos.Length >= 3 && int.Parse(datos[2]) == eventoId)
                contador++;
        }   
        return contador;
    }

    public bool ExisteReserva(int personaId, int eventoId)
    {
        using var sr = new StreamReader(_rutaArchivo);
        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (datos.Length >= 3 && int.Parse(datos[1]) == personaId &&
                int.Parse(datos[2]) == eventoId)
            {
                return true;
            }
        }
        return false;
    }

    public bool TieneReservasAsociadas(int personaId)
    {
        using var sr = new StreamReader(_rutaArchivo);
        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (datos.Length >= 2 && int.Parse(datos[1]) == personaId)
                return true;
        }
        return false;
    }

    public List<Reserva> ObtenerTodas()
    {
        var listaReservas = new List<Reserva>();
        using var sr = new StreamReader(_rutaArchivo);
        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var datos = linea.Split(';');
            if (datos.Length >= 5)
            {
                var reserva = new Reserva
                {
                    Id = int.Parse(datos[0]),
                    PersonaId = int.Parse(datos[1]),
                    EventoDeportivoId = int.Parse(datos[2]),
                    FechaAltaReserva = DateTime.Parse(datos[3]),
                    EstadoAsistencia = Enum.Parse<EstadoAsistencia>(datos[4])
                };
                listaReservas.Add(reserva);
            }
        }
        return listaReservas;
    }

    public List<Reserva> ObtenerPorPersonaId(int personaId)
    {
        return ObtenerTodas().Where(r => r.PersonaId == personaId).ToList();
    }

    public List<Reserva> ObtenerPorEventoId(int eventoId)
    {
       return ObtenerTodas().Where(r => r.EventoDeportivoId == eventoId).ToList();
    }

}
