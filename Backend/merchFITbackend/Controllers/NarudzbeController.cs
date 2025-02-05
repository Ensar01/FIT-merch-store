using merchFITbackend.Data;
using merchFITbackend.Data.DataTransferObjects;
using merchFITbackend.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace merchFITbackend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NarudzbeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NarudzbeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllNarudzbe")]
        public async Task<IActionResult> GetAllNarudzbe()
        {
            var narudzbe = await _context.Narudzba
                .Include(n=>n.StavkeNarudzbe)
                .ThenInclude(s=> s.Proizvod)
                .ToListAsync();

            if(narudzbe == null)
            {
                return NotFound();
            }

            return Ok(narudzbe);
        }

        [HttpPost("CreateNarudzba")]
        public async Task<IActionResult> CreateNarudzba([FromBody] AddNarudzbaDTO n)
        {
            if(n == null || !n.StavkeNarudzbe.Any())
            {
                return NotFound("Pogresno unijeti podaci");
            }

            var narudzba = new Narudzba
            {
                DatumNarudzbe = DateTime.Now,
                Status = "U pripremi",
                KorisnikID = n.KorisnikID,
                StavkeNarudzbe = new List<StavkeNarudzbe>(),
                DostavljacID = n.DostavljacID,
                Napomena = n.Napomena,
            };

            foreach(var stavka in n.StavkeNarudzbe)
            {
                var proizvod = await _context.Proizvod.FirstOrDefaultAsync(p => p.ID == stavka.ProizvodID);

                if(proizvod == null)
                {
                    return BadRequest("Proizvod nije pronadjen");
                }

                var cijenaStavke = proizvod.Cijena * stavka.Kolicina;

                narudzba.StavkeNarudzbe.Add(new StavkeNarudzbe
                {
                    NarudzbaID = narudzba.ID,
                    ProizvodID = stavka.ProizvodID,
                    Kolicina = stavka.Kolicina,
                    Cijena = cijenaStavke,
                });
            }
            _context.Narudzba.Add(narudzba);
            await _context.SaveChangesAsync();

            return Created(string.Empty, narudzba);
        }

        [HttpPut("UpdateNarudzba")]
        public async Task<IActionResult> UpdateNarudzba(int id, [FromBody] AddNarudzbaDTO n)
        {
            if (n == null || !n.StavkeNarudzbe.Any())
            {
                return NotFound("Pogresno unijeti podaci");
            }

            var narudzba = await _context.Narudzba.Include(n => n.StavkeNarudzbe).FirstOrDefaultAsync(x => x.ID == id);

            if (narudzba == null)
            {
                return NotFound("Narudzba nije pronadjena");
            }

            narudzba.KorisnikID = n.KorisnikID;
            narudzba.Status = n.Status;         


            var existingStavkeIds = narudzba.StavkeNarudzbe.Select(s => s.ProizvodID).ToList();

            foreach (var stavka in n.StavkeNarudzbe)
            {
                var proizvod = await _context.Proizvod.FirstOrDefaultAsync(p => p.ID == stavka.ProizvodID);

                if (proizvod == null)
                {
                    return BadRequest($"Proizvod {stavka.ProizvodID} nije pronadjen");
                }

                var existingStavka = narudzba.StavkeNarudzbe.FirstOrDefault(s => s.ProizvodID == stavka.ProizvodID);

                if (existingStavka != null)
                {
                    existingStavka.Kolicina = stavka.Kolicina;
                    existingStavka.Cijena = proizvod.Cijena * stavka.Kolicina;
                }
                else
                {
                    narudzba.StavkeNarudzbe.Add(new StavkeNarudzbe
                    {
                        NarudzbaID = narudzba.ID,
                        ProizvodID = stavka.ProizvodID,
                        Kolicina = stavka.Kolicina,
                        Cijena = proizvod.Cijena * stavka.Kolicina
                    });
                }
            }

            

            await _context.SaveChangesAsync();

            return Ok(narudzba);
        }

        [HttpDelete("ObrisiNarudzba")]
        public async Task<IActionResult> DeleteNarudzba(int Id)
        {
            var narudzba = await _context.Narudzba.FindAsync(Id);

            if (narudzba == null)
            {
                return NotFound();
            }

            _context.Narudzba.Remove(narudzba);
            await _context.SaveChangesAsync();

            return Ok(narudzba);
        }

        
    }
}
