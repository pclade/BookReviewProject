var builder = WebApplication.CreateBuilder(args);

// build ApiBaseUrl from injected host if not set in appsettings
var apiBaseFromConfig = builder.Configuration["ApiBaseUrl"];
var apiHost = Environment.GetEnvironmentVariable("API_HOST");
var apiScheme = Environment.GetEnvironmentVariable("API_SCHEME") ?? "https";
var resolvedApiBase = apiBaseFromConfig;

if (string.IsNullOrWhiteSpace(resolvedApiBase) && !string.IsNullOrWhiteSpace(apiHost))
{
    resolvedApiBase = $"{apiScheme}://{apiHost}/";
}

builder.Services.AddRazorPages();
builder.Services.AddHttpClient("api", c =>
{
    var baseUrl = resolvedApiBase ?? throw new InvalidOperationException("ApiBaseUrl not configured");
    c.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
