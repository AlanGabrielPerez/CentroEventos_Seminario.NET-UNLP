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

// use cases
builder.Services.AddScoped<UsuarioValidador>();
builder.Services.AddTransient<CrearUsuarioUseCase>();
builder.Services.AddTransient<LoginUseCase>();


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
