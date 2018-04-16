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
        protected IKvizService KvizService { get; set; }
        public KvizController(IKvizService kvizService)
        {
            this.KvizService = kvizService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllKvizAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KvizViewModel>>(await KvizService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetKvizAsync(Guid Id)
        {
            try
            {
                var response = Mapper.Map<KvizViewModel>(await KvizService.GetAsync(Id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddKvizAsync(KvizViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                addObj.KvizId = Guid.NewGuid();
                var response = await KvizService.AddAsync(Mapper.Map<IKvizDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateKvizAsync(KvizViewModel updateK)
        {
            try
            {

                KvizViewModel toBeUpdated = Mapper.Map<KvizViewModel>(await KvizService.GetAsync(updateK.KvizId));

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
                var response = await KvizService.UpdateAsync(Mapper.Map<IKvizDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteKvizAsync(Guid Id)
        {
            try
            {
                var response = await KvizService.DeleteAsync(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
