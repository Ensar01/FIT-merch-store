using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.Models
{
    [Table("Kategorija")]
    public class Kategorija
    {
        [Key]
        public int ID { get; set; }
        public string Naziv {  get; set; }
    }
}
