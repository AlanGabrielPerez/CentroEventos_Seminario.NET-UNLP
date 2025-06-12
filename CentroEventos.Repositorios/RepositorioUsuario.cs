using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio

{

    readonly string _rutaArchivo;
    public RepositorioUsuario()
    {
        string _carpetaArchivos = Path.Combine(Environment.CurrentDirectory,
                "..", "..", "..", "..",
                "CentroEventos.Repositorios", "Archivos");

        _rutaArchivo = Path.Combine(_carpetaArchivos, "personas.txt");
    }
    
    public void Actualizar(Usuario usuario)
    {
        var listaUsuarios = ObtenerTodas(); 
        int indice = listaUsuarios.FindIndex(p => p.Id == usuario.Id);
        if (indice == -1)
            throw new Exception($"No se encontro una Usuario con ID {usuario.Id}.");

        listaUsuarios[indice] = usuario;

        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var p in listaUsuarios)
            sw.WriteLine(p.ToString());
    }

    public void Crear(Usuario Usuario)
    {
        var repoID = new RepositorioGestorIDs("Usuario");
        Usuario.Id = repoID.ObtenerSiguienteId();
        using var sw = new StreamWriter(_rutaArchivo,true);
                
        sw.WriteLine(Usuario.ToString());
    }

    public void Eliminar(int id)
    {
        var ListaUsuarios = ObtenerTodas();
        ListaUsuarios.RemoveAll(p => p.Id == id);

        using var sw = new StreamWriter(_rutaArchivo, false);
        foreach (var Usuario in ListaUsuarios)
            sw.WriteLine(Usuario.ToString());
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

    public Usuario? ObtenerPorDni(string dni)
    {
        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var datos = linea.Split(';');
            if (datos.Length >= 6 && datos[1] == dni)
            {
                return new Usuario
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

    public Usuario? ObtenerPorEmail(string email)
    {
        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {  
            var linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;
            
            var datos = linea.Split(';');
            if (datos.Length >= 6 && datos[4] == email)
            {
                return new Usuario
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

    public Usuario? ObtenerPorId(int id)
    {

        using var sr = new StreamReader(_rutaArchivo);

        while (!sr.EndOfStream)
        {
            var linea = sr.ReadLine();
            if (linea == null) continue;
            
            var datos = linea.Split(';');
            if (int.TryParse(datos[0], out int UsuarioId) && UsuarioId == id)
            {
                return new Usuario
                {
                    Id = UsuarioId,
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

    public List<Usuario> ObtenerTodas()
    {
        var listaUsuarios = new List<Usuario>();
        using var sr = new StreamReader(_rutaArchivo);

    while (!sr.EndOfStream)
    {
        var linea = sr.ReadLine();
        if (string.IsNullOrWhiteSpace(linea)) continue;

        var datos = linea.Split(';');
        if (datos.Length >= 6)
        {
            var Usuario = new Usuario
            {
                Id = int.Parse(datos[0]),
                DNI = datos[1],
                Nombre = datos[2],
                Apellido = datos[3],
                Email = datos[4],
                Telefono = datos[5]
            };
            listaUsuarios.Add(Usuario);
        }
    }
        return listaUsuarios;
    }

}