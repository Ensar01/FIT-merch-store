namespace merchFITbackend.Data.DataTransferObjects
{
    public class AddRecenzijaDTO
    {
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public string Komentar { get; set; }
        public int Ocjena { get; set; }
    }
}