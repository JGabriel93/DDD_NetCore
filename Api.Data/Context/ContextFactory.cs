using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Persist Security Info=True;Server=localhost;Port=3306;DataBase=dbAPI;Uid=root;Pwd=admin";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}
