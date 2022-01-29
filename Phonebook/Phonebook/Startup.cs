using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Phonebook.Contacts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Phonebook.Contacts.Core.GenericRepository;
using Phonebook.Contacts.Core.Repository;
using AutoMapper;
using Phonebook.Contacts.Core.Services;
using Phonebook.Contacts.Core.Dapper;

namespace Phonebook
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
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Configuration EF Core
            services.AddDbContext<ContactsDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnection"));
            });
            services.AddSwaggerGen();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IGenericDapper, GenericDapper>();
            services.AddScoped<IContactDapper, ContactDapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Phonebook API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //      name: "default",
                //      pattern: "{area=Client}/{controller=Contacts}");
                endpoints.MapControllers();
            });
        }
    }
}
