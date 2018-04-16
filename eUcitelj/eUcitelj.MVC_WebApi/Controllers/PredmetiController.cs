using AutoMapper;
using eUcitelj.Model.Common;
using eUcitelj.MVC_WebApi.ViewModels;
using eUcitelj.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eUcitelj.MVC_WebApi.Controllers
{
    [RoutePrefix("api/predmeti")]
    public class PredmetiController : ApiController
    {
        protected IPredmetiService PredmetiService { get; set; }
        public PredmetiController(IPredmetiService predmetiService)
        {
            this.PredmetiService = predmetiService;
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllPredmetiAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetViewModel>>(await PredmetiService.GetAllAsync());
                
                return Request.CreateResponse(HttpStatusCode.OK, response);


            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPredmetiAsync(Guid Id)
        {
            try
            {
                var response = Mapper.Map<PredmetViewModel>(await PredmetiService.GetAsync(Id));
                
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
        public async Task<HttpResponseMessage> AddPredmetAsync(PredmetViewModel addObj)
        {
            try
            {             
                addObj.PredmetId = Guid.NewGuid();
                var response= await PredmetiService.AddAsync(Mapper.Map<IPredmetiDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePredmetAsync(PredmetViewModel updateP)
        {
            try
            {
                PredmetViewModel toBeUpdated = Mapper.Map<PredmetViewModel>(await PredmetiService.GetAsync(updateP.PredmetId));

                if(toBeUpdated==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Nije pronađen traženi predmet.");
                }
                else
                {
                    toBeUpdated.Ime_predmeta = updateP.Ime_predmeta;
                }

                var response = await PredmetiService.UpdateAsync(Mapper.Map<IPredmetiDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePredmetiAsync(Guid Id)
        {
            try
            {
                var response = await PredmetiService.DeleteAsync(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("spf")]
        public async Task<HttpResponseMessage> SortingPagingFilteringAsync(string redoslijed, string trazeniPojam, int? brStr)
        {
            try
            {
                var response =Mapper.Map<IEnumerable<PredmetViewModel>>(await PredmetiService.SortingPagingFilteringAsync(redoslijed, trazeniPojam, brStr));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
