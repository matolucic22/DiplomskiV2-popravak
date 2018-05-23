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
using System.Web;
using System.Web.Http;

namespace eUcitelj.MVC_WebApi.Controllers
{
    [RoutePrefix("api/predmetkorisnik")]
    public class PredmetKorisnikController:ApiController
    {
        protected IPredmetKorisnikService PredmetKorisnikService { get; set; }
        public PredmetKorisnikController(IPredmetKorisnikService predmetKorisnikService)
        {
            this.PredmetKorisnikService = predmetKorisnikService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllPKAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetKorisnikViewModel>>(await PredmetKorisnikService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPKAsync(Guid Id)
        {
            try
            {
                var response = Mapper.Map<KvizViewModel>(await PredmetKorisnikService.GetAsync(Id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddPKAsync(PredmetKorisnikViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                var response = await PredmetKorisnikService.AddAsync(Mapper.Map<IPredmetKorisnikDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}