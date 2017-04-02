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
using System.Threading.Tasks;
using System.Web;

namespace ACCIST.Despesas.ApplicationWebMVC.Controllers.API
{
    public class VisitaController : ApiController
    {
        private readonly IVisitaAppService _visitaAppService = new VisitaAppService();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Visita
        public IQueryable<VisitaViewModel> GetVisitaViewModels()
        {
            return _visitaAppService.RetornarAtivos().AsQueryable();
        }

        // GET: api/Visita/5
        [ResponseType(typeof(VisitaViewModel))]
        public IHttpActionResult GetVisitaViewModel(Guid id)
        {
            VisitaViewModel visitaViewModel = _visitaAppService.RetornaPorId(id);

            if (visitaViewModel == null)
            {
                return NotFound();
            }

            return Ok(visitaViewModel);
        }

        // PUT: api/Visita/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitaViewModel(Guid id, VisitaViewModel visitaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitaViewModel.Id)
            {
                return BadRequest();
            }


            _visitaAppService.Atualizar(visitaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Visita
        [ResponseType(typeof(VisitaViewModel))]
        public IHttpActionResult PostVisitaViewModel(VisitaViewModel visitaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _visitaAppService.Criar(visitaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = visitaViewModel.Id }, visitaViewModel);
        }

        // DELETE: api/Visita/5
        [ResponseType(typeof(VisitaViewModel))]
        public IHttpActionResult DeleteVisitaViewModel(Guid id)
        {
            VisitaViewModel visitaViewModel = _visitaAppService.RetornaPorId(id);
            if (visitaViewModel == null)
            {
                return NotFound();
            }

            _visitaAppService.Inativar(visitaViewModel);

            return Ok(visitaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _visitaAppService.Dispose();
        }

        private bool VisitaViewModelExists(Guid id)
        {
            return db.Visitas.Count(e => e.Id == id) > 0;
        }

        [Route("api/Cliente/Upload")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> PostUserImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {

                            var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName + extension);

                            postedFile.SaveAs(filePath);

                        }
                    }

                }
                //var res = string.Format("Please Upload a image.");
                //dict.Add("error", res);
                //return Request.CreateResponse(HttpStatusCode.NotFound, dict);

           
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }

            var message1 = string.Format("Image Updated Successfully.");
            return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
        }
    }
}

