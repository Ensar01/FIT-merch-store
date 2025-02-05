namespace merchFITbackend.Data.DataTransferObjects
{
    public class UpdateKorisnikDTO
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public new string Email { get; set; }

        public new string PhoneNumber { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string PostanskiBroj { get; set; }
    }
}
