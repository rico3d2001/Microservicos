using ApiGateway;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;


var builder = WebApplication.CreateBuilder(args);

var routes = "Routes";

builder.Configuration.AddOcelotWithSwaggerSupport(options =>
{
    options.Folder = routes;
});

//builder.Host.UseContentRoot(Directory.GetCurrentDirectory())
//    .ConfigureAppConfiguration((hostingContext, config) =>
//    {
//        config
//            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
//            .AddJsonFile("appsettings.json", true, true)
//            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
//            .AddJsonFile("ocelot.json")
//            .AddEnvironmentVariables();
//    })
//    .ConfigureServices(s =>
//    {
//        s.AddOcelot();
//        //.AddEureka();
//    });

builder.Services.AddOcelot(builder.Configuration).AddPolly();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddOcelot(routes, builder.Environment)
    .AddEnvironmentVariables();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
//    .AddEnvironmentVariables();

var app = builder.Build();
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
    options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;

}).UseOcelot().Wait();

//app.UseOcelot().Wait();

app.MapControllers();

app.Run();
