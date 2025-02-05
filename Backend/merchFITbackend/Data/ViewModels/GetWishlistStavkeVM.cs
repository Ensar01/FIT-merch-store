using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.ViewModels
{
    public class GetWishlistStavkeVM
    {
        public int ID { get; set; }
        public string NazivProizvoda { get; set; }
        public string SlikaProizvoda { get; set; }
    }
}
