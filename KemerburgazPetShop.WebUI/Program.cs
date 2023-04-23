using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.Business.Concrete;
using KemerburgazPetShop.DataAccess.Abstract;
using KemerburgazPetShop.DataAccess.Concrete.EfCore;
using KemerburgazPetShop.DataAccess.Concrete.EFCore;
using KemerburgazPetShop.WebUI.EmailServices;
using KemerburgazPetShop.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
//using KemerburgazPetShop.WebUI.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders(); // ikinci gelen kýsým, bu hali ile çalýþtý.

builder.Services.Configure<IdentityOptions>(options =>
{
    //password ve kullanýcý giriþi limit iþlemleri
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder 
    {
        HttpOnly = true,
        Name =".PetShop.Security.Cookie",
        SameSite = SameSiteMode.Strict //Cross-site attack
    };


});



//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDBContext>();  Scaffolding ile yüklenen kýsým

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IProductDAL, EFCoreProductDAL>();
builder.Services.AddScoped<ICategoryDAL, EFCoreCategoryDAL>();
builder.Services.AddScoped<ICartDAL, EFCoreCartDAL>();


builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICartService, CartManager>();

builder.Services.AddTransient<IEmailSender, EmailSender>(); //email confirmation  

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

//kullanýcý yetkilendirme için eklendi admin vs. baþlangýç
using (var scope = app.Services.CreateScope())
{
    var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));
    var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));

    SeedIdentity.Seed(userManager, roleManager, builder.Configuration).Wait();
}
//kullanýcý yetkilendirme için eklendi admin vs. bitiþ




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

app.MapControllerRoute(
    name: "cart",
    pattern: "{controller=Cart}/{action=Index}",
    defaults: new { controller = "Cart", action = "Index" });

app.MapRazorPages();

app.Run();
