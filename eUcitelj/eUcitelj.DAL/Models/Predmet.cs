using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    [MetadataType(typeof(Predmet))]
    public class Predmet//: IValidatableObject
    {
  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        public string Ime_predmeta { get; set; }

        public virtual ICollection<Ocjena> Ocjene { get; set; }//1 predmet moze imati vise ocijena

        public virtual ICollection<Kviz> Kviz { get; set; }//1 predmet moze imati vise kvizova

        public virtual ICollection<PredmetKorisnik> PredmetKorisnici { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var contextUser = (Predmet)validationContext.ObjectInstance;

            using (var context = new eUciteljContext())
            {
                var existingP = context.Predmeti.FirstOrDefault(u => u.Ime_predmeta == this.Ime_predmeta);
                if (existingP != null)
                {
                    yield return new ValidationResult("Unos postoji u bazi.");
                }
            }
        }
    }
}
