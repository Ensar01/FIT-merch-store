using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace merchFITbackend.Data.Models
{
    [Table("Podkategorija")]
    public class Podkategorija
    {
        public int ID { get; set; }
        public string Naziv {  get; set; }

        [ForeignKey(nameof(Kategorija))]
        public int KategorijaID { get; set; }
        [JsonIgnore]
        public Kategorija Kategorija { get; set; }
    }
}
