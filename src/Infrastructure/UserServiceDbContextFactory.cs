using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class UserServiceDbContextFactory : IDesignTimeDbContextFactory<UserServiceDbContext>
    {
        public UserServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
            
            optionsBuilder.UseSqlServer("Server=localhost;Database=UserServiceDb;TrustServerCertificate=True;Integrated Security=True;");

            return new UserServiceDbContext(optionsBuilder.Options);
        }
    }
}