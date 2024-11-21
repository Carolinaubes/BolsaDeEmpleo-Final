using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Comunicaciones
            services.AddScoped<IVacantesComunicacion, VacantesComunicacion>();
            services.AddScoped<IRolesComunicacion, RolesComunicacion>();
            services.AddScoped<IPostulacionesComunicacion, PostulacionesComunicacion>();
            services.AddScoped<IPersonas_EstudiosComunicacion, Personas_EstudiosComunicacion>();
            services.AddScoped<IPersonasComunicacion, PersonasComunicacion>();
            services.AddScoped<IEstudiosComunicacion, EstudiosComunicacion>();
            services.AddScoped<IEmpresasComunicacion, EmpresasComunicacion>();
            services.AddScoped<ICargos_EstudiosComunicacion, Cargos_EstudiosComunicacion>();
            services.AddScoped<ICargosComunicacion, CargosComunicacion>();
            services.AddScoped<IAuditoriasComunicacion, AuditoriasComunicacion>(); 

            // Presentaciones
            services.AddScoped<IVacantesPresentacion, VacantesPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IPostulacionesPresentacion, PostulacionesPresentacion>();
            services.AddScoped<IPersonas_EstudiosPresentacion, Personas_EstudiosPresentacion>();
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IEstudiosPresentacion, EstudiosPresentacion>();
            services.AddScoped<IEmpresasPresentacion, EmpresasPresentacion>();
            services.AddScoped<ICargos_EstudiosPresentacion, Cargos_EstudiosPresentacion>();
            services.AddScoped<ICargosPresentacion, CargosPresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>(); 

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}