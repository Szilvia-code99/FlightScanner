using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Helpers;
using AutoMapper;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the TokenService with a scoped lifetime, the lifetime of a single request
            services.AddScoped<ITokenService, TokenService>(); 
            services.AddAutoMapper(typeof(Automapper).Assembly);
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            
            // Browser security prevents a web page from making requests to a different domain than the one that served the web page. 
            // This restriction is called the same-origin policy. The same-origin policy prevents a malicious site from reading sensitive data from another site. 
            // Enabling cross-origin requests (CORS) can be done with named policy and middleware
            services.AddCors(
                o => o.AddPolicy(
                    "MyPolicy",builder => {
                     builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();}));

           services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                     .GetBytes(Configuration.GetSection("AppSettings:Token").Value)), // vigyazz, hogy ugyanigy legyen kitoltve az appsetings.json-okban, ha typo hiba van, akkor nem fog menni
                 ValidateIssuer = false,
                 ValidateAudience = false,
             };
             });
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
      }
    }
