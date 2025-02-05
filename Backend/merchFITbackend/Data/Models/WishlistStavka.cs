using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("WishlistStavka")]
    public class WishlistStavka
    {
        public int ID { get; set; }

        [ForeignKey(nameof(Wishlist))]
        public int WishlistID { get; set; }
        public Wishlist Wishlist { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }
    }
}
