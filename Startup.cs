using FluentValidation.AspNetCore;
using Furniture_Shop_Backend.Models;
using Furniture_Shop_Backend.Services;
using Furniture_Shop_Backend.Services.Orders;
using Furniture_Shop_Backend.Services.ProductImages;
using Furniture_Shop_Backend.Validations.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Furniture_Shop_Backend {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductvalidator>());

            services.AddDbContext<FurnitureShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FurnitureShopDB")));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Furniture_Shop_Backend", Version = "v1" });
            });

            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductImagesService, ProductImagesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Furniture_Shop_Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
