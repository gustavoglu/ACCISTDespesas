using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.EntityConfig
{
    public class DespesaEntityConfig : EntityTypeConfiguration<Despesa>
    {
        public DespesaEntityConfig()
        {
            ToTable("despesa");

            HasKey(d => d.Id);

            HasRequired(d => d.Visita)
                .WithRequiredPrincipal()
                .Map(m => m.MapKey("id_visita"));
        }
    }
}