using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("Dostavljac")]
    public class Dostavljac
    {
        public int ID { get; set; }
        public string Naziv {  get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }
        public int BrojTelefona { get; set; }
        public string Adresa { get; set; }
    }
}
