using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TutorPrototype.EF;
using TutorPrototype.Repos;
using TutorPrototype.Repos.Interfaces;

namespace TutorPrototype
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IHostingEnvironment Enviroment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Enviroment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddDbContext<TPContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TutorProto")));

            if (Enviroment.IsDevelopment())
            {
                services.AddScoped<ISignInRepo, DevSignInRepo>();
            }
            else
            {
                services.AddScoped<ISignInRepo, ProdSignInRepo>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TPContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            DbInitializer.InitializeData(db);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
