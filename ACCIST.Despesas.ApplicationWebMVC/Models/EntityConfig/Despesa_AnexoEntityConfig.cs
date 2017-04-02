using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.EntityConfig
{
    public class Despesa_AnexoEntityConfig : EntityTypeConfiguration<Despesa_Anexo>
    {
        public Despesa_AnexoEntityConfig()
        {
            ToTable("despesa_anexo");
            HasKey(da => da.Id);

            HasRequired(da => da.Despesa)
                .WithMany(d => d.Anexos)
                .HasForeignKey(da => da.Id_Despesa);
        }
    }
}