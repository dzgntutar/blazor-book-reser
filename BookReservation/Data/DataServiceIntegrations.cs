using BookReservation.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookReservation.Data
{
    public static class DataServiceIntegrations
    {
        public static void ServiceIntegrationData(this IServiceCollection services)
        {
            services.AddDbContext<ReservationDbContext>(config =>
            {
                config.UseSqlServer("Data Source=localhost; Initial Catalog=BookReservation; User Id=sa; Password=P@ssword1*");
            });
        }
    }
}
