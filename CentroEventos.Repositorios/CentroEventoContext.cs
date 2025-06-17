using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class CentroEventoContext : DbContext
{
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<SolicitudUsuario> SolicitudesUsuario { get; set; }
    public DbSet<PermisoUsuario> PermisosUsuario { get; set; }
    public DbSet<SolicitudReserva> SolicitudesReservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CentroEventos.sqlite");
    }

}