using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ACCIST.Despesas.ApplicationWebMVC.Models.EntityConfig;

namespace ACCIST.Despesas.ApplicationWebMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public string UriImagem { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClienteEntityConfig());
            modelBuilder.Configurations.Add(new VisitaEntityConfig());
            modelBuilder.Configurations.Add(new DespesaEntityConfig());
            modelBuilder.Configurations.Add(new Despesa_AnexoEntityConfig());
        }

        public System.Data.Entity.DbSet<Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<Despesa> Despesas { get; set; }

        public System.Data.Entity.DbSet<Visita> Visitas { get; set; }

        public System.Data.Entity.DbSet<Despesa_Anexo> Despesa_Anexo { get; set; }
    }
}