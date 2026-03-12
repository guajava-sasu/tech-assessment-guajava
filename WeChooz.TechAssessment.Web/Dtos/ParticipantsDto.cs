using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
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
