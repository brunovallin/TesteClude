using GestaoDeProfissionaisCludeAPI.Interfaces;
using GestaoDeProfissionaisCludeAPI.Services;
using GestaoDeProfissionaisPersistence;
using GestaoDeProfissionaisPersistence.Interface;
using GestaoDeProfissionaisPersistence.Persistencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
 context => context.UseSqlite(builder.Configuration.GetConnectionString("Default") 
        ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found."))
 );
 
builder.Services.AddScoped<IProfissionalService,ProfissionalService>();
builder.Services.AddScoped<IEspecialidadeService,EspecialidadeService>();
builder.Services.AddScoped<IPersistenciaGeral, GeralPersistencia>();
builder.Services.AddScoped<IProfissionalPersistencia,ProfissionalPersistencia>();
builder.Services.AddScoped<IEspecialidadePersistencia,EspecialidadePersistencia>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseCors(cors => cors.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
