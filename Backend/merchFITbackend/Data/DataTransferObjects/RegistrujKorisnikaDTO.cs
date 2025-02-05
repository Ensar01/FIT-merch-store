using System.ComponentModel.DataAnnotations;

namespace merchFITbackend.Data.DataTransferObjects
{
    public class RegistrujKorisnikaDTO
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required] 
        public string Grad {  get; set; }
        [Required]
        public string Drzava { get; set; }
        [Required]
        public string PostanskiBroj { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}