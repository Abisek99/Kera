using HKCR.Infra.DI;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


{
    builder.Services.AddControllers();
    builder.Services.AddInfrastructure(builder.Configuration);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    // builder.Services.AddCors(options =>
    // {
    //     options.AddPolicy(name: myAllowSpecificOrigins,
    //         policy =>
    //         {
    //             // policy.WithOrigins("https://localhost:7179/",
    //             //     "http://localhost:5128/");
    //             policy.WithOrigins("*");
    //         });
    // });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseCors(myAllowSpecificOrigins);
app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();