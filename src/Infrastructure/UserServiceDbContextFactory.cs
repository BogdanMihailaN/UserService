using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class UserServiceDbContextFactory : IDesignTimeDbContextFactory<UserServiceDbContext>
    {
        public UserServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
            
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=UserServiceDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");

            return new UserServiceDbContext(optionsBuilder.Options);
        }
    }
}