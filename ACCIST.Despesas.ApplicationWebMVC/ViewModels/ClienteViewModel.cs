using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.ViewModels
{
    public class ClienteViewModel
    {

        public ClienteViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Visitas = new List<VisitaViewModel>();
        }
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public ICollection<VisitaViewModel> Visitas{ get; set; }
    }
}