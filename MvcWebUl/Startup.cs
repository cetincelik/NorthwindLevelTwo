using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcWebUl.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MvcWebUl
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
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IProductDal, EfProductDal>();
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartSessionHelper, CartSessionHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();

            services.AddControllersWithViews()
                .AddFluentValidation(option=>
                option.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
//Entities katman� bizim projemizdeki veritaban�na kar��l�k gelen nesneleri yap�land�rd���m�z yerdir.�rne�in northwind veri taban�nda
// �r�nler diye bir tablo var. O tabloya kar��l�k gelen bir �r�n nesnemiz olacacak.

//Core katman� framework katman�d�r. Yani sadece bu projede de�il, di�er projelerdede kullanabilece�imiz kodlar�
//bu k�s�ma ekliyoruz ki sonra bunu al�p ba�ka projedede kullanabilelim.

//DataAccess k�sm� bizim veri taban� i�lerini yapt���m�z yerdir. Bu katman tamamen temel sorgular�n yaz�ld��� yerdir. 


//Business projeye y�nelik i� kodlar� buraya yaz�l�r. �rne�in bankac�l�k sisteminde
// bir ki�iye kredi verip vermeyece�imizi planlad���m�z yer, algoritmas�n�n yaz�ld��� yer buras�d�r.
