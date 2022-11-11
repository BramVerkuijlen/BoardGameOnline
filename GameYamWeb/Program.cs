using DAL;
using InterfaceDAL.Interface;
using Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region injection services

// Logic
builder.Services.AddTransient<Player>();
builder.Services.AddTransient<PlayerCollection>();

builder.Services.AddTransient<Game>();
builder.Services.AddTransient<GameCollection>();

// DAL
builder.Services.AddScoped<IPlayerDAL, PlayerDAL>();
builder.Services.AddScoped<IPlayerCollectionDAL, PlayerDAL>();

builder.Services.AddScoped<IGameDAL, GameDAL>();
builder.Services.AddScoped<IGameCollectionDAL, GameDAL>();

//Database

builder.Services.AddSingleton<dbContext>();

#endregion

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
