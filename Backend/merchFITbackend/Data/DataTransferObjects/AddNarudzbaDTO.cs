using merchFITbackend.Data.Models;

namespace merchFITbackend.Data.DataTransferObjects
{
    public class AddNarudzbaDTO
    {
        public int KorisnikID { get; set; }
        public string? Status { get; set; }
        public List<AddStavkeNarudzbeDTO> StavkeNarudzbe { get; set; }
        public string Napomena { get; set; }
        public int DostavljacID { get; set; }
    }
}