using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Web.Data
{
    [Table("ModeDelivrance")]
    public class ModeDelivrance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }
        public ICollection<Cours> Cours { get; set; } = new List<Cours>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
