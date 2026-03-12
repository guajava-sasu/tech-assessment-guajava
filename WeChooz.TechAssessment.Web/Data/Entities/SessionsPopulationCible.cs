namespace WeChooz.TechAssessment.Web.Data
{
    public sealed class SessionsPopulationCible
    {
        public int IdSession { get; set; }

        public Session Session { get; set; } = null!;

        public int IdPopulationCible { get; set; }

        public PopulationCible PopulationCible { get; set; } = null!;
    }
}