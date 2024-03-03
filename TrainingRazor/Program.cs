using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using TrainingRazor.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<WebEncoderOptions>(options =>
    options.TextEncoderSettings = new TextEncoderSettings(
        UnicodeRanges.Arabic, UnicodeRanges.BasicLatin));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//If the static files requested, Like css, or js, or any other files, it will be served
app.UseStaticFiles();


//create extension function for application builder to add RequestMiddleware


//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(
//                           Path.Combine(Directory.GetCurrentDirectory(), @"static_files")),
//});

app.UseRouting();

//use the middle ware to handle the requests
app.UseMiddleware<RequestMiddleware>();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
