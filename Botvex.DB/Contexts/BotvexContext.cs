using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models;
using Botvex.DB.Repositories.Beatmapset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Convert = Botvex.DB.Models.Convert;

namespace Botvex.DB.Contexts;

public class BotvexEnvContextFactory :IDesignTimeDbContextFactory<BotvexContext> 
{
    public BotvexContext CreateDbContext(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BotvexContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultBotvexDbConnection"));

        return new BotvexContext(optionsBuilder.Options);
    }
}

public partial class BotvexContext : DbContext, IBotvexContext
{
    private IBotvexContext _botvexContextImplementation;
    public BotvexContext(DbContextOptions<BotvexContext> options) : base(options) { }

    public virtual DbSet<Beatmap> Beatmaps { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<Beatmapset> Beatmapsets { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;
    public virtual DbSet<Language> Languages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Convert>();

        modelBuilder.Entity<Beatmapset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Beatmapset_Id");
            entity.Property(e => e.Id).ValueGeneratedNever();
            
            entity.Ignore(e => e.Beatmaps);

            entity.ToTable("beatmapsets");

            entity.Property(e => e.Artist).HasMaxLength(100);
            entity.Property(e => e.Artist_unicode).HasMaxLength(100);
            // entity.Property(e => e.Covers).HasMaxLength(100);
            entity.Property(e => e.Creator).HasMaxLength(100);
            entity.Property(e => e.Favourite_count).HasColumnType("int");
            entity.Property(e => e.Nsfw).HasConversion<int>();
            entity.Property(e => e.Offset).HasColumnType("int");
            entity.Property(e => e.Play_count).HasColumnType("int");
            entity.Property(e => e.Preview_url).HasMaxLength(100);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.Spotlight).HasConversion<int>();
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Title_unicode).HasMaxLength(100);
            entity.HasOne(bse => bse.User)
                .WithMany(u => u.Beatmapsets)
                .HasForeignKey(bse => bse.User_id)
                .HasConstraintName("FK_UserToBeatmapset")
                .OnDelete(DeleteBehavior.NoAction);
            entity.Property(e => e.User_id).HasColumnType("int");
            entity.Property(e => e.Video).HasConversion<int>();
            entity.Property(e => e.Has_favourited).HasConversion<int>();
            entity.Property(e => e.Track_id).HasColumnType("int");
        });
        
        modelBuilder.Entity<Beatmap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BeatmapId");
            entity.Property(e => e.Id).ValueGeneratedNever();
            
            entity.ToTable("beatmaps");
            
            entity.Property(e => e.Difficulty_Rating).HasColumnType("float");
            entity.Property(e => e.Mode).HasMaxLength(25);
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.Total_Length).HasColumnType("int");
            entity.Property(e => e.User_Id).HasColumnType("int");
            entity.Property(e => e.Version).HasMaxLength(100);
            entity.HasOne(be => be.User)
                .WithMany(u => u.Beatmaps)
                .HasForeignKey(be => be.User_Id)
                .HasConstraintName("FK_UserToBeatmap")
                .OnDelete(DeleteBehavior.NoAction);
            entity.Property(e => e.User_Id).HasColumnType("int");
            entity.Property(e => e.Beatmapset_Id).HasColumnType("int");
            entity.HasOne(be => be.Beatmapset)
                .WithMany(bse => bse.Beatmaps)
                .HasForeignKey(be => be.Beatmapset_Id)
                .HasConstraintName("FK_BeatmapToSet")
                .OnDelete(DeleteBehavior.NoAction);
            entity.Property(e => e.Checksum).HasMaxLength(100);
            entity.Property(e => e.Max_combo).HasColumnType("int");
            entity.Property(e => e.Accuracy).HasColumnType("float");
            entity.Property(e => e.Ar).HasColumnType("float");
            entity.Property(e => e.Convert).HasConversion<int>();
            entity.Property(e => e.Count_circles).HasColumnType("int");
            entity.Property(e => e.Count_sliders).HasColumnType("int");
            entity.Property(e => e.Count_spinners).HasColumnType("int");
            entity.Property(e => e.Cs).HasColumnType("float");
            entity.Property(e => e.Deleted_at).HasMaxLength(100);
            entity.Property(e => e.Drain).HasColumnType("float");
            entity.Property(e => e.Hit_length).HasColumnType("int");
            entity.Property(e => e.Is_scoreable).HasConversion<int>();
            entity.Property(e => e.Last_updated).HasMaxLength(100);
            entity.Property(e => e.Mode_int).HasColumnType("int");
            entity.Property(e => e.Passcount).HasColumnType("int");
            entity.Property(e => e.Playcount).HasColumnType("int");
            entity.Property(e => e.Ranked).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(100);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GenreId");

            entity.ToTable("genres");

            entity.HasOne(g => g.Beatmapset)
                .WithOne(bse => bse.Genre)
                .HasForeignKey<Genre>(g => g.Beatmapset_Id)
                .HasConstraintName("FK_GenreToSet");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LanguageId");

            entity.ToTable("languages");

            entity.HasOne(l => l.Beatmapset)
                .WithOne(bse => bse.Language)
                .HasForeignKey<Language>(l => l.Beatmapset_Id)
                .HasConstraintName("FK_LanguageToSet");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserId");
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.ToTable("users");

            entity.Property(e => e.Avatar_url).HasMaxLength(100);
            entity.Property(e => e.Country_code).HasMaxLength(10);
            entity.Property(e => e.Default_group).HasMaxLength(100);
            entity.Property(e => e.Is_active).HasConversion<int>();
            entity.Property(e => e.Is_bot).HasConversion<int>();
            entity.Property(e => e.Is_deleted).HasConversion<int>();
            entity.Property(e => e.Is_online).HasConversion<int>();
            entity.Property(e => e.Is_supporter).HasConversion<int>();
            entity.Property(e => e.Last_visit).HasMaxLength(100);
            entity.Property(e => e.Pm_friends_only).HasConversion<int>();
            entity.Property(e => e.Profile_colour).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });
        
        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}