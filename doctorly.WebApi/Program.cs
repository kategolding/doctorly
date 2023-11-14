using doctorly.Core.ServiceInterfaces;
using doctorly.Data.EntityFramework.Repositories;
using doctorly.Data.EntityFramework.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: Would like to prevent having to actually have a reference to EF Project, 
// But without a proper business layer, it will have to do for now
builder.Services.AddDoctorlyDbContext(builder.Configuration.GetConnectionString(name: "DoctorlyConnection"));
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

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
