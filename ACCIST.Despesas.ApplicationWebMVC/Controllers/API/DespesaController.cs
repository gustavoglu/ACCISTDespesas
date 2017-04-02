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
    public class DespesaController : ApiController
    {
        private readonly IDespesaAppService _despesaAppService = new DespesaAppService();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DespesaViewModels
        public IQueryable<DespesaViewModel> GetDespesaViewModels()
        {
            return _despesaAppService.RetornarAtivos().AsQueryable();
        }

        // GET: api/DespesaViewModels/5
        [ResponseType(typeof(DespesaViewModel))]
        public IHttpActionResult GetDespesaViewModel(Guid id)
        {
            DespesaViewModel despesaViewModel = _despesaAppService.RetornaPorId(id);
            if (despesaViewModel == null)
            {
                return NotFound();
            }

            return Ok(despesaViewModel);
        }

        // PUT: api/DespesaViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDespesaViewModel(Guid id, DespesaViewModel despesaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != despesaViewModel.Id)
            {
                return BadRequest();
            }

            _despesaAppService.Atualizar(despesaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DespesaViewModels
        [ResponseType(typeof(DespesaViewModel))]
        public IHttpActionResult PostDespesaViewModel(DespesaViewModel despesaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _despesaAppService.Criar(despesaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = despesaViewModel.Id }, despesaViewModel);
        }

        // DELETE: api/DespesaViewModels/5
        [ResponseType(typeof(DespesaViewModel))]
        public IHttpActionResult DeleteDespesaViewModel(Guid id)
        {
            DespesaViewModel despesaViewModel = _despesaAppService.RetornaPorId(id);

            if (despesaViewModel == null)
            {
                return NotFound();
            }

            _despesaAppService.Inativar(despesaViewModel);

            return Ok(despesaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            this._despesaAppService.Dispose();
        }

        private bool DespesaViewModelExists(Guid id)
        {
            return db.Despesas.Count(e => e.Id == id) > 0;
        }
    }
}