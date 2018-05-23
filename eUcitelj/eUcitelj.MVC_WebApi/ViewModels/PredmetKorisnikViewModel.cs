using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUcitelj.MVC_WebApi.ViewModels
{
    public class PredmetKorisnikViewModel
    {
        public Guid PredmetKorisnikId { get; set; }
        public Guid PredmetId { get; set; }
        public Guid KorisnikId { get; set; }
    }
}