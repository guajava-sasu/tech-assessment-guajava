using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
{
    public sealed record CoursDto(
        int Id,
        string Nom,
        string DescriptionCourte,
        int DureeEnJours,
        List<PopulationCibleDto> PopulationCible,
        int CapaciteMaximale,
        FormateurDto Formateur,
        DateTime DateCreation
    );
}
