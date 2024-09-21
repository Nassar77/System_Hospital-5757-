using HospitalSystem.BLL.Mapping;
using HospitalSystem.BLL.Service.Impelementation;
using HospitalSystem.DAL.Repo.Abstraction;
using HospitalSystem.DAL.Repo.Impelementation;
using HospitalSystem.DAL.DB;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Repo.Abstracion;
using HospitalSystem.DAL.Repo.Implemintation;
using Stripe;
using HospitalSystem.BLL.Service.Implemintation;
using SH.DAL.Repo.Abstracion;
using SH.DAL.Repo.Implemintation;
using SH.BLL.Services.Abstraction;
using SH.BLL.Services.implemintation;
using Microsoft.AspNetCore.Mvc.Routing;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(x => x.AddProfile(new Mapp()));
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, HospitalSystem.BLL.Service.Impelementation.AccountService>();
builder.Services.AddScoped<IDectorRepo, DoctorRepo>();
builder.Services.AddScoped<IDocServices, DocServices>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IMedicalReportRepo, MedicalReportRepo>();
builder.Services.AddScoped<IMedicalReportService, MedicalReportService>();
builder.Services.AddScoped<IAMedicalReportService, AMedicalReportService>();
builder.Services.AddScoped<IAMedicalReportRepo, AMedicalReportRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IRoomService, RoomService>();
//Identity
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer("name=DefaultConnection"));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.AddIdentity<Patient, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();


builder.Services.AddIdentityCore<Patient>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Patient>>(TokenOptions.DefaultProvider);



//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();



builder.Services.Configure<IdentityOptions>(options =>
{
    //Lockout settings
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    //Signin settings
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Auth:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Auth:Google:ClientSecret"];
    });



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();
