using doctorly.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Data.EntityFramework.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDoctorlyDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DoctorlyDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
