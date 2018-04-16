﻿using AutoMapper;
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
        protected IKorisnikService KorisnikService { get; set; }

        public KorisnikController(IKorisnikService korisnikService)
        {
            this.KorisnikService = korisnikService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllKorisnikAsync()
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
        public async Task<HttpResponseMessage> GetKorisnikAsync(Guid Id)
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
        public async Task<HttpResponseMessage> AddKorisnikAsync(KorisnikViewModel addObj)//httpresponsemessage - convert to HTTP convert message
        {
            
                try
                {
                    addObj.KorisnikId = Guid.NewGuid();
                    var response = await KorisnikService.AddAsync(Mapper.Map<IKorisnikDomainModel>(addObj));
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }       
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateKorisnikAsync(KorisnikViewModel updateK)
        {
            /*KorisnikViewModel toBeUpdated = Mapper.Map<KorisnikViewModel>(await KorisnikService.Get(updateK.KorisnikId)); -nema potrebe mapirati response u view, nego u domain model, i onda dobiveni view model (updateK)treba mapirati u domain koji se onda šalje na update
            
            toBeUpdated.Ime_korisnika = updateK.Ime_korisnika;
            toBeUpdated.Prezime_korisnika = updateK.Prezime_korisnika;
            toBeUpdated.Korisnicko_ime = updateK.Korisnicko_ime;
            toBeUpdated.KorisnikId = updateK.KorisnikId;
            toBeUpdated.Password = updateK.Password;
            toBeUpdated.Potvrda = updateK.Potvrda;
            toBeUpdated.Role = updateK.Role;
            var response = await KorisnikService.Update(Mapper.Map<IKorisnikDomainModel>(toBeUpdated));*/ //Nisam tocno shvatio sto ste htjeli sa ovim reci pa sam Vam objasnio korake po kojima sam radio update. Smatram da niste shvatili kako sam napavio. KORACI - 1), 2) i 3). 

            try
            {
                KorisnikViewModel toBeUpdated =Mapper.Map<KorisnikViewModel>(await KorisnikService.Get(updateK.KorisnikId));//1) Iz baze dohvaćam korisnika nad kojim želim napraviti "update", preko ID-a (updateK.KorisnikId - properti koji je "došao iz view-a" kao ulazni podatak u metodu). Potrebno je mapirati toBeUpdated u ViewModel zato što je objekt koji dolazi iz baze (iz domain modela).

                if (toBeUpdated == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nije pronađen trazeni korisnik.");
                }
                else// 2)updateK
                {
                    var response = await KorisnikService.UpdateAsync(Mapper.Map<IKorisnikDomainModel>(updateK));// 3)Mapiram updateK i saljem "Update" metodom u bazu
                    return Request.CreateResponse(HttpStatusCode.OK, response);//***Ovaj način sam sam smislio dok sam radio. Malo drugačije smo radili Lvl. 3 zd na praksi kod vas. Tek kasnije sam primjetio da nismo tako radili, ali nisam ništa htio mijenjat zato što je i ovako funkcioniralo, samo što ima više kooda i teze je razumjeti.***
                }
                
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteKorisnikAsync(Guid Id)
        {
            try
            {
                var response = await KorisnikService.DeleteAsync(Id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("logintoken")]
        public async Task<HttpResponseMessage> LoginTonkenAsync(UserCredentials userCredentials)
        {
            try
            {
                var userToLogin = Mapper.Map<KorisnikViewModel>(await KorisnikService.FindByUserNameAsync(userCredentials.Korisnicko_ime));

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
                        KorisnikId = userToLogin.KorisnikId,
                        Korisnicko_ime = userCredentials.Korisnicko_ime,
                        Token = token,
                        Uloga = userToLogin.Uloga,
                        
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, tokenResponse);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet]
        [Route("getKorisnickoIme")]
        public async Task<HttpResponseMessage> GetAllKorisnicko_imeAsync()
        {
            try {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await KorisnikService.GetAllKorisnicko_imeAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
                
            } catch(Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("getAllKorisnikId")]
        public async Task<HttpResponseMessage> GetAllKorisnikIdAsync()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<KorisnikViewModel>>(await KorisnikService.GetAllKorisnikIdAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

    }
}
