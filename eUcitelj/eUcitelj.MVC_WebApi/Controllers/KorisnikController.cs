using AutoMapper;
using eUcitelj.Model.Common;
using eUcitelj.MVC_WebApi.ViewModels;
using eUcitelj.Service.Common;
using eUcitelj.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eUcitelj.MVC_WebApi.Controllers
{
    
    [RoutePrefix("api/Korisnik")]
    public class KorisnikController : ApiController
    {
        protected IKorisnikService KorisnikService { get; set; }

        public KorisnikController(IKorisnikService korisnikService)
        {
            this.KorisnikService = korisnikService;
        }

        [HttpGet]
        [Route("getAllK")]
        public async Task<HttpResponseMessage> GetAllKorisnik()
        {
            try
            {  
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await KorisnikService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("getK")]
        public async Task<HttpResponseMessage> GetKorisnik(Guid Id)
        {
            try
            {
                var response = Mapper.Map<KorisnikViewModel>(await KorisnikService.Get(Id));

                if (response == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Traženi element nije pronađen u bazi podataka");
                }


                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("addK")]
        public async Task<HttpResponseMessage> AddKorisnik(KorisnikViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            try
            {
                addObj.KorisnikId = Guid.NewGuid();
                var response = await KorisnikService.Add(Mapper.Map<IKorisnikDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);
             }
             catch (Exception e)
             {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
             }           
        }

        [HttpPut]
        [Route("updateK")]
        public async Task<HttpResponseMessage> UpdateKorisnik(KorisnikViewModel updateK)
        {
            try
            {

                KorisnikViewModel toBeUpdated =Mapper.Map<KorisnikViewModel>(await KorisnikService.Get(updateK.KorisnikId));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije pronađen trazeni korisnik.");
                }
                if (updateK.Ime_korisnika==null||updateK.Korisnicko_ime==null || updateK.KorisnikId==null || updateK.Password==null || updateK.Potvrda==null || updateK.Prezime_korisnika==null || updateK.Role==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska u unosu!");
                }
                else
                {
                    toBeUpdated.Ime_korisnika = updateK.Ime_korisnika;
                    toBeUpdated.Prezime_korisnika = updateK.Prezime_korisnika;
                    toBeUpdated.Korisnicko_ime = updateK.Korisnicko_ime;
                    toBeUpdated.KorisnikId = updateK.KorisnikId;
                    toBeUpdated.Password = updateK.Password;
                    toBeUpdated.Potvrda = updateK.Potvrda;
                    toBeUpdated.Role = updateK.Role;
                }
                var response = await KorisnikService.Update(Mapper.Map<IKorisnikDomainModel>(toBeUpdated));
                return Request.CreateResponse(HttpStatusCode.OK, response);

            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        [Route("deleteK")]
        public async Task<HttpResponseMessage> DeleteKorisnik(Guid Id)
        {
            try
            {
                var response = await KorisnikService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("logintoken")]
        public async Task<HttpResponseMessage> LoginTonken(UserCredentials userCredentials)
        {
            var userToLogin = Mapper.Map<KorisnikViewModel>(await KorisnikService.FindByUserName(userCredentials.Korisnicko_ime));

            if(userToLogin==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Korisnik nije registriran");
            }
            else if(userCredentials.Password!=userToLogin.Password)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Password is incorect");
            }
            else
            {
                var tokenDuration = DateTime.UtcNow.AddMinutes(10);//POSTAVLJANJE VREMENAAA
                var token = new TokenFactory(tokenDuration).GenerateToken();
                var tokenResponse = new TokenResponse()
                {
                    KorisnikId = userToLogin.KorisnikId,
                    Korisnicko_ime = userCredentials.Korisnicko_ime,
                    Token = token,
                    Role=userToLogin.Role,
                                     

                };

                return Request.CreateResponse(HttpStatusCode.OK, tokenResponse);
                


            }
        }

        [HttpGet]
        [Route("getKI")]
        public async Task<HttpResponseMessage> GetAllKorisnicko_ime()
        {
            try {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await KorisnikService.GetAllKorisnicko_ime());
                return Request.CreateResponse(HttpStatusCode.OK, response);
                
            } catch(Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("getAllKorId")]
        public async Task<HttpResponseMessage> GetAllKorisnikId()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await KorisnikService.GetAllKorisnikId());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

    }
}
