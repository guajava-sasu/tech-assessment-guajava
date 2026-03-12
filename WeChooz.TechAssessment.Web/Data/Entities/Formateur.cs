using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Web.Data
{
    [Table("Formateurs")]
    public class Formateur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }

        public ICollection<Cours> Cours { get; set; } = new List<Cours>();
    }
}
