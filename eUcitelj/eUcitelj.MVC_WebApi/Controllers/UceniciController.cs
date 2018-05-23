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
    [RoutePrefix("api/ucenici")]
    public class UceniciController:ApiController
    {
        protected IUceniciService UceniciService { get; set; }
        public UceniciController(IUceniciService uceniciService)
        {
            this.UceniciService = uceniciService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllUceniciAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<UcenikViewModel>>(await UceniciService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUceniciAsync(Guid Id)
        {
            try
            {
                var response = Mapper.Map<UcenikViewModel>(await UceniciService.GetAsync(Id));

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
        public async Task<HttpResponseMessage> AddUceniciAsync(UcenikViewModel addObj)
        {
            try
            {
                var response = await UceniciService.AddAsync(Mapper.Map<IUceniciDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteUceniciAsync(Guid Id)
        {
            try
            {
                var response = await UceniciService.DeleteAsync(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }
    }
}