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
        private IPredmetKorisnikService predmetKorisnikService;
        public PredmetKorisnikController(IPredmetKorisnikService predmetKorisnikService)
        {
            this.predmetKorisnikService = predmetKorisnikService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllPKAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<PredmetKorisnikViewModel>>(await predmetKorisnikService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPKAsync(Guid id)
        {
            try
            {
                var response = Mapper.Map<KvizViewModel>(await predmetKorisnikService.GetAsync(id));
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
                var response = await predmetKorisnikService.AddAsync(Mapper.Map<IPredmetKorisnikDomainModel>((addObj)));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}