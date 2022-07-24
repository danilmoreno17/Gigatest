using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Kameyo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kameyo.Infrastructure.Identity
{
    /// <summary>
    /// Database abstraction for a combined <see cref="DbContext"/> using ASP.NET Identity and Identity Server.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TRole"></typeparam>
    /// <typeparam name="TKey">Key of the IdentityUser entity</typeparam>
    /// IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    //public class KeyApiAuthorizationDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>, IPersistedGrantDbContext
    //public class KeyApiAuthorizationDbContext<
    //    TUser,
    //    TRole,
    //    TKey,
    //    TUserClaim,
    //    TUserRole,
    //    TUserLogin,
    //    TRoleClaim,
    //    TUserToken> : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>, IPersistedGrantDbContext
    //    where TUser : IdentityUser<TKey>
    //    where TRole : IdentityRole<TKey>
    //    where TKey : IEquatable<TKey>
    //    where TUserClaim : IdentityUserClaim<TKey>
    //    where TUserRole : IdentityUserRole<TKey>
    //    where TUserLogin : IdentityUserLogin<TKey>
    //    where TRoleClaim : IdentityRoleClaim<TKey>
    //    where TUserToken : IdentityUserToken<TKey>

    //{
    //    private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

    //    /// <summary>
    //    /// Initializes a new instance of <see cref="ApiAuthorizationDbContext{TUser, TRole, TKey}"/>.
    //    /// </summary>
    //    /// <param name="options">The <see cref="DbContextOptions"/>.</param>
    //    /// <param name="operationalStoreOptions">The <see cref="IOptions{OperationalStoreOptions}"/>.</param>
    //    public KeyApiAuthorizationDbContext(
    //        DbContextOptions options,
    //        IOptions<OperationalStoreOptions> operationalStoreOptions)
    //        : base(options)
    //    {
    //        _operationalStoreOptions = operationalStoreOptions;
    //    }

    //    //public virtual DbSet<TUser> Users { get; set; }
    //    /// <summary>
    //    /// Gets or sets the <see cref="DbSet{PersistedGrant}"/>.
    //    /// </summary>
    //    public DbSet<PersistedGrant>? PersistedGrants { get; set; }

    //    /// <summary>
    //    /// Gets or sets the <see cref="DbSet{DeviceFlowCodes}"/>.
    //    /// </summary>
    //    public DbSet<DeviceFlowCodes>? DeviceFlowCodes { get; set; }
    //    public DbSet<Key>? Keys { get; set; }

    //    Task<int> IPersistedGrantDbContext.SaveChangesAsync() => base.SaveChangesAsync();

    //    /// <inheritdoc />
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);

    //        builder.Entity<TUser>(b => { 
    //            b.ToTable("IdentityUsers");

    //            //// Each User can have many UserClaims
    //            //b.HasMany<TUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
    //            //// Each User can have many UserLogins
    //            //b.HasMany<TUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
    //            //// Each User can have many UserTokens
    //            //b.HasMany<TUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
    //            //// Each User can have many entries in the UserRole join table
    //            b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
    //        });
            


    //        builder.Entity<TRole>(b => { 
    //            b.ToTable("IdentityRoles");

    //            // Each Role can have many entries in the UserRole join table
    //            //b.HasMany(e => e.UserRoles)
    //            //    .WithOne(e => e.Role)
    //            //    .HasForeignKey(ur => ur.RoleId)
    //            //    .IsRequired();

    //            // Each Role can have many associated RoleClaims
    //            //b.HasMany(e => e.RoleClaims)
    //            //    .WithOne(e => e.Role)
    //            //    .HasForeignKey(rc => rc.RoleId)
    //            //    .IsRequired();
    //        });
    //        builder.Entity<TUserClaim>(b => { b.ToTable("IdentityUserClaims"); });
    //        builder.Entity<TUserToken>(b => { b.ToTable("IdentityUserTokens"); });
    //        builder.Entity<TUserLogin>(b => { b.ToTable("IdentityUserLogins"); });
    //        builder.Entity<TRoleClaim>(b => { b.ToTable("IdentityRoleClaims"); });
    //        builder.Entity<IdentityUserRole<TKey>>(b => { 
    //            b.ToTable("IdentityUserRoles");
    //            // Primary key
    //            b.HasKey(r => new { r.UserId, r.RoleId });
    //        });
    //        builder.Entity<Key>(b => { b.ToTable("IdentityKeys"); });
    //        builder.Entity<PersistedGrant>(b => { b.ToTable("IdentityPersistedGrants"); });

    //        builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
    //    }
    //}

}
