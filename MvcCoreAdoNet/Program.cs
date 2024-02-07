var builder = WebApplication.CreateBuilder(args);
//añadir services vistas y controladores
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();


//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}");

app.Run();