using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Web.Data;

namespace WeChooz.TechAssessment.Web.Dtos;


public sealed  record FormateursDto(
        int Id,
        string Nom,
        string DescriptionCourte,
        int DureeEnJours,
        string PopulationCible,
        int CapaciteMaximale,
        int FormateurId,
        DateTime DateCreation
    );
