using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ExamanApp.Models
{
    public class Facture
    {
        [Key]
        public int FactureId { get; set; }
        public string Montant { get; set; }

        [ForeignKey("ProjetID")]
        public int? ProjetId { get; set; }

        public virtual Projet? Projet { get; set; }
    }
}
