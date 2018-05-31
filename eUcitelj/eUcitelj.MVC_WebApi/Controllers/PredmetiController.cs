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
        protected IPredmetiService PredmetiService { get; set; }
        public PredmetiController(IPredmetiService predmetiService)
        {
            this.PredmetiService = predmetiService;
        }

        [HttpGet]
        [Route("imepredmeta")]
        public async Task<HttpResponseMessage> GetAllImePredmetaAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetViewModel>>(await PredmetiService.GetAllImePredmetaAsync());

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
                var response = Mapper.Map<IEnumerable<PredmetViewModel>>(await PredmetiService.GetAllAsync());

                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPredmetiAsync(Guid Id)
        {
            try
            {
                var response = Mapper.Map<PredmetViewModel>(await PredmetiService.GetAsync(Id));

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
                var response = await PredmetiService.AddAsync(Mapper.Map<IPredmetDomainModel>(addObj));
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
                var response = await PredmetiService.AddToBridgeAsync(Mapper.Map<IPredmetKorisnikDomainModel>(addObj));
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
                    PredmetViewModel toBeUpdated = Mapper.Map<PredmetViewModel>(await PredmetiService.GetAsync(updateP.Id));

                    if (toBeUpdated == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije pronađen traženi predmet.");
                    }
                    else
                    {
                        toBeUpdated.Ime_predmeta = updateP.Ime_predmeta;
                    }

                    var response = await PredmetiService.UpdateAsync(Mapper.Map<IPredmetDomainModel>(toBeUpdated));
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
        public async Task<HttpResponseMessage> DeletePredmetiAsync(Guid Id)
        {
            try
            {
                var response = await PredmetiService.DeleteAsync(Id);
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
                FilterModel filterModel = new FilterModel(redoslijed, trazeniPojam, brStr);
                var response =Mapper.Map<IEnumerable<PredmetViewModel>>(await PredmetiService.FindPredmetiAsync(filterModel));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška kod SPF-a.");
            }
        }
    
    }
}
