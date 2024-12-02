using Microsoft.EntityFrameworkCore;
using ProductAppMvc.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión correcta para la base de datos
builder.Services.AddDbContext<ProductAppMvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductAppMvcContext")
        ?? throw new InvalidOperationException("Connection string 'ProductAppMvcContext' not found.")));

// Registrar el servicio ProductService para la inyección de dependencias
builder.Services.AddTransient<ProductService>();

// Agregar servicios MVC (Controladores y Vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configurar redirección a HTTPS y servir archivos estáticos
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configurar el enrutamiento
app.UseRouting();

// Configurar la autorización (si es necesario)
app.UseAuthorization();

// Definir la ruta predeterminada para el controlador y la acción
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicación
app.Run();



