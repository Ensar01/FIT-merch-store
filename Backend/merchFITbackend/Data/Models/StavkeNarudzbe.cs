using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("StavkeNarudzbe")]
    public class StavkeNarudzbe
    {
        [Key]
        public int ID { get; set; }
        public int Kolicina { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }

        [ForeignKey(nameof(Narudzba))]
        public int NarudzbaID { get; set; }
        public Narudzba Narudzba {  get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }
    }
}