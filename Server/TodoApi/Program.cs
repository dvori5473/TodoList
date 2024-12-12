using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<ToDosContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("todos"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql")));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();    

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/items", async (ToDosContext dbContext)=> {
    
    var items = await dbContext.Items.ToListAsync();
    return Results.Ok(items);
});


app.MapPost("/items", async (ToDosContext dbContext, Item item) =>
{
    dbContext.Items.Add(item);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/items/{item.Id}", item);
});


app.MapPut("/items/{id}", async (ToDosContext dbContext, int id, [FromQuery] bool isComplete) =>
{
   
    var item = await dbContext.Items.FindAsync(id);
    if (item == null)
    {
        return Results.NotFound();
    }

    item.IsComplete = isComplete;
    await dbContext.SaveChangesAsync();

    return Results.Ok(item);
});


app.MapDelete("/items/{id}", async (ToDosContext dbContext, int id) =>
{
    var item = await dbContext.Items.FindAsync(id);
    if (item == null)
    {
        return Results.NotFound();
    }

    dbContext.Items.Remove(item);
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});


app.Run();
