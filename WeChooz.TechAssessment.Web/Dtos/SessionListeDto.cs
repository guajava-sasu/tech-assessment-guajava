using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
{
    public sealed record SessionListeDto(
        int Id,
        string NomCours,
        string DescriptionCourte,
        string PopulationCible,
        DateTime DateDebut,
        int DureeEnJours,
        string ModeDelivrance,
        int NombrePlacesRestantes,
        string FormateurNom
    );
}
