using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models
{
    public class Despesa : BaseEntity
    {
        public double Quilometragem { get; set; }

        public double Almoco { get; set; }

        public double Estacionamento { get; set; }

        public double Outros { get; set; }

        public string ObservacoesDespesa { get; set; }

        public Guid Id_Visita { get; set; }

        public virtual Visita Visita{ get; set; }

        public virtual ICollection<Despesa_Anexo> Anexos{ get; set; }

    }
}