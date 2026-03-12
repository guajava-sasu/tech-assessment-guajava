using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Web.Data
{
    [Table("Sessions")]
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cours")]
        public int IdCours { get; set; }

        public Cours Cours { get; set; }

        [ForeignKey("ModeDelivrance")]
        public int IdModeDelivrance { get; set; }

        public ModeDelivrance ModeDelivrance { get; set; }

        [ForeignKey("PopulationCible")]
        public int IdPopulationCible { get; set; }

        public IEnumerable<SessionsPopulationCible>  SessionsPopulationCibles { get; set; } =  new List<SessionsPopulationCible>();

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        [StringLength(255)]
        public string Lieu { get; set; }

        [Required]
        public int NombrePlacesMax { get; set; }

        [Required]
        public int NombrePlacesRestantes { get; set; }

    }
}
