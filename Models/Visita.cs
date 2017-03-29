using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models
{
    public class Visita : BaseEntity
    {

        public Guid Id_Cliente { get; set; }

        public Guid Id_Despesa { get; set; }

        public DateTime DataVisita { get; set; }

        public TimeSpan HoraChegada { get; set; }

        public TimeSpan HoraSaida { get; set; }

        public TimeSpan TempoImprodutivo { get; set; }

        public TimeSpan IntervaloAlmoco { get; set; }

        public string ObservacoesVisita { get; set; }

        public virtual Despesa Despesa { get; set; }

        public virtual Cliente Cliente { get; set; }



    }
}