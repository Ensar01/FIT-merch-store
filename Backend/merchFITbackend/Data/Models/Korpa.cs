using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("Korpa")]
    public class Korpa
    {
        public int ID { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set;}

    }
}
