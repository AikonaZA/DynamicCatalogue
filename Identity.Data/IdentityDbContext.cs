using Identity.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    // Inherit from IdentityDbContext<ApplicationUser> from the correct namespace
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
    }
}
