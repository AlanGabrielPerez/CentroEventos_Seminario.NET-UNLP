using CentroEventos.Aplicacion.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public abstract class RepositorioDbContext(CentroEventoContext context)
{
    protected readonly CentroEventoContext _context = context;

    public void Create<T>(T entidad) where T : class
    {
        _context.Set<T>().Add(entidad);
        _context.SaveChanges();
    }

    public void Update<T>(T entidad) where T : class
    {
        _context.Set<T>().Update(entidad);
        _context.SaveChanges();
    }

    public void Delete<T>(T entidad) where T : class
    {
        _context.Set<T>().Remove(entidad);
        _context.SaveChanges();
    }

    public List<T> GetAll<T>() where T : class
    {
        return _context.Set<T>().ToList();
    }

    public T? GetByID<T>(int id) where T : class
    {
        return _context.Set<T>().Find(id) ?? throw new EntidadNotFoundException(typeof(T).Name + " con ID " + id + " no encontrada.");
    }

    public void GuardarCambios()
    {
        _context.SaveChanges();
    }
}