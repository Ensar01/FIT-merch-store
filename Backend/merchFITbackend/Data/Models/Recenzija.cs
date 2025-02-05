using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("Recenzija")]
    public class Recenzija
    {
        public int ID { get; set; }
        public string Komentar {  get; set; }
        public int Ocjena { get; set; }
        public DateTime DatumRecenzije { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }
    }
}
