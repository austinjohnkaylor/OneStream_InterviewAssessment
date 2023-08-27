using FrontendWebAPI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddAuthentication(x => {
//     x.DefaultAuthenticateScheme = 
// }); --> watch this video for more info -> https://www.youtube.com/watch?v=mgeuh8k3I4g

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

builder.Services.AddHttpClient<ILocationApiService, LocationApiService>();
builder.Services.AddHttpClient<IPersonApiService, PersonApiService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
