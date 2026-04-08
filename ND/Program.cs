var builder = WebApplication.CreateBuilder(args);

// ✅ 1️⃣ ADD CORS HERE (before Build)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins(
                "https://your-angular-app.onrender.com",   // Angular on Render
                "https://namastubhyamdecor.com",           // your domain
                "https://www.namastubhyamdecor.com"        // your domain (www)
            )
            .AllowAnyHeader()
            .AllowAnyMethod());
});

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

app.UseStaticFiles();

app.UseRouting();

// ✅ 2️⃣ ADD CORS HERE (VERY IMPORTANT - after UseRouting)
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ IMPORTANT for Render
app.Run("http://0.0.0.0:10000");