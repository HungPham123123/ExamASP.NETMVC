using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = "Data Source=localhost,1433;Database=HR_MANAGE;User Id=sa;Password=Password789;TrustServerCertificate=true";
builder.Services.AddDbContext<ExamInASP.NET_MVC.Entities.DataContext>(
    options => options.UseSqlServer(connectionString)
);


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
    pattern: "{controller=department}/{action=Index}/{id?}");

app.Run();

