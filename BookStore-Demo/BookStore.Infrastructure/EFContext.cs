using BookStore.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure
{
    public class EFContext : IdentityDbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }
    }
}
