using Cart.Datalibrary;
using Cart.Datalibrary.CartManagement;
using Cart.Datalibrary.StockManagement;
using Cart.Modules.In.Contracts;
using Cart.Modules.In.Workflows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CartAPI
{
    public class Startup
    {
        [System.Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        [System.Obsolete]
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this._env = env;
            var conf = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: false, optional: true)
               .Build();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<CartDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CartDatabase"), b => {
                    b.CommandTimeout(60000);
                    b.MigrationsAssembly("Cart.Datalibrary");
                });
            });
            services.AddTransient<ICartWorkflow, CartWorkflow>();
            services.AddTransient<ICartManagementUnitOfWork, CartManagementUnitOfWork>();
            services.AddTransient<IStockManagementUnitOfWork, StockManagementUnitOfWork>();
            services.AddControllers();


            services.AddTransient(o => {
                string connStr = Configuration.GetSection("MongoDbSettings").GetValue<string>("ConnectionString");
                string dbName = Configuration.GetSection("MongoDbSettings").GetValue<string>("DatabaseName");

                return new CartDwhDataContext(connStr, dbName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CartDataContext cartDataContext)
        {        

            cartDataContext.Database.Migrate();
            cartDataContext.UpdateRange();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller}/{action}/{id?}"
                );
            });
            app.UseMvc();
        }
    }
}
