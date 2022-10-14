using bART_Solutions_test.Domain;
using bART_Solutions_test.Domain.Entities;
using bArt_test.Domain.Repositories.Abstract;
using bArt_test.Domain.Repositories.EntityFramewok;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using bArt_test.Validators;


namespace bArt_test
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
                       
            services.AddMvc()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);
            
            services.AddControllers();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<Test_DbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //Abstracts entyties
            services.AddTransient<IContactRepository, EFContactRepository>();
            services.AddTransient<IAccountRepository, EFAccountRepository>();
            services.AddTransient<IIncidentRepository, EFIncidentRepository>();
            //Validators
            services.AddScoped<IValidator<Account>, AccountValidator>();
            services.AddScoped<IValidator<Contact>, ContactValidator>();
            services.AddScoped<IValidator<Incident>, IncidentValidator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "bArt_test", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "bArt_test v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        //public virtual IServiceCollection InitializeAutomapper(IServiceCollection services)
        //{
        //    // Used in older versions
        //    // ServiceCollectionExtensions.UseStaticRegistration = false;

        //    services.AddAutoMapper(cfg =>
        //    {
        //        cfg.AddProfile<ContactsProfile>();

        //    }); // Scoped Lifetime!

        //    return services;
        //}
    }
}
