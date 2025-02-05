using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace merchFITbackend.Data.Models
{
    public class ProizvodVelicina
    {
        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

     
        [ForeignKey(nameof(Velicina))]
        public int VelicinaID { get; set; }
        public Velicina Velicina { get; set; }
    }
}
