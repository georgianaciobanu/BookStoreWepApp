using BookStoreApp.DataAccess.Interface;
using BookStoreApp.DataAccess.Repository;
using BookStoreApp.Models;
using BookStoreApp.Models.Entites;
using BookStoreApp.Models.Interfaces;
using BookStoreApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<BookStoreContext>(option => option.UseSqlServer(Configuration.GetConnectionString("AppDbConn")));
            services.AddControllersWithViews();
            services.AddSingleton(MapperConfig.GetMapper());

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Services
            services.AddScoped<IBookTypeService, BookTypeService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();


            #endregion Services

            #region Repository

            services.AddScoped<IRepository<BookType, int>, Repository<BookType, int>>();
            services.AddScoped<IRepository<Book, int>, Repository<Book, int>>();
            services.AddScoped<IRepository<Order, int>, Repository<Order, int>>();
            services.AddScoped<IRepository<OrdersBook, int>, Repository<OrdersBook, int>>();


            #endregion Repository
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
