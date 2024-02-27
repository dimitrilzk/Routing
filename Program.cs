using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    //this end point will be always null because its called before UseRouting()
//    Endpoint? endp = context.GetEndpoint();
//    await next(context);
//});
////enable routing
//app.UseRouting();

//app.Use(async (context, next) =>
//{
//    //this will be an object representing the endpoint because its called after UseRouting()
//    Endpoint? endp = context.GetEndpoint();
//    if (endp != null)
//    {
//        await context.Response.WriteAsync($"Endpoint:{endp.DisplayName}\n");
//    }
//    await next(context);
//});

////creating end points
//app.UseEndpoints(endpoints =>
//{
//    //add your end points
//    //MapGet enable this end point only to get request
//    endpoints.MapGet("map1", async (context) =>
//    {
//        await context.Response.WriteAsync("In Map 1");
//    });
//    //MapPost enable this end point only to post request
//    endpoints.MapPost("map2", async (context) =>
//    {
//        await context.Response.WriteAsync("In Map 2");
//    });
//});

////this is for default request who does not match with my end points
//app.Run(async context =>
//{
//    await context.Response.WriteAsync($"Request recived at{context.Request.Path}");
//});




app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files: {fileName}.{extension}");
    });
    endpoints.Map("product/detail/{id:int?}", async context =>
    {
        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product detail: {id}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request recived at{context.Request.Path}");
});

app.Run();
