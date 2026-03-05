using Microsoft.EntityFrameworkCore;

namespace WeChooz.TechAssessment.Web.Data;

public sealed class FormationDbContext(DbContextOptions<FormationDbContext> options)
    : DbContext(options)
{
    // Ajoutez vos DbSet<> quand vos entités existent.
    // public DbSet<Session> Sessions => Set<Session>();
}