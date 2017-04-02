using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models
{
    public class Despesa_Anexo : BaseEntity
    {
        public string Descricao { get; set; }

        public string Uri { get; set; }

        public Guid Id_Despesa { get; set; }

        public virtual Despesa Despesa { get; set; }
    }
}