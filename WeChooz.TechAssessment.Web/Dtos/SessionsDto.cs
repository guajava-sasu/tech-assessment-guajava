using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos
{
    public sealed record SessionDto(
        int Id,
        int IdCours,
        int IdModeDelivrance,
        int IdPopulationCible,
        DateTime DateDebut,
        DateTime DateFin,
        string Lieu,
        int NombrePlacesMax,
        int NombrePlacesRestantes
    );
}
