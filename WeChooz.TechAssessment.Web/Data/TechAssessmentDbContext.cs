using Microsoft.EntityFrameworkCore;

namespace WeChooz.TechAssessment.Web.Data
{
    public class TechAssessmentDbContext : DbContext
    {
        public TechAssessmentDbContext(DbContextOptions<TechAssessmentDbContext> options) : base(options) { }

        public DbSet<Formateur> Formateurs { get; set; } = null!;
        public DbSet<Cours> Cours { get; set; } = null!;
        public DbSet<Participant> Participants { get; set; } = null!;
        public DbSet<ModeDelivrance> ModesDelivrance { get; set; } = null!;
        public DbSet<PopulationCible> PopulationsCibles { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;

        public DbSet<CoursPopulationCible> CoursPopulationCible { get; set; } = null!;
        public DbSet<SessionsPopulationCible> SessionsPopulationCible { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Formateur>(e =>
            {
                e.ToTable("Formateurs", "dbo");

                e.Property(x => x.Nom).HasMaxLength(100).IsRequired();
                e.Property(x => x.Prenom).HasMaxLength(100).IsRequired();

                e.HasIndex(x => new { x.Nom, x.Prenom }).IsUnique();
            });

            modelBuilder.Entity<Cours>(e =>
            {
                e.ToTable("Cours", "dbo");

                e.Property(x => x.Nom).HasMaxLength(255).IsRequired();
                e.Property(x => x.DescriptionCourte).HasMaxLength(500).IsRequired();
                e.Property(x => x.DescriptionLongueMarkdown).IsRequired();

                e.Property(x => x.DateCreation).HasDefaultValueSql("GETDATE()");
                e.HasOne(x => x.ModeDelivrance).WithMany(x=>x.Cours).HasForeignKey(x => x.IdModeDelivrance)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasOne(x => x.Formateur)
                    .WithMany(x => x.Cours)
                    .HasForeignKey(x => x.IdFormateur)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Participant>(e =>
            {
                e.ToTable("Participants", "dbo");

                e.Property(x => x.Nom).HasMaxLength(100).IsRequired();
                e.Property(x => x.Prenom).HasMaxLength(100).IsRequired();
                e.Property(x => x.Email).HasMaxLength(255).IsRequired();
                e.Property(x => x.NomEntreprise).HasMaxLength(255).IsRequired();

                e.Property(x => x.DateCreation).HasDefaultValueSql("GETDATE()");

                e.HasIndex(x => x.Email).IsUnique();
            });

            modelBuilder.Entity<ModeDelivrance>(e =>
            {
                e.ToTable("ModeDelivrance", "dbo");

                e.Property(x => x.Libelle).HasMaxLength(50).IsRequired();
                e.HasIndex(x => x.Libelle).IsUnique();
            });

            modelBuilder.Entity<PopulationCible>(e =>
            {
                e.ToTable("PopulationCible", "dbo");

                e.Property(x => x.Libelle).HasMaxLength(50).IsRequired();
                e.HasIndex(x => x.Libelle).IsUnique();
            });

            modelBuilder.Entity<Session>(e =>
            {
                e.ToTable("Sessions", "dbo");

                e.Property(x => x.Lieu).HasMaxLength(255);

                e.HasOne(x => x.Cours)
                    .WithMany(x => x.Sessions)
                    .HasForeignKey(x => x.IdCours)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.ModeDelivrance)
                    .WithMany(x => x.Sessions)
                    .HasForeignKey(x => x.IdModeDelivrance)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CoursPopulationCible>(e =>
            {
                e.ToTable("CoursPopulationCible", "dbo");

                e.HasKey(x => new { x.IdCours, x.IdPopulationCible });

                e.HasOne(x => x.Cours)
                    .WithMany(x => x.CoursPopulationCibles)
                    .HasForeignKey(x => x.IdCours)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.PopulationCible)
                    .WithMany(x => x.CibleCoursPopulationCibles)
                    .HasForeignKey(x => x.IdPopulationCible)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SessionsPopulationCible>(e =>
            {
                e.ToTable("SessionsPopulationCible", "dbo");

                e.HasKey(x => new { x.IdSession, x.IdPopulationCible });

                e.HasOne(x => x.Session)
                    .WithMany(x => x.SessionsPopulationCibles)
                    .HasForeignKey(x => x.IdSession)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.PopulationCible)
                    .WithMany(x => x.SessionsPopulationCibles)
                    .HasForeignKey(x => x.IdPopulationCible)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
