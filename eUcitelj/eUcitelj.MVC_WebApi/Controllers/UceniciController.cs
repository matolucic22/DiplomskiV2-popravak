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
        private IUceniciService uceniciService;
        public UceniciController(IUceniciService uceniciService)
        {
            this.uceniciService = uceniciService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllUceniciAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<UcenikViewModel>>(await uceniciService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUceniciAsync(Guid id)
        {
            try
            {
                var response = Mapper.Map<UcenikViewModel>(await uceniciService.GetAsync(id));

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
                var response = await uceniciService.AddAsync(Mapper.Map<IUceniciDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteUceniciAsync(Guid id)
        {
            try
            {
                var response = await uceniciService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }
    }
}