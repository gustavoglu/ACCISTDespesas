using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.EntityConfig
{
    public class ClienteEntityConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityConfig()
        {
            this.ToTable("cliente");

            this.HasKey(c => c.Id);

        }
    }
}