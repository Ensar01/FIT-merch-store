using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.ViewModels
{
    public class GetKorpaStavkeVM
    {
        public int ID { get; set; }
        public string NazivProizvoda { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }
        public int Zaliha { get; set; }
        public string SlikaProizvoda { get; set; }
        public int Kolicina { get; set; }
    }
}
