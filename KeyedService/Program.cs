using KeyedService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddKeyedScoped<IStorageService, CloudStorageService>("CloudService");
builder.Services.AddKeyedScoped<IStorageService, LocalStroageService>("LocalService");

builder.Services.AddScoped(e =>
{
    var env = e.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();
    var key = env.IsDevelopment() ? "LocalService" : "CloudService";
    return e.GetRequiredKeyedService<IStorageService>(key);
});

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
