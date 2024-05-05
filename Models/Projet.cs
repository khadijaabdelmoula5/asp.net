using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamanApp.Models
{
    public class Projet
    {
        [Key]
        public int ProjetId { get; set; }
        [Required]
        public string NomProjet { get; set; }
        public string addresseProjet { get; set; }
        public string Description { get; set; }
        public string StatutProjet { get; set; }



        [ForeignKey("ClientID")]
        public int? ClientId { get; set; }
        public virtual Client? Client { get; set; }

    }
}
