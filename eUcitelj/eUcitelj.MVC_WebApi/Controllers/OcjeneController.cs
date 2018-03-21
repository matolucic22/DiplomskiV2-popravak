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
    [RoutePrefix("api/Ocjene")]
    public class OcjeneController : ApiController
    {
        protected IOcjeneService OcjeneService { get; set; }

        public OcjeneController(IOcjeneService ocjeneService)
        {
            this.OcjeneService = ocjeneService;
        }

        [HttpGet]
        [Route("getAllO")]
        public async Task<HttpResponseMessage> GetAllOcjene()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<OcjeneViewModel>>(await OcjeneService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("getO")]
        public async Task<HttpResponseMessage> GetOcjene(Guid Id)
        {
            try
            {
                var response = Mapper.Map<OcjeneViewModel>(await OcjeneService.Get(Id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("addO")]
        public async Task<HttpResponseMessage> AddOcjene(OcjeneViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                addObj.OcjeneId = Guid.NewGuid();
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
        [Route("updateO")]
        public async Task<HttpResponseMessage> UpdateOcjene(OcjeneViewModel updateO)
        {
            try
            {

                OcjeneViewModel toBeUpdated = Mapper.Map<OcjeneViewModel>(await OcjeneService.Get(updateO.OcjeneId));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije moguće završiti radnju.");
                }
                if (updateO.OcjeneId==null||updateO.PredmetiId==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska u unosu!");
                }
                else
                {
                    toBeUpdated.Ocjena = updateO.Ocjena;
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
        [Route("deleteO")]
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
