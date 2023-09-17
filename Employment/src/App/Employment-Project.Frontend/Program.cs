using Employment_Project.Frontend.Contracts;
using Employment_Project.Frontend.Contracts.Base;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Formatting=Newtonsoft.Json.Formatting.Indented;
    options.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.NullValueHandling=Newtonsoft.Json.NullValueHandling.Ignore;
});
builder.Services.AddTransient<IEmploymentClient,EmploymentClient>();

var baseUrl = builder.Configuration.GetValue<string>("EmploymentApiBase");
builder.Services.AddHttpClient("EmployeeApi", c =>
{
    c.BaseAddress = new Uri(baseUrl!);

});
builder.Services.AddTransient<IEmploymentClient,EmploymentClient>();
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
