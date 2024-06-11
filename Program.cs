// Importación del espacio de nombres necesario para el código
using ControlBiblioteca;
using Microsoft.AspNetCore.Hosting;

// Creación de un nuevo constructor para la aplicación web utilizando la clase WebApplication
var builder = WebApplication.CreateBuilder(args);

// Creación de una nueva instancia de la clase Startup, que se encarga de configurar la aplicación
var startup = new Startup(builder.Configuration);

// Llamada al método ConfigureServices de la clase Startup para configurar los servicios de la aplicación
startup.ConfigureServices(builder.Services);

// Construcción de la aplicación
var app = builder.Build();

// Llamada al método Configure de la clase Startup para configurar la aplicación y el entorno de ejecución
startup.Configure(app, app.Environment);

// Ejecución de la aplicación
app.Run();