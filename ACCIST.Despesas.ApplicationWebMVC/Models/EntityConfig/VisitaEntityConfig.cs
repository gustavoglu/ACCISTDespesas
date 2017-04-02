using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.EntityConfig
{
    public class VisitaEntityConfig : EntityTypeConfiguration<Visita>
    {
        public VisitaEntityConfig()
        {
            ToTable("visita");

            HasKey(v => v.Id);

            HasRequired(v => v.Despesa)
                .WithRequiredPrincipal()
                .Map(m => m.MapKey("id_despesa"));

            HasRequired(v => v.Cliente)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.Id_Cliente);


        }
    }
}