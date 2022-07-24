using Duende.IdentityServer.EntityFramework.Options;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Domain.Common;
using Kameyo.Core.Domain.Entities;
using Kameyo.Infrastructure.Identity;
using Kameyo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Kameyo.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        string,
        IdentityUserClaim<string>,
        ApplicationUserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options,
       IOptions<OperationalStoreOptions> operationalStoreOptions,
       ICurrentUserService currentUserService,
       IDomainEventService domainEventService,
       IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
            _dateTime = dateTime;
        }

        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeAward> EmployeeAwards { get; set; } = null!;
        public virtual DbSet<EmployeeCertification> EmployeeCertifications { get; set; } = null!;
        public virtual DbSet<EmployeeExperience> EmployeeExperiences { get; set; } = null!;
        public virtual DbSet<EmployeeSkillAbility> EmployeeSkillAbilities { get; set; } = null!;
        public virtual DbSet<EmployeeStudy> EmployeeStudies { get; set; } = null!;
        public virtual DbSet<HourBank> HourBanks { get; set; } = null!;
        //public virtual DbSet<PriceList> PriceLists { get; set; } = null!;
        //public virtual DbSet<PriceListItem> PriceListItems { get; set; } = null!;
        //public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectHourBank> ProjectHourBanks { get; set; } = null!;
        public virtual DbSet<ProjectResource> ProjectResources { get; set; } = null!;
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; } = null!;

        public virtual DbSet<ProjectManager> ProjectManagers { get; set; } = null!;
        public virtual DbSet<ProjectReport> ProjectReports { get; set; } = null!;
        public virtual DbSet<ProjectReportDetail> ProjectReportDetails { get; set; } = null!;

        public virtual DbSet<Rule> Rules { get; set; } = null!;
        public virtual DbSet<Subsidiary> Subsidiaries { get; set; } = null!;
        public virtual DbSet<TaskActivity> TaskActivities { get; set; } = null!;
        public virtual DbSet<ProjectReport> ProjectReport { get; set; } = null!;
        public virtual DbSet<ProjectReportDetail> ProjectReportDetail { get; set; }
        public virtual DbSet<MenuRole> MenuRole { get; set; } = null!;
        //public virtual DbSet<MenuUserType> MenuUserType { get; set; } = null!;
        public virtual DbSet<FinancialParticipation> FinancialParticipation { get; set; } = null;
        public virtual DbSet<PercentageParticipationTable> PercentageParticipationTable { get; set; } = null;

        



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.UtcNow;
                        break;
                }
            }

            var events = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(events);
            return result;
        }

        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("IdentityUsers");               

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

            });



            builder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("IdentityRoles");               

                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            builder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("IdentityUserClaims"); });
            builder.Entity<IdentityUserToken<string>>(b => { b.ToTable("IdentityUserTokens"); });
            builder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("IdentityUserLogins"); });
            builder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("IdentityRoleClaims"); });
            builder.Entity<ApplicationUserRole>(b =>
            {
                b.ToTable("IdentityUserRoles");
                // Primary key
                //b.HasKey(r => new { r.UserId, r.RoleId });
            });

            //builder.Entity<Key>(b => { b.ToTable("IdentityKeys"); });
            //builder.Entity<PersistedGrant>(b => { b.ToTable("IdentityPersistedGrants"); });
            //builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
        }

    }

}
