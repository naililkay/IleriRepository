using IleriRepository.Context;
using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.Repositories.Abstract;
using IleriRepository.Repositories.Concretes;
using IleriRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddControllersWithViews();
//abrasct interface ,Concrete class,Data class
builder.Services.AddScoped<IPersonelRep,PersonelRep<Personel>>();
builder.Services.AddScoped<ICityRep,CityRep<City>>();
builder.Services.AddScoped<ICountyRep,CountyRep<County>>();
builder.Services.AddScoped<IDepartmentRep,DepartmentRep<Department>>();
builder.Services.AddScoped<IGradeRep,GradeRep<Grade>>();
builder.Services.AddScoped<IUnit,Unit>();
builder.Services.AddScoped<CityModel>();
builder.Services.AddScoped<CountyModel>();
builder.Services.AddScoped<GradeModel>();
builder.Services.AddScoped<DepartmentModel>();

//builder.Services.AddScoped<City>();

//depency injection of version
//new lemek instansce yaratmak 
//serviste yapýlan tek deðiþiklikte bütün controllerde  newlemeye gerek yok

/*builder.Services.AddScoped<Personel>();
builder.Services.AddScoped<Grade>();

builder.Services.AddScoped<Department>();
builder.Services.AddScoped<County>();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
