using ApiProyectoConjuntoAWSRedSocial.Data;
using ApiProyectoConjuntoAWSRedSocial.Helpers;
using ApiProyectoConjuntoAWSRedSocial.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ApiProyectoConjuntoAWSRedSocial;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();

        string secretKey = "huoghiohiofgdhiossfgdpjifgdpjisgfdpjifghdpjiosfgdpjiofgdpjiosfgdpjiosfgbphifdmjgofdjgpdjpiofdjgjfidpsjgpsfdjpvgi";
        string audience = "Api";
        string issuer = "localhost";


        string connectionString = "server=awsmysqlrepa.cvqso0me2ev3.us-east-1.rds.amazonaws.com;port=3306;user id=adminsql;password=Admin123;database=REDSOCIAL";


        HelperActionServicesOAuth helper = new HelperActionServicesOAuth(secretKey, audience, issuer);

        services.AddSingleton<HelperActionServicesOAuth>(helper);

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddAuthentication
            (helper.GetAuthenticateSchema())
            .AddJwtBearer(helper.GetJwtBearerOptions());

        // ANTIGUO
        // string connectionString = builder.Configuration.GetConnectionString("SqlAzure");

        services.AddTransient<RepositoryTheHive>();
        services.AddDbContext<TheHiveContext>
            (options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        // REGISTRAMOS SWAGGER COMO SERVICIO
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
        });

       

        services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Emp Hospitales");
            options.RoutePrefix = "";
        });
    }
}