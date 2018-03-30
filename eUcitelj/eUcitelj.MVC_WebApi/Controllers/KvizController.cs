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
    [RoutePrefix("api/Kviz")]
    public class KvizController : ApiController
    {
        protected IKvizService KvizService { get; set; }
        public KvizController(IKvizService kvizService)
        {
            this.KvizService = kvizService;
        }

        [HttpGet]
        [Route("getAllK")]
        public async Task<HttpResponseMessage> GetAllKviz()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KvizViewModel>>(await KvizService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("getK")]
        public async Task<HttpResponseMessage> GetKviz(Guid Id)
        {
            try
            {
                var response = Mapper.Map<KvizViewModel>(await KvizService.Get(Id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("addK")]
        public async Task<HttpResponseMessage> AddKviz(KvizViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                addObj.KvizId = Guid.NewGuid();
                var response = await KvizService.Add(Mapper.Map<IKvizDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("updateK")]
        public async Task<HttpResponseMessage> UpdateKviz(KvizViewModel updateK)
        {
            try
            {

                KvizViewModel toBeUpdated = Mapper.Map<KvizViewModel>(await KvizService.Get(updateK.KvizId));

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
                var response = await KvizService.Update(Mapper.Map<IKvizDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("deleteK")]
        public async Task<HttpResponseMessage> DeleteKviz(Guid Id)
        {
            try
            {
                var response = await KvizService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
