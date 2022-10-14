using bART_Solutions_test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace bART_Solutions_test.Domain
{
    public class Test_DbContext : DbContext
    {
        public Test_DbContext(DbContextOptions<Test_DbContext> options)
            :base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACTS");

                entity.HasIndex(x => x.Email)
                .HasDatabaseName("EMAIL")
                .IsUnique();

                entity.Property(x => x.FirstName)
                .IsRequired();

                entity.Property(x => x.LastName)
                .IsRequired(); 
                
                entity.Property(x => x.Email)
                .IsRequired();

                entity.HasOne(d => d.Account)
                .WithMany(p => p.Contacts)
                .HasForeignKey(b => b.AccountId);
            });
            builder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNTS");

                entity.HasIndex(x => x.Name)
                .IsUnique();                

                entity.Property(x => x.Name)
                .IsRequired();

                entity.HasOne(d => d.Incident)
                .WithMany(p => p.Accounts)
                .HasForeignKey(b => b.IncidentName);
                
            });
            builder.Entity<Incident>(entity =>
            {
                entity.ToTable("INCIDENTS");

                entity.HasIndex(x => x.Name)
                .IsUnique();

                entity.Property(x => x.Name)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

                entity.HasKey(x => x.Name);

            });
        }/*HasDefaultValueSql("NEWID()");*/
        //public async Task<int> SaveChangesAsync()
        //{
        //    return await base.SaveChangesAsync();
        //}
    }
}
