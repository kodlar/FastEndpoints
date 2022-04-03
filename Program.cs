using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder();

builder.Logging.ClearProviders();
ILogger logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .CreateLogger();

builder.Logging.AddSerilog(logger);
builder.Services.AddSingleton(logger);

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(z => z.ConfigureDefaults());
app.Run();
