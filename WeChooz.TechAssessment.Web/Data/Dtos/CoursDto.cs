namespace WeChooz.TechAssessment.Web.Data.Dtos
{
    public sealed record CoursDto(
        int Id,
        string Nom,
        string DescriptionCourte,
        string DescriptionLongueMarkdown,
        int DureeEnJours,
        int CapaciteMaximale,
        int? IdFormateur,
        List<PopulationCible> PopulationCible,
        DateTime DateCreation
    );
}