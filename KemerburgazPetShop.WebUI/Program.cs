using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Business.Concrete;
using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.DataAccess.Concrete.EfCore;
using KemerburgazPetShop.DataAccess.Concrete.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KemerburgazPetShop.WebUI.Areas.Identity.Data;




var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDBContext>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "products",
    pattern: "products/{category?}",
    defaults: new { controller = "Shop", action = "List" });

app.MapControllerRoute(
    name: "adminProducts",
    pattern: "admin/products",
    defaults: new { controller = "Admin", action = "ProductList" });

app.MapControllerRoute(
    name: "adminProducts",
    pattern: "admin/products/{id?}",
    defaults: new { controller = "Admin", action = "EditProduct" });

app.MapRazorPages();

app.Run();
