using AutoMapper;
using eUcitelj.Common;
using eUcitelj.Model.Common;
using eUcitelj.MVC_WebApi.ViewModels;
using eUcitelj.Service;
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
        private IPredmetiService predmetiService;
        public PredmetiController(IPredmetiService predmetiService)
        {
            this.predmetiService = predmetiService;
        }

        [HttpGet]
        [Route("imepredmeta")]
        public async Task<HttpResponseMessage> GetAllImePredmetaAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetViewModel>>(await predmetiService.GetAllImePredmetaAsync());

                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetViewModel>>(await predmetiService.GetAllAsync());

                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPredmetiAsync(Guid id)
        {
            try
            {
                var response = Mapper.Map<PredmetViewModel>(await predmetiService.GetAsync(id));

                if (response == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Traženi element nije pronađen u bazi podataka");
                }

                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<HttpResponseMessage> AddPredmetAsync(PredmetViewModel addObj)
        {
            try
            {
                var response = await predmetiService.AddAsync(Mapper.Map<IPredmetDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPost]
        [Route("addtobridge")]
        public async Task<HttpResponseMessage> AddToBridgeAsync(PredmetKorisnikViewModel addObj)
        {
            try
            {
                var response = await predmetiService.AddToBridgeAsync(Mapper.Map<IPredmetKorisnikDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska prilikom dodavanja");
            }
        }

        [HttpPut]
        [ValidateModel]
        public async Task<HttpResponseMessage> UpdatePredmetAsync(PredmetViewModel updateP)
        {
            try
            {
                if (updateP != null)
                { 
                    PredmetViewModel toBeUpdated = Mapper.Map<PredmetViewModel>(await predmetiService.GetAsync(updateP.Id));

                    if (toBeUpdated == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije pronađen traženi predmet.");
                    }
                    else
                    {
                        toBeUpdated.Ime_predmeta = updateP.Ime_predmeta;
                    }

                    var response = await predmetiService.UpdateAsync(Mapper.Map<IPredmetDomainModel>(toBeUpdated));
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Predmet nije pronađen");
                }

            }catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska prilikom promjene");
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePredmetiAsync(Guid id)
        {
            try
            {
                var response = await predmetiService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }

        [HttpGet]
        [Route("spf")]
        public async Task<HttpResponseMessage> FindPredmetiAsync(string redoslijed, string trazeniPojam, int? brStr)
        {
            try
            {
                int brEl = 4;
                FilterModel filterModel = new FilterModel(redoslijed, trazeniPojam, brStr, brEl);
                var response =Mapper.Map<IEnumerable<PredmetViewModel>>(await predmetiService.FindPredmetiAsync(filterModel));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška kod SPF-a.");
            }
        }
    
    }
}
