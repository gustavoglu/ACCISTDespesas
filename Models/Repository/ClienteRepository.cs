﻿using ACCIST.Despesas.ApplicationWebMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Models.Repository
{
    public class ClienteRepository : Repository<Cliente> ,IClienteRepository 
    {
    }
}