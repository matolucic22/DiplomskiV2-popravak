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
    [RoutePrefix("api/kviz")]
    public class KvizController : ApiController
    {
        private IKvizService kvizService;
        public KvizController(IKvizService kvizService)
        {
            this.kvizService = kvizService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllKvizAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KvizViewModel>>(await kvizService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetKvizAsync(Guid id)
        {
            try
            {
                var response = Mapper.Map<KvizViewModel>(await kvizService.GetAsync(id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<HttpResponseMessage> AddKvizAsync(KvizViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                var response = await kvizService.AddAsync(Mapper.Map<IKvizDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPut]
        [ValidateModel]
        public async Task<HttpResponseMessage> UpdateKvizAsync(KvizViewModel updateK)
        {
            try
            {

                KvizViewModel toBeUpdated = Mapper.Map<KvizViewModel>(await kvizService.GetAsync(updateK.KvizId));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije pronađen trazeni kviz.");
                }
                else 
                {
                    toBeUpdated.Odg1 = updateK.Odg1;
                    toBeUpdated.Odg2 = updateK.Odg2;
                    toBeUpdated.Odg3 = updateK.Odg3;
                    toBeUpdated.Pitanje = updateK.Pitanje;
                    toBeUpdated.Tocan_odgovor = updateK.Tocan_odgovor;
                }
                var response = await kvizService.UpdateAsync(Mapper.Map<IKvizDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska prilikom promjene");
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteKvizAsync(Guid id)
        {
            try
            {
                var response = await kvizService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }
    }
}
