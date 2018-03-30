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
    [RoutePrefix("api/Ucenici")]
    public class UceniciController:ApiController
    {
        protected IUceniciService UceniciService { get; set; }
        public UceniciController(IUceniciService uceniciService)
        {
            this.UceniciService = uceniciService;
        }

        [HttpGet]
        [Route("getAllU")]
        public async Task<HttpResponseMessage> GetAllUcenici()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<UceniciViewModel>>(await UceniciService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("getU")]
        public async Task<HttpResponseMessage> GetUcenici(Guid Id)
        {
            try
            {
                var response = Mapper.Map<UceniciViewModel>(await UceniciService.Get(Id));

                if (response == null)
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
        [Route("addU")]
        public async Task<HttpResponseMessage> AddUcenici(UceniciViewModel addObj)
        {
            try
            {

                addObj.UceniciId = Guid.NewGuid();
                var response = await UceniciService.Add(Mapper.Map<IUceniciDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("deleteU")]
        public async Task<HttpResponseMessage> DeleteUcenici(Guid Id)
        {
            try
            {
                var response = await UceniciService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}