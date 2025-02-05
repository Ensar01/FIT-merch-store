namespace merchFITbackend.Data.Models
{
    public class Velicina
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public ICollection<ProizvodVelicina> Proizvod {  get; set; }

    }
}
