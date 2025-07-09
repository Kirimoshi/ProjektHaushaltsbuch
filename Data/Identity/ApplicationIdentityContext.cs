namespace ProjektHaushaltsbuch.Data.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationIdentityContext : IdentityDbContext
{
    public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options)
        : base(options)
    {
    }
}