using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace merchFITbackend.Data.Models
{
    [Table("Proizvod")]
    public class Proizvod
    {
        [Key]
        public int ID { get; set; }
        public string Naziv {  get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }
        public int Zaliha { get; set; }
        public string SlikaProizvoda { get; set; }
        [ForeignKey(nameof(Uzrast))]
        public int UzrastID { get; set; }
        [JsonIgnore]
        public Uzrast Uzrast { get; set; }

        [ForeignKey(nameof(Podkategorija))]
        public int PodkategorijaID { get; set; }
        [JsonIgnore]
        public Podkategorija Podkategorija { get; set; }
        public ICollection<ProizvodVelicina> Velicine { get; set; }
    }
}
