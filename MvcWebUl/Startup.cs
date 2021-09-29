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
//Entities katmaný bizim projemizdeki veritabanýna karþýlýk gelen nesneleri yapýlandýrdýðýmýz yerdir.Örneðin northwind veri tabanýnda
// ürünler diye bir tablo var. O tabloya karþýlýk gelen bir ürün nesnemiz olacacak.

//Core katmaný framework katmanýdýr. Yani sadece bu projede deðil, diðer projelerdede kullanabileceðimiz kodlarý
//bu kýsýma ekliyoruz ki sonra bunu alýp baþka projedede kullanabilelim.

//DataAccess kýsmý bizim veri tabaný iþlerini yaptýðýmýz yerdir. Bu katman tamamen temel sorgularýn yazýldýðý yerdir. 


//Business projeye yönelik iþ kodlarý buraya yazýlýr. Örneðin bankacýlýk sisteminde
// bir kiþiye kredi verip vermeyeceðimizi planladýðýmýz yer, algoritmasýnýn yazýldýðý yer burasýdýr.
