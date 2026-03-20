using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }



    }
}
