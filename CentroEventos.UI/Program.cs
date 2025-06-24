using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios; 
using CentroEventos.Repositorios;

using CentroEventos.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<CentroEventoContext>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<IEventoDeportivoRepositorio, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IReservaRepositorio, RepositorioReserva>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionRepositorio>();
builder.Services.AddScoped<ISesionUsuario, SesionUsuario>();

//validadores
builder.Services.AddScoped<EventoDeportivoValidador>();
builder.Services.AddScoped<UsuarioValidador>();
builder.Services.AddScoped<ReservaValidador>();


builder.Services.AddScoped<LoginUseCase>();


//casos de uso usuario
builder.Services.AddTransient<CrearUsuarioUseCase>();
builder.Services.AddScoped<ActualizarUsuarioUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<ListarSolicitudesUsuarioPendientesUseCase>();
builder.Services.AddScoped<AceptarUsuarioUseCase>();
builder.Services.AddScoped<RechazarUsuarioUseCase>();
builder.Services.AddScoped<EliminarUsuarioUseCase>();

//casos de uso permisos
builder.Services.AddScoped<OtorgarPermisoUseCase>();
builder.Services.AddScoped<EliminarPermisoUseCase>();
builder.Services.AddScoped<VerificarPermisosUseCase>();

//casos de uso evento
builder.Services.AddScoped<CrearEventoDeportivoUseCase>();
builder.Services.AddScoped<ListarEventosDeportivosUseCase>();
builder.Services.AddScoped<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddScoped<ObtenerEventoUseCase>();

//casos de uso reserva
builder.Services.AddScoped<CrearReservaUseCase>();
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ListarReservasUseCase>();
builder.Services.AddScoped<ListarSolicitudesReservaPendientesUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


CentroEventosDbInitializer.Inicializar();

app.Run();
