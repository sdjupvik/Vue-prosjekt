using Microsoft.EntityFrameworkCore;

public class ArmyDBContext : DbContext
{
    public ArmyDBContext(DbContextOptions<ArmyDBContext> o) : base(o) { }

    public DbSet<Mission> Missions { get; set; }
    public DbSet<MissionCommander> MissionCommanders { get; set; }
    public DbSet<Soldier> Soldiers { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<MissionStatus> MissionStatuses { get; set; }
    public DbSet<WeaponType> WeaponTypes { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<SoldierMedal> SoldierMedals { get; set; }
    public DbSet<SoldierRank> SoldierRanks { get; set; }
    public DbSet<SoldierExpertise> SoldierExpertises { get; set; }
    public DbSet<ProfileImage> ProfileImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mission 
        modelBuilder.Entity<Mission>()
            .HasOne<MissionStatus>(x => x.MissionStatus).WithMany();

        modelBuilder.Entity<Mission>()
            .HasMany<Soldier>(x => x.Soldiers).WithMany(x => x.Missions);

        modelBuilder.Entity<Mission>()
            .HasMany<Vehicle>(x => x.Vehicles).WithMany(x => x.Missions);

        modelBuilder.Entity<Mission>()
            .HasMany<Weapon>(x => x.Weapons).WithMany(x => x.Missions);

        // MissionCommander
        modelBuilder.Entity<MissionCommander>()
            .HasOne<Mission>().WithOne().HasForeignKey<MissionCommander>(x => x.MissionId);

        modelBuilder.Entity<MissionCommander>()
            .HasOne<Soldier>().WithOne().HasForeignKey<MissionCommander>(x => x.SoldierId);

        // Soldier
        modelBuilder.Entity<Soldier>()
            .HasOne<SoldierRank>(x => x.SoldierRank).WithMany(x => x.Soldiers);

        modelBuilder.Entity<Soldier>()
            .HasMany<SoldierMedal>(x => x.SoldierMedals).WithMany(x => x.Soldiers);

        modelBuilder.Entity<Soldier>()
            .HasMany<SoldierExpertise>(x => x.SoldierExpertises).WithMany(x => x.Soldiers);

        // Vehicle
        modelBuilder.Entity<Vehicle>()
            .HasOne<VehicleType>(x => x.VehicleType).WithMany();

        // Weapon
        modelBuilder.Entity<Weapon>()
            .HasOne<WeaponType>(x => x.WeaponType).WithMany();

        // To avoid duplicate data
        modelBuilder.Entity<SoldierExpertise>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<MissionStatus>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<SoldierMedal>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<SoldierRank>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<VehicleType>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<WeaponType>().HasIndex(x => x.Name).IsUnique();
    }
}
