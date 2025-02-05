using merchFITbackend.Data;
using merchFITbackend.Data.DataTransferObjects;
using merchFITbackend.Data.Models;
using merchFITbackend.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace merchFITbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProizvodController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllProizvodi")]
        public async Task<IActionResult> GetAllProizvodi(int kategorijaId = 0, int uzrastId = 0)
        {
            if (kategorijaId < 0 || uzrastId < 0)
            {
                return BadRequest("Nevalidni parametri.");
            }


            if (kategorijaId == 0 && uzrastId > 0)
            {
                var proizvodi = await _context.Proizvod
                    .Where(x => x.UzrastID == uzrastId)
                    .Select(x => new GetAllProizvodiVM
                    {
                        ID = x.ID,
                        Naziv = x.Naziv,
                        Opis = x.Opis,
                        Cijena = x.Cijena,
                        Zaliha = x.Zaliha,
                        Uzrast = x.Uzrast.Naziv,
                        SlikaProizvoda = x.SlikaProizvoda,
                        SveVelicine = _context.ProizvodVelicina.Where(v => v.ProizvodID == x.ID)
                        .Select(s => new GetAllVelicineVM
                        {
                            VelicinaID = s.VelicinaID,
                            Naziv = s.Velicina.Naziv
                        }).ToList(),
                        SveRecenzije = _context.Recenzija.Where(r => r.ProizvodID == x.ID).ToList()
                    }).ToListAsync();

                return Ok(proizvodi);
            }
            if (kategorijaId > 0 && uzrastId > 0)
            {
                var proizvodi = await _context.Proizvod
                    .Where(x => x.UzrastID == uzrastId && x.Podkategorija.KategorijaID == kategorijaId)
                    .Select(x => new GetAllProizvodiVM
                    {
                        ID = x.ID,
                        Naziv = x.Naziv,
                        Opis = x.Opis,
                        Cijena = x.Cijena,
                        Zaliha = x.Zaliha,
                        Uzrast = x.Uzrast.Naziv,
                        SlikaProizvoda = x.SlikaProizvoda,
                        SveVelicine = _context.ProizvodVelicina.Where(v => v.ProizvodID == x.ID)
                        .Select(s => new GetAllVelicineVM
                        {
                            VelicinaID = s.VelicinaID,
                            Naziv = s.Velicina.Naziv
                        }).ToList(),
                        SveRecenzije = _context.Recenzija.Where(r => r.ProizvodID == x.ID).ToList()
                    }).ToListAsync();



                return Ok(proizvodi);
            }



            return BadRequest("Unesi validan uzrastId.");
        }

            [HttpGet("Podkategorije")]
        public async Task<IActionResult> GetPodkategorije(int id)
        {
            var podkategorije = await _context.Podkategorija
                .Where(x => x.KategorijaID == id)
                .ToListAsync();

            if (podkategorije == null || !podkategorije.Any())
            {
                return NotFound();
            }

            return Ok(podkategorije);
        }
        [HttpGet("GetProizvodBySubcategory")]
        public async Task<IActionResult> GetProizvode(int id)
        {
            var proizvodi = await _context.Proizvod
                .Where(x => x.PodkategorijaID == id)
                .Select(x => new GetAllProizvodiVM
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Cijena = x.Cijena,
                    Zaliha = x.Zaliha,
                    Uzrast = x.Uzrast.Naziv,
                    SveVelicine = _context.ProizvodVelicina.Where(v => v.ProizvodID == x.ID)
                        .Select(s => new GetAllVelicineVM
                        {
                            VelicinaID = s.VelicinaID,
                            Naziv = s.Velicina.Naziv
                        }).ToList()
                }).ToListAsync();

            if (proizvodi == null || !proizvodi.Any())
            {
                return NotFound();
            }

            return Ok(proizvodi);
        }

        [HttpGet("ProizvodiPretraga")]
        public async Task<IActionResult> GetProizvodeIme(string naziv)
        {
            var proizvodi = await _context.Proizvod
                .Where(x => x.Naziv.ToLower().Contains(naziv.ToLower()))
                .Select(x => new GetAllProizvodiVM
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Cijena = x.Cijena,
                    Zaliha = x.Zaliha,
                    Uzrast = x.Uzrast.Naziv,
                    SveVelicine = _context.ProizvodVelicina.Where(v => v.ProizvodID == x.ID)
                        .Select(s => new GetAllVelicineVM
                        {
                            VelicinaID = s.VelicinaID,
                            Naziv = s.Velicina.Naziv
                        }).ToList()
                }).ToListAsync();

            if (proizvodi == null || !proizvodi.Any())
            {
                return NotFound();
            }
            return Ok(proizvodi);
        }

        [HttpGet("SviProizvodi")]
        public async Task<IActionResult> GetAllProizvodi()
        {
            var proizvodi = await _context.Proizvod
                .Select(x => new GetAllProizvodiVM
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Cijena = x.Cijena,
                    Zaliha = x.Zaliha,
                    Uzrast = x.Uzrast.Naziv,
                    SveVelicine = _context.ProizvodVelicina.Where(v => v.ProizvodID == x.ID)
                        .Select(s => new GetAllVelicineVM
                        {
                            VelicinaID = s.VelicinaID,
                            Naziv = s.Velicina.Naziv
                        }).ToList(),
                    SveRecenzije = _context.Recenzija.Where(r => r.ProizvodID == x.ID).ToList()
                }).ToListAsync();

            if (proizvodi == null || !proizvodi.Any())
            {
                return NotFound();
            }

            return Ok(proizvodi);

        }


        [HttpDelete("ObrisiProizvod")]
        public async Task<IActionResult> DeleteProizvod(int Id)
        {
            var proizvod = await _context.Proizvod.FindAsync(Id);

            if (proizvod == null)
            {
                return NotFound();
            }

            _context.Proizvod.Remove(proizvod);
            await _context.SaveChangesAsync();

            return Ok(proizvod);
        }

        [HttpPut("UpdateProizvod")]
        public async Task<IActionResult> UpdateProizvod([FromBody] UpdateProizvodDTO p)
        {
            if (p == null || p.ID <= 0)
            {
                return BadRequest("Netacni podaci o proizvodu");
            }

            var proizvod = await _context.Proizvod.FindAsync(p.ID);

            if (proizvod == null)
            {
                return NotFound("Proizvod nije pronadjen");
            }

            proizvod.Naziv = p.Naziv;
            proizvod.Opis = p.Opis;
            proizvod.Cijena = p.Cijena;
            proizvod.Zaliha = p.Zaliha;
            proizvod.SlikaProizvoda = p.SlikaProizvoda;
            proizvod.UzrastID = p.UzrastID;
            proizvod.PodkategorijaID = p.PodkategorijaID;

            await _context.SaveChangesAsync();
            return Ok("Proizvod azuriran uspjesno");
        }

        [HttpPost("AddProizvod")]
        public async Task<IActionResult> AddProizvod([FromBody] AddProizvodDTO p)
        {
            if (p == null)
            {
                return BadRequest("Nedostaju podaci u tijelu zahtjeva");
            }

            var proizvod = new Proizvod
            {
                Naziv = p.Naziv,
                Opis = p.Opis,
                Cijena = p.Cijena,
                Zaliha = p.Zaliha,
                SlikaProizvoda = p.SlikaProizvoda,
                UzrastID = p.UzrastID,
                PodkategorijaID = p.PodkategorijaID
            };

            _context.Proizvod.Add(proizvod);
            await _context.SaveChangesAsync();

            return Created(string.Empty, proizvod);
        }

        [HttpPost("AddRecenzija")]
        public async Task<IActionResult> AddRecenzija([FromBody] AddRecenzijaDTO r)
        {
            if(r == null)
            {
                return BadRequest("Nedostaju podaci u tijelu zahtjeva");
            }

            var korisnik = await _context.Korisnik.FindAsync(r.KorisnikID);
            var proizvod = await _context.Proizvod.FindAsync(r.ProizvodID);

            if(korisnik == null || proizvod == null)
            {
                return NotFound("Korisnik ili proizvod nije pronadjen");
            }

            var Recenzija = new Recenzija
            {
                Komentar = r.Komentar,
                Ocjena = r.Ocjena,
                DatumRecenzije = DateTime.Now,
                KorisnikID = r.KorisnikID,
                ProizvodID = r.ProizvodID
            };
            _context.Recenzija.Add(Recenzija);
            _context.SaveChangesAsync();

            return Created(string.Empty,Recenzija);

        }
        [HttpGet("GetRecenzije")]
        public async Task<IActionResult>GetRecenzije(int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest("Netacni podaci o proizvodu");
            }

            var proizvod = await _context.Proizvod.FindAsync(id);
            if(proizvod == null)
            {
                return NotFound("Proizvod ne postoji");
            }
            var recenzije = _context.Recenzija.Where(x => x.ProizvodID == proizvod.ID).ToList();
            return Ok(recenzije);

        }
        [HttpDelete("ObrisiRecenziju")]
        public async Task<IActionResult> DeleteRecenzija(int id)
        {
            var recenzija = await _context.Recenzija.FindAsync(id);

            if(recenzija == null)
            {
                return NotFound("Recenzija ne postoji");
            }

            _context.Remove(recenzija);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
