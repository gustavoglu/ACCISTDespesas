using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.ViewModels
{
    public class Despesa_AnexoViewModel
    {
        public Despesa_AnexoViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Uri { get; set; }

        public Guid Id_Despesa { get; set; }

        public DespesaViewModel Despesa { get; set; }
    }
}