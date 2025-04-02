using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    public class SpendSmartDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<QuoteRequest> QuoteRequests { get; set; }

        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext>options):
            base(options)
        {

        }

        internal object SingleOrDefault(Func<object, bool> value) 
        {
            throw new NotImplementedException();
        }
    }
}
