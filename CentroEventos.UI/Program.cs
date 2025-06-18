using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<CentroEventoContext>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<IEventoDeportivoRepositorio, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IReservaRepositorio, RepositorioReserva>();
builder.Services.AddScoped<ISolicitudUsuarioRepositorio, RepositorioSolicitudUsuario>();
builder.Services.AddScoped<ISolicitudReservaRepositorio, RepositorioSolicitudReserva>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacionRepositorio>();




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

app.Run();
