using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Kviz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid KvizId { get; set; }

        public string Odg1 { get; set; }
        
        public string Odg2 { get; set; }
        
        public string Odg3 { get; set; }

        public string Pitanje { get; set; }

        public Guid PredmetId { get; set; }
        
        public string Tocan_odgovor { get; set; }

    }
}
