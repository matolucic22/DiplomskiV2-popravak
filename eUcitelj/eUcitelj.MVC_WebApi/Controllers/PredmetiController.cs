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
    [RoutePrefix("api/Predmeti")]
    public class PredmetiController : ApiController
    {
        protected IPredmetiService PredmetiService { get; set; }
        public PredmetiController(IPredmetiService predmetiService)
        {
            this.PredmetiService = predmetiService;
        }
        
        [HttpGet]
        [Route("getAllP")]
        public async Task<HttpResponseMessage> GetAllPredmeti()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetiViewModel>>(await PredmetiService.GetAll());
                
                return Request.CreateResponse(HttpStatusCode.OK, response);


            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("getP")]
        public async Task<HttpResponseMessage> GetPredmeti(Guid Id)
        {
            try
            {
                var response = Mapper.Map<PredmetiViewModel>(await PredmetiService.Get(Id));
                
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
        [Route("addP")]
        public async Task<HttpResponseMessage> AddPredmet(PredmetiViewModel addObj)
        {
            try
            {
                
                addObj.PredmetiId = Guid.NewGuid();
                var response= await PredmetiService.Add(Mapper.Map<IPredmetiDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        [Route("updateP")]
        public async Task<HttpResponseMessage> UpdatePredmet(PredmetiViewModel updateP)
        {
            try
            {
                PredmetiViewModel toBeUpdated = Mapper.Map<PredmetiViewModel>(await PredmetiService.Get(updateP.PredmetiId));

                if(toBeUpdated==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Nije pronađen traženi predmet.");
                }
                if(updateP.Ime_predmeta==null||updateP.PredmetiId==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška u unosu!");
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
        [Route("deleteP")]
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
