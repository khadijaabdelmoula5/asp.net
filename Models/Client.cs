using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamanApp.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string NomClient { get; set; }
        public string prenom { get; set; }
        public string addresse { get; set; }
        public string telephone { get; set; }
        public string emailClient { get; set; }

        [ForeignKey("ArchitecteId")]
        public int? ArchitecteId { get; set; }
        public virtual Architecte? Architecte { get; set; }
    }
}
