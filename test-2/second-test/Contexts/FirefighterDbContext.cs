using Microsoft.EntityFrameworkCore;
using second_test.Models;
using Action = second_test.Models.Action;

namespace second_test.Contexts;

public partial class FirefighterDbContext : DbContext
{
    public FirefighterDbContext()
    {
    }

    public FirefighterDbContext(DbContextOptions<FirefighterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; } = null!;
    public virtual DbSet<FireTruck> FireTrucks { get; set; } = null!;
    public virtual DbSet<Firefighter> Firefighters { get; set; } = null!;
    public virtual DbSet<FiretruckAction> FiretruckActions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=db-mssql;Database=2019SBD;User Id=s23499;Password=amYwPx32f#;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s23499");

        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.IdAction)
                .HasName("Action_pk");

            entity.ToTable("Action");

            entity.Property(e => e.IdAction).ValueGeneratedNever();

            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<FireTruck>(entity =>
        {
            entity.HasKey(e => e.IdFireTruck)
                .HasName("FireTruck_pk");

            entity.ToTable("FireTruck");

            entity.Property(e => e.IdFireTruck).ValueGeneratedNever();

            entity.Property(e => e.OperationalNumber).HasMaxLength(10);
        });

        modelBuilder.Entity<Firefighter>(entity =>
        {
            entity.HasKey(e => e.IdFirefighter)
                .HasName("Firefighter_pk");

            entity.ToTable("Firefighter");

            entity.Property(e => e.IdFirefighter).ValueGeneratedNever();

            entity.Property(e => e.FirstName).HasMaxLength(30);

            entity.Property(e => e.LastName).HasMaxLength(30);

            entity.HasMany(d => d.IdActions)
                .WithMany(p => p.IdFirefighters)
                .UsingEntity<Dictionary<string, object>>(
                    "FirefighterAction",
                    l => l.HasOne<Action>().WithMany().HasForeignKey("IdAction").OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Firefighter_Action_Action"),
                    r => r.HasOne<Firefighter>().WithMany().HasForeignKey("IdFirefighter")
                        .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Firefighter_Action_Firefighter"),
                    j =>
                    {
                        j.HasKey("IdFirefighter", "IdAction").HasName("Firefighter_Action_pk");

                        j.ToTable("Firefighter_Action");
                    });
        });

        modelBuilder.Entity<FiretruckAction>(entity =>
        {
            entity.HasKey(e => e.IdFireTruckAction)
                .HasName("Firetruck_Action_pk");

            entity.ToTable("Firetruck_Action");

            entity.Property(e => e.IdFireTruckAction).ValueGeneratedNever();

            entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdActionNavigation)
                .WithMany(p => p.FiretruckActions)
                .HasForeignKey(d => d.IdAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Firetruck_Action_Action");

            entity.HasOne(d => d.IdFireTruckNavigation)
                .WithMany(p => p.FiretruckActions)
                .HasForeignKey(d => d.IdFireTruck)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Firetruck_Action_FireTruck");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}