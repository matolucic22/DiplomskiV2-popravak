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
    public class PredmetiController : ApiController
    {
        protected IPredmetiService PredmetiService { get; set; }
        public PredmetiController(IPredmetiService predmetiService)
        {
            this.PredmetiService = predmetiService;
        }
        
        [HttpGet]
        [Route("Predmeti")]
        public async Task<HttpResponseMessage> GetAllPredmeti()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetViewModel>>(await PredmetiService.GetAll());
                
                return Request.CreateResponse(HttpStatusCode.OK, response);


            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("Predmeti")]
        public async Task<HttpResponseMessage> GetPredmeti(Guid Id)
        {
            try
            {
                var response = Mapper.Map<PredmetViewModel>(await PredmetiService.Get(Id));
                
                if(response==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Traženi element nije pronađen u bazi podataka");
                }

                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("Predmeti")]
        public async Task<HttpResponseMessage> AddPredmet(PredmetViewModel addObj)
        {
            try
            {             
                addObj.PredmetId = Guid.NewGuid();
                var response= await PredmetiService.Add(Mapper.Map<IPredmetiDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("Predmeti")]
        public async Task<HttpResponseMessage> UpdatePredmet(PredmetViewModel updateP)
        {
            try
            {
                PredmetViewModel toBeUpdated = Mapper.Map<PredmetViewModel>(await PredmetiService.Get(updateP.PredmetId));

                if(toBeUpdated==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Nije pronađen traženi predmet.");
                }
                else
                {
                    toBeUpdated.Ime_predmeta = updateP.Ime_predmeta;
                }
                var response = await PredmetiService.Update(Mapper.Map<IPredmetiDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("Predmeti")]
        public async Task<HttpResponseMessage> DeletePredmeti(Guid Id)
        {
            try
            {
                var response = await PredmetiService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
