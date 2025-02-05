using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("KorpaStavka")]
    public class KorpaStavka
    {
        public int ID { get; set; }

        [ForeignKey(nameof(Korpa))]
        public int KorpaID { get; set; }
        public Korpa Korpa { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
    }
}
