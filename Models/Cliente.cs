using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }

        public string UriImagem { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }
    }
}