using ExamanApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamanApp.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Projet> Projet { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Facture> Facture { get; set; }
        public DbSet<Architecte> Architecte { get; set; }

    }
}
