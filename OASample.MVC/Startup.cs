using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OASample.Repo.Mapping;
using OASample.Repo;
using OASample.Service;
using OASample.MVC.Extensions;
using OASample.Repo.Repositories;
using System.Globalization;
using Microsoft.Extensions.Options;
using OASample.MVC.Resources;
using System.Reflection;

namespace OASample.MVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //configure to use OASample.migration to migrate
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(
                this.Configuration.GetConnectionString("DefaultConnection")
                , x => x.MigrationsAssembly("OASample.Repo")
            ));

            services.AddAutoMapper();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(EntityMappingFactory));
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddSingleton<LocService>();
            services.AddLocalization(o => o.ResourcesPath = "Resources");

            //setting up data annotations localization
            services.AddMvc()
                .AddViewLocalization(o => o.ResourcesPath = "Resources")
                .AddDataAnnotationsLocalization(opt =>
                {
                    opt.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assembly = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assembly.Name);
                    };
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //setup globalizations
            services.Configure<RequestLocalizationOptions>(
                opt =>
                {
                    var supportedCultures = new List<CultureInfo>()
                    {
                        new CultureInfo("en-AU"),
                        new CultureInfo("id-ID"),
                        new CultureInfo("ar-SA")
                    };

                    opt.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[2]);
                    opt.SupportedCultures = supportedCultures;
                    opt.SupportedUICultures = supportedCultures;
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //get localizations setup            
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
