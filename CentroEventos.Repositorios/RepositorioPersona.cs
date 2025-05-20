using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IPersonaRepositorio

{

    readonly string _rutaArchivo;
    public RepositorioPersona()
    {
        string _carpetaArchivos = Path.Combine(Environment.CurrentDirectory,
                "..", "..", "..", "..",
                "CentroEventos.Repositorios", "Archivos");

        _rutaArchivo = Path.Combine(_carpetaArchivos, "personas.txt");
    }
    

    public void Actualizar(Persona persona)
    {
        var listaPersonas = ObtenerTodas(); 
        int indice = listaPersonas.FindIndex(p => p.Id == persona.Id);
        if (indice == -1)
            throw new Exception($"No se encontro una persona con ID {persona.Id}.");

        listaPersonas[indice] = persona;

        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var p in listaPersonas)
            sw.WriteLine(p.ToString());
    }

    public void Crear(Persona persona)
    {
        var repoID = new RepositorioIDs("persona");
        persona.Id = repoID.ObtenerSiguienteId();
        using var sw = new StreamWriter(_rutaArchivo,true);
                
        sw.WriteLine(persona.ToString());
    }

    public void Eliminar(int id)
    {
        var ListaPersonas = ObtenerTodas();
        ListaPersonas.RemoveAll(p => p.Id == id);

        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var persona in ListaPersonas)
            sw.WriteLine(persona.ToString());
    }

    public bool ExisteDni(string? dni)
    {
        if (string.IsNullOrWhiteSpace(dni)) return false;

        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (linea == null) continue;
            var datos = linea.Split(';');
            if (datos.Length > 1 && datos[1] == dni) return true;
        }
        return false;
    }

    public bool ExisteEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;

        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (linea == null) continue;
            var datos = linea.Split(';');
            if (datos.Length > 4 && datos[4] == email) return true;
        }
        return false;
    }

    public Persona? ObtenerPorDni(string dni)
    {
        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var datos = linea.Split(';');
            if (datos.Length >= 6 && datos[1] == dni)
            {
                return new Persona
                {
                    Id = int.Parse(datos[0]),
                    DNI = datos[1],
                    Nombre = datos[2],
                    Apellido = datos[3],
                    Email = datos[4],
                    Telefono = datos[5]
                };
            }
        }
        return null;
    }

    public Persona? ObtenerPorEmail(string email)
    {
        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {  
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            
            var datos = linea.Split(';');
            if (datos.Length >= 6 && datos[4] == email)
            {
                return new Persona
                {
                    Id = int.Parse(datos[0]),
                    DNI = datos[1],
                    Nombre = datos[2],
                    Apellido = datos[3],
                    Email = datos[4],
                    Telefono = datos[5]
                };
            }
        }
        return null;
    }

    public Persona? ObtenerPorId(int id)
    {

        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (linea == null) continue;
            
            var datos = linea.Split(';');
            if (int.TryParse(datos[0], out int personaId) && personaId == id)
            {
                return new Persona
                {
                    Id = personaId,
                    DNI = datos[1],
                    Nombre = datos[2],
                    Apellido = datos[3],
                    Email = datos[4],
                    Telefono = datos[5]
                };
            }
        }

        return null;
    }

    public List<Persona> ObtenerTodas()
    {
        var listaPersonas = new List<Persona>();
        using var sr = new StreamReader(_rutaArchivo);

    while (!sr.EndOfStream)
    {
        var linea = sr.ReadLine();
        if (string.IsNullOrWhiteSpace(linea)) continue;

        var datos = linea.Split(';');
        if (datos.Length >= 6)
        {
            var persona = new Persona
            {
                Id = int.Parse(datos[0]),
                DNI = datos[1],
                Nombre = datos[2],
                Apellido = datos[3],
                Email = datos[4],
                Telefono = datos[5]
            };
            listaPersonas.Add(persona);
        }
    }
        return listaPersonas;
    }

}