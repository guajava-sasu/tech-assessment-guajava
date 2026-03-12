namespace WeChooz.TechAssessment.Web.Data.Dtos
{
    public sealed record SessionDto(
        int Id,
        int IdCours,
        int IdModeDelivrance,
        DateTime DateDebut,
        DateTime DateFin,
        string? Lieu,
        int NombrePlacesMax,
        int NombrePlacesRestantes
    );
}