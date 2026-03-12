using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Web.Data
{
    [Table("Cours")]
    public class Cours
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nom { get; set; }

        [Required]
        [StringLength(500)]
        public string DescriptionCourte { get; set; }

        [Required]
        public string DescriptionLongueMarkdown { get; set; }

        [Required]
        public int DureeEnJours { get; set; }

        [Required]

        public ICollection<CoursPopulationCible> CoursPopulationCibles { get; set; } = new List<CoursPopulationCible>();


        [ForeignKey("ModeDelivrance")]
        public int IdModeDelivrance { get; set; }
        public ModeDelivrance ModeDelivrance { get; set; }

        [Required]
        public int CapaciteMaximale { get; set; }

        [ForeignKey("Formateur")]
        public int IdFormateur { get; set; }

        public Formateur Formateur { get; set; }

        public ICollection<Session> Sessions { get; set; } = new List<Session>();

        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}
