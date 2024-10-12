<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using Palmart.Data;
using Palmart.IRepo;
using Palmart.Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
//builder.Services.AddTransient(typeof(IBasicRepo<>), typeof(BasicRepo<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Other service registrations

//builder.Services.AddScoped(typeof(BasicRepo<>), typeof(BasicRepo<>)); // Register generic repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(ILoginRepo), typeof(LoginRepo));

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
	name: "area",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
=======
using Microsoft.EntityFrameworkCore;
using Palmart.Data;
using Palmart.IRepo;
using Palmart.Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
//builder.Services.AddTransient(typeof(IBasicRepo<>), typeof(BasicRepo<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Other service registrations

//builder.Services.AddScoped(typeof(BasicRepo<>), typeof(BasicRepo<>)); // Register generic repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(ILoginRepo), typeof(LoginRepo));

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
	name: "area",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
>>>>>>> e14596fa2815c3abeeab24a806a31c2f1350cfcd
