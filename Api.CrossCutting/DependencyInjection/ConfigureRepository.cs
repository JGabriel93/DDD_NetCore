using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<ICurrentAccountRepository, CurrentAccountImplementation>();
            serviceCollection.AddScoped<IHistoricCurrentAccountRepository, HistoricCurrentAccountImplementation>();

            serviceCollection.AddDbContext<MyContext>(context => context.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
        }
    }
}
