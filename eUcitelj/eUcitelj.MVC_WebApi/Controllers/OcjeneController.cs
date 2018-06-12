using AutoMapper;
using eUcitelj.Model.Common;
using eUcitelj.MVC_WebApi.ViewModels;
using eUcitelj.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eUcitelj.MVC_WebApi.Controllers
{
    [RoutePrefix("api/ocjene")]
    public class OcjeneController : ApiController
    {
        private IOcjeneService ocjeneService;

        public OcjeneController(IOcjeneService ocjeneService)
        {
            this.ocjeneService = ocjeneService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllOcjeneAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<OcjenaViewModel>>(await ocjeneService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetOcjeneAsync(Guid id)
        {
            try
            {
                var response = Mapper.Map<OcjenaViewModel>(await ocjeneService.GetAsync(id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<HttpResponseMessage> AddOcjeneAsync(OcjenaViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                var response = await ocjeneService.AddAsync(Mapper.Map<IOcjeneDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPut]
        [ValidateModel]
        public async Task<HttpResponseMessage> UpdateOcjeneAsync(OcjenaViewModel updateO)//Nepotrebna metoda
        {
            try
            {

                OcjenaViewModel toBeUpdated = Mapper.Map<OcjenaViewModel>(await ocjeneService.GetAsync(updateO.OcjenaId));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije moguće završiti radnju.");
                }
                else
                {
                    toBeUpdated.Ocj = updateO.Ocj;
                }
                var response = await ocjeneService.UpdateAsync(Mapper.Map<IOcjeneDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska prilikom promjene");
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOcjeneAsync(Guid id)
        {
            try
            {
                var response = await ocjeneService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }

        [HttpGet]
        [Route("korisnikid")]
        public async Task<HttpResponseMessage> GetByKorisnikIdAsync(Guid korisnikId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<OcjenaViewModel>>(await ocjeneService.GetByKorisnikIdAsync(korisnikId));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }
    }
}
