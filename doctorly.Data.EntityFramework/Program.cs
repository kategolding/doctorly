using doctorly.Data.EntityFramework.Extensions;

namespace Doctorly.Data.EntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDoctorlyDbContext(builder.Configuration.GetConnectionString(name: "DoctorlyConnection"));

            var app = builder.Build();

            app.Run();
        }
    }
}