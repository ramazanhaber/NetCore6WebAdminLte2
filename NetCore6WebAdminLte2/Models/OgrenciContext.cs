using Microsoft.EntityFrameworkCore;

namespace NetCore6WebAdminLte2.Models
{
    public class OgrenciContext : DbContext
    {
        public OgrenciContext(DbContextOptions<OgrenciContext> opt) : base(opt)
        {

        }
        public DbSet<OgrenciTable> OgrenciTable { get; set; }
    }
}
