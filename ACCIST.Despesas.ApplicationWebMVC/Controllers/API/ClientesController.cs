using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ACCIST.Despesas.ApplicationWebMVC.Models;
using ACCIST.Despesas.ApplicationWebMVC.ViewModels;
using ACCIST.Despesas.ApplicationWebMVC.Interfaces;
using ACCIST.Despesas.ApplicationWebMVC.Services;

namespace ACCIST.Despesas.ApplicationWebMVC.Controllers.API
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService = new ClienteAppService();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Clientes
        public IQueryable<ClienteViewModel> GetClienteViewModels()
        {
            return _clienteAppService.RetornarAtivos().AsQueryable();
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult GetClienteViewModel(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.RetornaPorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return Ok(clienteViewModel);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClienteViewModel(Guid id, ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clienteViewModel.Id)
            {
                return BadRequest();
            }

            var clienteAtualizado = _clienteAppService.Atualizar(clienteViewModel);


            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult PostClienteViewModel(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteInserido = _clienteAppService.Criar(clienteViewModel);

            return CreatedAtRoute("DefaultApi", new { id = clienteViewModel.Id }, clienteViewModel);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult DeleteClienteViewModel(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.RetornaPorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            _clienteAppService.Inativar(clienteViewModel);

            return Ok(clienteViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            this._clienteAppService.Dispose();
        }

        private bool ClienteViewModelExists(Guid id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}