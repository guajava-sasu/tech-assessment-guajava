using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Web.Data
{
    [Table("Participants")]
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string NomEntreprise { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}
