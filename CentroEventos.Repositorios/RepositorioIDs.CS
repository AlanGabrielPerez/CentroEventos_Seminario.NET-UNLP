namespace CentroEventos.Repositorios;

public class RepositorioIDs{

    readonly string _rutaArchivo;

    public RepositorioIDs(string entidad)
    {
        string _carpetaArchivos = Path.Combine(Environment.CurrentDirectory,
                "..", "..", "..", "..",
                "CentroEventos.Repositorios", "Archivos");

        _rutaArchivo = Path.Combine(_carpetaArchivos, $"id_{entidad}.txt");
    }

    public int ObtenerSiguienteId()
    {
        int ultimoId = 0;

        using (var sr = new StreamReader(_rutaArchivo))
        {
            string? linea = sr.ReadLine();
            if (!string.IsNullOrEmpty(linea))
                int.TryParse(linea, out ultimoId);
        }

        int nuevoId = ultimoId + 1;

        using (var sw = new StreamWriter(_rutaArchivo, false))
        {
            sw.WriteLine(nuevoId);
        }

        return nuevoId;
    }

}