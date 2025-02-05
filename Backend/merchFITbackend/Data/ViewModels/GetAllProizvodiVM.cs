using merchFITbackend.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.ViewModels
{
    public class GetAllProizvodiVM
    {
        public int ID { get; set; }
        public string Naziv {  get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }
        public int Zaliha { get; set; }
        public string Uzrast {  get; set; }
        public List<GetAllVelicineVM> SveVelicine { get; set; }
        public List<Recenzija> SveRecenzije {  get; set; }
        public string SlikaProizvoda { get; set; }
    }
}
