var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:50189");
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    // Check if the request path is the root path "/"
    if (context.Request.Path == "/")
    {
        // Redirect to index.html
        context.Response.Redirect("/index.html");
        return;
    }

    // Call the next middleware in the pipeline
    await next();
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
