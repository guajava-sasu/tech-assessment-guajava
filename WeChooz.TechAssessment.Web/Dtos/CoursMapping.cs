using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Web.Data;
using WeChooz.TechAssessment.Web.Dtos;

namespace WeChooz.TechAssessment.Web.Dtos;

public static class CoursMapping
{
    public static IQueryable<CoursDto> SelectCoursDto(this IQueryable<Cours> query)
        => query.Select(c => new CoursDto(
            c.Id,
            c.Nom,
            c.DescriptionCourte,
            c.DureeEnJours,
            c.CoursPopulationCibles
                .OrderBy(x => x.PopulationCible.Libelle)
                .Select(x => new PopulationCibleDto(
                    x.PopulationCible.Id,
                    x.PopulationCible.Libelle
                ))
                .ToList(),
            c.CapaciteMaximale,
            new FormateurDto(
                c.Formateur.Id,
                c.Formateur.Nom,
                c.Formateur.Prenom
            ),
            new ModeDelivranceDto(
                c.ModeDelivrance.Id,
                c.ModeDelivrance.Libelle
            ),
            c.DateCreation
        ));
}