using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.ViewModels
{
    public class ClienteViewModel
    {

        public ClienteViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }
    }
}