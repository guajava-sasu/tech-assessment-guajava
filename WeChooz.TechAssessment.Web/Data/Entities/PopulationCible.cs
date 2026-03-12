using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Web.Data
{
    [Table("PopulationCible")]
    public class PopulationCible
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        public ICollection<CoursPopulationCible> CibleCoursPopulationCibles { get; set; } = new List<CoursPopulationCible>();

        public IEnumerable<SessionsPopulationCible> SessionsPopulationCibles { get; set; } = new List<SessionsPopulationCible>();

    }
}
