using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace merchFITbackend.Data.Models
{
    [Table("Narudzba")]
    public class Narudzba
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumNarudzbe {  get; set; }
        public string Status { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set;}

        [ForeignKey(nameof(Dostavljac))]
        public int DostavljacID { get; set; }
        public Dostavljac Dostavljac { get; set; }

        public string Napomena { get; set; }

        [JsonIgnore]
        public ICollection<StavkeNarudzbe> StavkeNarudzbe { get; set; }
    }
}
