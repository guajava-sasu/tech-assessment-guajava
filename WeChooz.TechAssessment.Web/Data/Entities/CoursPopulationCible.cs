namespace WeChooz.TechAssessment.Web.Data
{
    public sealed class CoursPopulationCible
    {
        public int IdCours { get; set; }

        public Cours Cours { get; set; } = null!;

        public int IdPopulationCible { get; set; }

        public PopulationCible PopulationCible { get; set; } = null!;
    }
}