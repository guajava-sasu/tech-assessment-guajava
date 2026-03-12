using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
{
    public sealed record CoursDetailDto(
        int Id,
        string Nom,
        string DescriptionCourte,
        string DescriptionLongueMarkdown,
        int DureeEnJours,
        string PopulationCible,
        int CapaciteMaximale,
        int FormateurId,
        string FormateurNom,
        string FormateurPrenom,
        DateTime DateCreation
    );
}
