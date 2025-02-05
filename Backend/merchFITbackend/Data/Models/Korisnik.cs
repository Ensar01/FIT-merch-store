using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace merchFITbackend.Data.Models
{
    [Table("Korisnik")]
    public class Korisnik : IdentityUser<int>
    {
        [Key]
        public int Id{ get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public new string Email { get; set; }

        public new string PhoneNumber { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
       
        public bool IsAdmin { get; set; }
        public string PostanskiBroj { get; set; }
        [JsonIgnore]
        public DateTime DatumRegistracije { get; set; }

    }

    public class KorisnikLog
    {
        public string Email { get; set; }
        public string Lozinka { get; set; }
    }
  
}
