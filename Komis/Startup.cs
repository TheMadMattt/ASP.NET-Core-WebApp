using Komis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Komis
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
	            options.Password.RequireDigit = true;
	            options.Password.RequireNonAlphanumeric = false;
	            options.Password.RequiredLength = 8;
	            options.Password.RequiredUniqueChars = 0;
	            options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();
	        services.AddTransient<ICarRepository, CarRepository>();
	        services.AddTransient<IOpinionRepository, OpinionRepository>();
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
