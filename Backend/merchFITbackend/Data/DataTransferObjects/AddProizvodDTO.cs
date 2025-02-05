using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.DataTransferObjects
{
    public class AddProizvodDTO
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }
        public int Zaliha { get; set; }
        public string SlikaProizvoda { get; set; }
        public int UzrastID { get; set; }
        public int PodkategorijaID { get; set; }
    }
}
