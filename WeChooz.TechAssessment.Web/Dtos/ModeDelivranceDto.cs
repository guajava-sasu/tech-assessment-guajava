using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
{
    public sealed record ModeDelivranceDto(
        int Id,
        string Libelle
    );
}
