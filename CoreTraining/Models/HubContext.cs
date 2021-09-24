using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreTraining.Models
{
    public partial class HubContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public HubContext(IConfiguration configuration, DbContextOptions<HubContext> options) : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<EnumType> EnumTypes { get; set; }
        public virtual DbSet<EnumTypeItem> EnumTypeItems { get; set; }
        public virtual DbSet<MeasurementUnitValue> MeasurementUnitValues { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            var connection = new SqlConnection
            {
                ConnectionString = Configuration.GetConnectionString("HubDatabase")
            };

            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.ActivityStatus)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_EnumTypeItem");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Property");

                entity.HasOne(d => d.QuotingRentMax)
                    .WithMany(p => p.ActivityQuotingRentMaxes)
                    .HasForeignKey(d => d.QuotingRentMaxId)
                    .HasConstraintName("FK_Activity_MeasurementUnitValue");

                entity.HasOne(d => d.QuotingRentMin)
                    .WithMany(p => p.ActivityQuotingRentMins)
                    .HasForeignKey(d => d.QuotingRentMinId)
                    .HasConstraintName("FK_Activity_MeasurementUnitValue1");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<EnumType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<EnumTypeItem>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.EnumType)
                    .WithMany(p => p.EnumTypeItems)
                    .HasForeignKey(d => d.EnumTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnumTypeItem_EnumType");
            });

            modelBuilder.Entity<MeasurementUnitValue>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Property_Address");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_PropertyType");
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
