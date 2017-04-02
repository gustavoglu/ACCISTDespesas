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
using ACCIST.Despesas.ApplicationWebMVC.Interfaces;
using ACCIST.Despesas.ApplicationWebMVC.Services;
using ACCIST.Despesas.ApplicationWebMVC.ViewModels;

namespace ACCIST.Despesas.ApplicationWebMVC.Controllers.API
{
    public class Despesa_AnexoController : ApiController
    {
        private readonly IDespesa_AnexoAppService _despesa_AnexoAppService = new Despesa_AnexoAppService();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Despesa_Anexo
        public IQueryable<Despesa_AnexoViewModel> GetDespesa_Anexo()
        {
            return _despesa_AnexoAppService.RetornarAtivos().AsQueryable();
        }

        // GET: api/Despesa_Anexo/5
        [ResponseType(typeof(Despesa_AnexoViewModel))]
        public IHttpActionResult GetDespesa_Anexo(Guid id)
        {
            Despesa_AnexoViewModel despesa_Anexo = _despesa_AnexoAppService.RetornaPorId(id);
            if (despesa_Anexo == null)
            {
                return NotFound();
            }

            return Ok(despesa_Anexo);
        }

        // PUT: api/Despesa_Anexo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDespesa_Anexo(Guid id, Despesa_AnexoViewModel despesa_AnexoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != despesa_AnexoViewModel.Id)
            {
                return BadRequest();
            }

            _despesa_AnexoAppService.Criar(despesa_AnexoViewModel);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Despesa_Anexo
        [ResponseType(typeof(Despesa_AnexoViewModel))]
        public IHttpActionResult PostDespesa_Anexo(Despesa_AnexoViewModel despesa_AnexoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _despesa_AnexoAppService.Criar(despesa_AnexoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = despesa_AnexoViewModel.Id }, despesa_AnexoViewModel);
        }

        // DELETE: api/Despesa_Anexo/5
        [ResponseType(typeof(Despesa_AnexoViewModel))]
        public IHttpActionResult DeleteDespesa_Anexo(Guid id)
        {
            Despesa_AnexoViewModel despesa_AnexoViewModel = _despesa_AnexoAppService.RetornaPorId(id);
            if (despesa_AnexoViewModel == null)
            {
                return NotFound();
            }

            _despesa_AnexoAppService.Inativar(despesa_AnexoViewModel);

            return Ok(despesa_AnexoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _despesa_AnexoAppService.Dispose();
        }

        private bool Despesa_AnexoExists(Guid id)
        {
            return db.Despesa_Anexo.Count(e => e.Id == id) > 0;
        }
    }
}