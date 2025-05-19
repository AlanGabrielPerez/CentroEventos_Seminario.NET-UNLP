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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public bool ExisteDni(string? dni)
    {
        return false;
    }

    public bool ExisteEmail(string? email)
    {
        return false;
    }

    public Persona ObtenerPorDni(string dni)
    {
        throw new NotImplementedException();
    }

    public Persona ObtenerPorEmail(string email)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public bool TieneReservas(int personaId)
    {
        throw new NotImplementedException();
    }
}