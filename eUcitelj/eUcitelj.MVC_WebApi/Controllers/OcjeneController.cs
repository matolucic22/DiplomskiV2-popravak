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
    [RoutePrefix("api")]
    public class OcjeneController : ApiController
    {
        protected IOcjeneService OcjeneService { get; set; }

        public OcjeneController(IOcjeneService ocjeneService)
        {
            this.OcjeneService = ocjeneService;
        }

        [HttpGet]
        [Route("Ocjene")]
        public async Task<HttpResponseMessage> GetAllOcjene()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<OcjenaViewModel>>(await OcjeneService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("Ocjene")]
        public async Task<HttpResponseMessage> GetOcjene(Guid Id)
        {
            try
            {
                var response = Mapper.Map<OcjenaViewModel>(await OcjeneService.Get(Id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("Ocjene")]
        public async Task<HttpResponseMessage> AddOcjene(OcjenaViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                addObj.OcjenaId = Guid.NewGuid();
                addObj.DatumUpisa = DateTime.Now.Date;
                var response = await OcjeneService.Add(Mapper.Map<IOcjeneDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("Ocjene")]
        public async Task<HttpResponseMessage> UpdateOcjene(OcjenaViewModel updateO)//Nepotrebna metoda
        {
            try
            {

                OcjenaViewModel toBeUpdated = Mapper.Map<OcjenaViewModel>(await OcjeneService.Get(updateO.OcjenaId));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije moguće završiti radnju.");
                }
                else
                {
                    toBeUpdated.Ocj = updateO.Ocj;
                }
                var response = await OcjeneService.Update(Mapper.Map<IOcjeneDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("Ocjene")]
        public async Task<HttpResponseMessage> DeleteOcjene(Guid Id)
        {
            try
            {
                var response = await OcjeneService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
