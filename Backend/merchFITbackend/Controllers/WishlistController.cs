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
    public class WishlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishlistController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddWishlistStavka")]
        public async Task<IActionResult> AddWishlistStavka([FromBody] AddWishListStavkaDTO WS)
        {
            var proizvod = await _context.Proizvod.FindAsync(WS.ProizvodID);

            if (proizvod == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.Where(x=>x.KorisnikID == WS.KorisnikID).FirstOrDefaultAsync();
            if (wishlist == null)
            {
                return NotFound("Wishlist nije pronađena.");
            }

            var WishlistStavka = new WishlistStavka
            {
                ProizvodID = WS.ProizvodID,
                WishlistID = wishlist.ID
            };

            _context.WishlistStavka.Add(WishlistStavka);
            await _context.SaveChangesAsync();

            return Ok(WishlistStavka);
        }

        [HttpGet("GetWishlistById")]
        public async Task<IActionResult> GetWishlistById (int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            var wishlist = await _context.Wishlist
            .FirstOrDefaultAsync(x => x.KorisnikID == id);

            if (wishlist == null)
            {
                return NotFound(); // Ako korpa ne postoji
            }

            var WishlistStavke = await _context.WishlistStavka
                .Where(x => x.WishlistID == wishlist.ID)
                .Select(n => new GetWishlistStavkeVM
                {
                    ID = n.ID,
                    NazivProizvoda = n.Proizvod.Naziv,
                    SlikaProizvoda = n.Proizvod.SlikaProizvoda
                }).ToListAsync();

            return Ok(WishlistStavke);
        }

        [HttpDelete("DeleteWishlistStavka")]
        public async Task<IActionResult> DeleteWishlistStavka(int id)
        {
            var WishlistStavka = await _context.WishlistStavka.FindAsync(id);

            if (WishlistStavka == null)
            {
                return NotFound();
            }
            _context.WishlistStavka.Remove(WishlistStavka);
            await _context.SaveChangesAsync();

            return Ok(WishlistStavka);
        }
    }
}
