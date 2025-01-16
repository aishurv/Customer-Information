using CustomerInformation.Components;
using Serilog;
using CustomerInformation.Helper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddBuilderServices();

var app = builder.Build();
Logger.LogInitializer();
Log.Information("Application Started !");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
