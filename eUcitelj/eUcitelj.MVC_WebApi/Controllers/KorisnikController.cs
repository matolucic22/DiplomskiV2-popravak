using AutoMapper;
using eUcitelj.Model.Common;
using eUcitelj.MVC_WebApi.ViewModels;
using eUcitelj.Service;
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
    
    [RoutePrefix("api/korisnik")]
    public class KorisnikController : ApiController
    {
        private IKorisnikService korisnikService;

        public KorisnikController(IKorisnikService korisnikService)
        {
            this.korisnikService = korisnikService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetKorisnikAsync(Guid id)
        {
            try
            {
                var response = Mapper.Map<KorisnikViewModel>(await korisnikService.Get(id));

                if (response == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Traženi element nije pronađen u bazi podataka");
                }


                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [ValidateModel]
        public async Task<HttpResponseMessage> AddKorisnikAsync(KorisnikViewModel addObj)
        {
            
            try
            {
                var response = await korisnikService.AddAsync(Mapper.Map<IKorisnikDomainModel>(addObj));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }       
        }

        [HttpPut]
        [ValidateModel]
        public async Task<HttpResponseMessage> UpdateKorisnikAsync(KorisnikViewModel updateK)
        {
            try
            {
                KorisnikViewModel toBeUpdated =Mapper.Map<KorisnikViewModel>(await korisnikService.Get(updateK.Id));

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije pronađen trazeni korisnik.");
                }
                else
                {
                    var response = await korisnikService.UpdateAsync(Mapper.Map<IKorisnikDomainModel>(updateK));
                    return Request.CreateResponse(HttpStatusCode.OK, response);//***Ovaj način sam sam smislio dok sam radio. Malo drugačije smo radili Lvl. 3 zd na praksi kod vas. Tek kasnije sam primjetio da nismo tako radili, ali nisam ništa htio mijenjat zato što je i ovako funkcioniralo, samo što ima više kooda i teze je razumjeti.***
                }
                
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greska prilikom promjene");
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteKorisnikAsync(Guid id)
        {
            try
            {
                var response = await korisnikService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Greška prilikom brisanja");
            }
        }

        [HttpPost]
        [Route("logintoken")]
        public async Task<HttpResponseMessage> LoginTonkenAsync(UserCredentials userCredentials)
        {
            try
            {
                var userToLogin = Mapper.Map<KorisnikViewModel>(await korisnikService.FindByUserNameAsync(userCredentials.Korisnicko_ime));

                if (userToLogin == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Korisnik nije registriran");
                }
                else if (userCredentials.Lozinka != userToLogin.Lozinka)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Password is incorect");
                }
                else
                {
                    var tokenDuration = DateTime.UtcNow.AddMinutes(10);//POSTAVLJANJE VREMENA
                    var token = new TokenFactory(tokenDuration).GenerateToken();
                    var tokenResponse = new TokenResponse()
                    {
                        KorisnikId = userToLogin.Id,
                        Korisnicko_ime = userCredentials.Korisnicko_ime,
                        Token = token,
                        Uloga = userToLogin.Uloga,
                        
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, tokenResponse);

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, e);
            }

        }

        [HttpGet]
        [Route("getkorisnickoime")]
        public async Task<HttpResponseMessage> GetAllKorisnicko_imeAsync()
        {
            try {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await korisnikService.GetAllKorisnicko_imeAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
                
            } catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }

        }      
        
        [HttpGet]
        [Route("getallucenik")]
        public async Task<HttpResponseMessage> GetAllUcenikAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await korisnikService.GetAllUcenikAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        [Route("getallnepotvrdeno")]
        public async Task<HttpResponseMessage> GetNepotvrdenoAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await korisnikService.GetNepotvrdenoAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        [Route("getallpotvrdeno")]
        public async Task<HttpResponseMessage> GetPotvrdenoAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await korisnikService.GetPotvrdenoAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpGet]
        [Route("getallodbijeno")]
        public async Task<HttpResponseMessage> GetOdbijenoAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await korisnikService.GetOdbijenoAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

    }
}
