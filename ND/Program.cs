var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// ✅ ADD THIS (for static files like CSS, JS, images)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ REMOVE .WithStaticAssets()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ IMPORTANT for Render (port binding)
app.Run("http://0.0.0.0:10000");