using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Business.Concrete;
using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.DataAccess.Concrete.EfCore;
using KemerburgazPetShop.DataAccess.Concrete.EFCore;
using KemerburgazPetShop.DataAccess.Concrete.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IProductDAL, EFCoreProductDAL>();
builder.Services.AddScoped<ICategoryDAL, EFCoreCategoryDAL>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    SeedDatabase.Seed();
}
app.UseStaticFiles();
app.UseSession(); //!!
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
