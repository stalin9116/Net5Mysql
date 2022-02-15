using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net5Mysql.API.Models;
using Net5Mysql.API.Others;

namespace Net5Mysql.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Service Mysql
            services.AddDbContext<ContextCarrito>(options =>
                                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            //End Service Mysql

            //Service Cors

            services.AddCors(options =>
            {
                options.AddPolicy(name: "PolicyAllow",
                    builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());

                options.AddPolicy(name: "PolicyCordillera",
                    builder => builder.WithOrigins("https://cordillera.edu.ec", "https://186.91.2.150")
                                .AllowAnyHeader()
                                .AllowAnyMethod());

                options.AddPolicy(name: "PolicyBancoPichincha",
                    builder =>
                    {
                        builder.WithOrigins("https://pichincha.com", "https://186.60.2.100")
                        .AllowAnyHeader()
                        .WithMethods("GET");
                    });
            }
            );


            //End Service Cors


            //Service JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Dominio"],
                        ValidAudience = Configuration["JWT:AppApi"],
                        LifetimeValidator = TokenLifeTime.Validate,
                        IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(Configuration["JWT:Clave"]))
                    };
                });
            //End Service JWT



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5Mysql.API", Version = "v1" });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5Mysql.API v1"));
            }
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();

            app.UseHttpsRedirection();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
