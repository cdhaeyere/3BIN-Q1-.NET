var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/calcultva/{prix}/{pays}", (int prix, String pays) =>
{
    double returned = prix;
    switch (pays)
    {
        case "FR":
            returned = prix * 1.2;
            break;
        case "BE":
            returned = prix * 1.21;
            break;
        default:
            break;
    }

    return returned;
});

app.Run();