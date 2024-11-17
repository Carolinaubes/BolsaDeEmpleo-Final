using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup //Este resuelve la inyeccion de dependencias del lado del servidor
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Inyecciones que requiero hacer: Repositorio necesita Conexion (la inyecto), aplicacion necesita Repositorio (la inyecto), el controlador
            //necesita aplicacion y token (los inyecto)

            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IEstudiosRepositorio, EstudiosRepositorio>();
            services.AddScoped<IEmpresasRepositorio, EmpresasRepositorio>();
            services.AddScoped<ICargosRepositorio, CargosRepositorio>();
            services.AddScoped<ICargos_EstudiosRepositorio, Cargos_EstudiosRepositorio>();
            services.AddScoped<IPersonas_EstudiosRepositorio, Personas_EstudiosRepositorio>();
            services.AddScoped<IPersonasRepositorio, PersonasRepositorio>();
            services.AddScoped<IPostulacionesRepositorio, PostulacionesRepositorio>();
            services.AddScoped<IRolesRepositorio, RolesRepositorio>();
            services.AddScoped<IAccionesRepositorio, AccionesRepositorio>();
            services.AddScoped<IAuditoriasRepositorio, AuditoriasRepositorio>();

            // Aplicaciones
            services.AddScoped<IEstudiosAplicacion, EstudiosAplicacion>();
            services.AddScoped<IEmpresasAplicacion, EmpresasAplicacion>();
            services.AddScoped<ICargosAplicacion, CargosAplicacion>();
            services.AddScoped<ICargos_EstudiosAplicacion, Cargos_EstudiosAplicacion>();
            services.AddScoped<IPersonas_EstudiosAplicacion, Personas_EstudiosAplicacion>();
            services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
            services.AddScoped<IPostulacionesAplicacion, PostulacionesAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IAccionesAplicacion, AccionesAplicacion>();
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}