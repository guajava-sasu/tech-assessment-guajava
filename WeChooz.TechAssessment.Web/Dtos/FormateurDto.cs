using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
{
    public sealed record FormateurDto(
        int Id,
        string Nom,
        string Prenom
    );
}
