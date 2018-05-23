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
        protected IOcjeneService OcjeneService { get; set; }

        public OcjeneController(IOcjeneService ocjeneService)
        {
            this.OcjeneService = ocjeneService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllOcjeneAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<OcjenaViewModel>>(await OcjeneService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetOcjeneAsync(Guid Id)
        {
            try
            {
                var response = Mapper.Map<OcjenaViewModel>(await OcjeneService.GetAsync(Id));
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
                var response = await OcjeneService.AddAsync(Mapper.Map<IOcjeneDomainModel>((addObj)));
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

                OcjenaViewModel toBeUpdated = Mapper.Map<OcjenaViewModel>(await OcjeneService.GetAsync(updateO.OcjenaId));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije moguće završiti radnju.");
                }
                else
                {
                    toBeUpdated.Ocj = updateO.Ocj;
                }
                var response = await OcjeneService.UpdateAsync(Mapper.Map<IOcjeneDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska prilikom promjene");
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOcjeneAsync(Guid Id)
        {
            try
            {
                var response = await OcjeneService.DeleteAsync(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }

        [HttpGet]
        [Route("korisnikid")]
        public async Task<HttpResponseMessage> GetByKorisnikIdAsync(Guid KorisnikId)
        {
            try
            {
                var response = Mapper.Map<IEnumerable<OcjenaViewModel>>(await OcjeneService.GetByKorisnikIdAsync(KorisnikId));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }
    }
}
