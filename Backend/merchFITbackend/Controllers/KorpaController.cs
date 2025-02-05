using merchFITbackend.Data;
using merchFITbackend.Data.DataTransferObjects;
using merchFITbackend.Data.Models;
using merchFITbackend.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace merchFITbackend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class KorpaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KorpaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddKorpaStavka")]
        public async Task<IActionResult> AddKorpaStavka([FromBody] AddKorpaStavkaDTO KS)
        {
            var proizvod = await _context.Proizvod.FindAsync(KS.ProizvodID);

            if(proizvod == null) 
            {
                return NotFound();
            }

            var korpa = await _context.Korpa.Where(x => x.KorisnikID == KS.KorisnikID).FirstOrDefaultAsync();
            if (korpa == null)
            {
                return NotFound("Korpa nije pronađena.");
            }

            var KorpaStavka = new KorpaStavka
            {
                KorpaID = korpa.ID,
                ProizvodID = KS.ProizvodID,
                Kolicina = KS.Kolicina,
            };

            _context.KorpaStavka.Add(KorpaStavka);
            await _context.SaveChangesAsync();

            return Ok(KorpaStavka);
        }

        [HttpPut("UpdateKorpaStavka")]
        public async Task<IActionResult> UpdateKorpaStavka([FromBody] UpdateKorpaStavkaDTO US)
        {
            var KorpaStavka = _context.KorpaStavka.Find(US.ID);
            if(KorpaStavka == null)
            {
                return NotFound("");
            }

            KorpaStavka.Kolicina = US.Kolicina;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetKorpaByID")]
        public async Task<IActionResult> GetKorpaByID(int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            var korpa = await _context.Korpa
            .FirstOrDefaultAsync(x => x.KorisnikID == id);

            if (korpa == null)
            {
                return NotFound(); // Ako korpa ne postoji
            }

            // Mapiranje stavki korpe na view modele
            var KorpaStavke = await _context.KorpaStavka
                .Where(x => x.KorpaID == korpa.ID)
                .Select(s => new GetKorpaStavkeVM
                {
                    ID = s.ID,
                    NazivProizvoda = s.Proizvod.Naziv,
                    SlikaProizvoda = s.Proizvod.SlikaProizvoda,
                    Kolicina = s.Kolicina,
                    Zaliha = s.Proizvod.Zaliha,
                    Cijena = s.Proizvod.Cijena * s.Kolicina,
                }).ToListAsync();

            return Ok(KorpaStavke);
        }

        [HttpDelete("DeleteStavka")]
        public async Task<IActionResult> DeleteStavka(int id)
        {
            var stavka = await _context.KorpaStavka.FindAsync(id);

            if(stavka == null) 
            {
                return NotFound();
            }
            _context.KorpaStavka.Remove(stavka);
            await _context.SaveChangesAsync();

            return Ok(stavka);
        }

        [HttpGet("GetAllDostavljaci")]
        public async Task<IActionResult> GetDostavljaci()
        {
            var dostavljaci = await _context.Dostavljac.ToListAsync();

            if (dostavljaci == null)
            {
                return NotFound();
            }


            return Ok(dostavljaci);
        }
    
    }
}
