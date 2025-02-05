using merchFITbackend.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace merchFITbackend.Data.DataTransferObjects
{
    public class AddStavkeNarudzbeDTO
    {
        public int Kolicina { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public int ProizvodID { get; set; }
    }
}
