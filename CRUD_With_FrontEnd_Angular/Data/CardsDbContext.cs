using CRUD_With_FrontEnd_Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_With_FrontEnd_Angular.Data
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {

        }
            //DbSet 
            public DbSet<Card> Cards { get; set; }
    }
    
}
