using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.ViewModels
{
    public class DespesaViewModel
    {
        public DespesaViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public double Quilometragem { get; set; }

        public double Almoco { get; set; }

        public double Estacionamento { get; set; }

        public double Outros { get; set; }

        public string ObservacoesDespesa { get; set; }

        public Guid Id_Visita { get; set; }

        public virtual VisitaViewModel Visita { get; set; }
    }
}
}