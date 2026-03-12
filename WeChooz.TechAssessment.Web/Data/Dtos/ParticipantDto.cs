namespace WeChooz.TechAssessment.Web.Data.Dtos
{
    public sealed record ParticipantDto(
        int Id,
        string Nom,
        string Prenom,
        string Email,
        string NomEntreprise,
        DateTime DateCreation
    );
}