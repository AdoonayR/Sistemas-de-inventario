using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Sistemas_de_inventario.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext utilizando la cadena de conexión en appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar controladores con vistas
builder.Services.AddControllersWithViews();

// Configurar autenticación por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";    // Ruta de Login para usuarios no autenticados
        options.LogoutPath = "/Login/Logout";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Primero se usa la autenticación, luego la autorización
app.UseAuthentication();
app.UseAuthorization();

// Establecer la ruta predeterminada: cuando el usuario vaya a la raíz, se redirige a LoginController.Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
