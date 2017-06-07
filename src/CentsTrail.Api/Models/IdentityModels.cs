using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Constants = CentsTrail.Api.Helpers.Constants;

namespace CentsTrail.Api.Models
{
  public class ApplicationUser : IdentityUser
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
      string authenticationType)
    {
      var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
      // Add custom user claims here
      return userIdentity;
    }
  }

  public class AuthorizationContext : IdentityDbContext<ApplicationUser>
  {
    public AuthorizationContext()
      : base(Constants.DefaultConnectionString, false)
    {
    }

    public static AuthorizationContext Create()
    {
      return new AuthorizationContext();
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<ApplicationUser>().ToTable("User");
      modelBuilder.Entity<IdentityRole>().ToTable("Role");
      modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
      modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
      modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
    }
  }
}