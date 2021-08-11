using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Product.ApiRest.DataDbContext;
using Product.ApiRest.Repository;
using System;

namespace Product.ApiRest
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

			var connection = Configuration["MySQLConnection:MySQLConnectionString"];
			services.AddDbContext<ProdutoApplication>(options => options.UseMySql(connection));

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1",
					new OpenApiInfo
					{
						Title = "Api Rest de produtos",
						Version = "v1",
						Description = "API RESTful de produtos'",
						Contact = new OpenApiContact
						{
							Name = "Leandro Costa",
							Url = new Uri("https://github.com/magnomoreira")
						}
					});
			});

			services.AddScoped<ProdutoRepository>();
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

			app.UseSwagger();

			app.UseSwaggerUI(c => 
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json",
					"Api Rest de produtos ");
			});

			var option = new RewriteOptions();
			option.AddRedirect("^$", "swagger");
			app.UseRewriter(option);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
		
	}
}
