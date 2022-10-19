using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorChatServer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddCors(options =>
	options.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyMethod()
						.AllowAnyHeader()
						.WithOrigins(
							"https://localhost:7050", // ASP.Net Core con autenticazione
							"https://localhost:44360", // ASP.Net senza autenticazione
							"https://localhost:44370" // ASP.Net con autenticazione
						)
						.AllowCredentials();
	}));

builder.Services.AddSignalR(x => x.EnableDetailedErrors = true);

/*
// CORS di default
builder.Services.AddCors(options => 
	options.AddDefaultPolicy(builder =>
	{
		builder.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
	}));
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// NOTA: UseCors must be called before MapHub.
app.UseCors();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// SignalR Endpoints
app.UseEndpoints(endpoints =>
{
	//endpoints.MapBlazorHub();
	//endpoints.MapFallbackToPage("/_Host");
	endpoints.MapHub<ChatHub>(ChatHub.HubUrl)
		.AllowAnonymous()
		.RequireCors("CorsPolicy");
});

app.Run();
