using API_REST_ASPNETCORE.Model;
using Microsoft.EntityFrameworkCore;

namespace API_REST_ASPNETCORE.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

    }
}
