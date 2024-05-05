using System.ComponentModel.DataAnnotations;

namespace ExamanApp.Models
{
    public class Architecte
    {
        [Key]
        public int ArchitecteId { get; set; }
        [Required]
        public string NomArchitecte { get; set; }
        public string prenomArchitecte { get; set; }
        public string telephone { get; set; }

    }
}
