using eUcitelj.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUcitelj.DAL.Models
{
    public class Kviz:IKviz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid KvizId { get; set; }

        public int Bodovi { get; set; }

        public string Odg1 { get; set; }

        public string Odg2 { get; set; }
        
        public string Odg3 { get; set; }

        public string Pitanje { get; set; }
                
        public Guid PredmetiId { get; set; }
        
        public string Tocan_odgovor { get; set; }

    }
}
