using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUcitelj.DAL.Models
{
    public class Korisnik
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        public string Ime_korisnika { get; set; }
        
        public string Prezime_korisnika { get; set; }
        
        public string Korisnicko_ime { get; set; }
        
        public string Lozinka { get; set; }
        
        public string Potvrda { get; set; }
        
        public string Uloga { get; set; }

        public virtual ICollection<PredmetKorisnik> PredmetKorisnici { get; set; }//1 korisnik moze biti upisan na vise predmeta
        public virtual ICollection<Ucenik> Ucenici { get; set; }//1 korisnik logiran kao roditelj moze imati vise ucenika
    }
}
