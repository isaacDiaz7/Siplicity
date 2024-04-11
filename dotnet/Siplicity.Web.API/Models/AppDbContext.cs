using Microsoft.EntityFrameworkCore;

namespace Siplicity.Web.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
