using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.ViewModels
{
    public class VisitaViewModel
    {
        public VisitaViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid Id_Cliente { get; set; }

        public Guid Id_Despesa { get; set; }

        public DateTime DataVisita { get; set; }

        public TimeSpan HoraChegada { get; set; }

        public TimeSpan HoraSaida { get; set; }

        public TimeSpan TempoImprodutivo { get; set; }

        public TimeSpan IntervaloAlmoco { get; set; }

        public string ObservacoesVisita { get; set; }
      
        public DespesaViewModel Despesa { get; set; }
      
        public ClienteViewModel Cliente { get; set; }
    }
}