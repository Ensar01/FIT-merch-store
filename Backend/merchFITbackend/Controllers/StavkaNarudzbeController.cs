using merchFITbackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace merchFITbackend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StavkaNarudzbeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StavkaNarudzbeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("SveStavke")]
        public async Task<IActionResult> GetAllStavke(int narudzbaId)
        {
            // Find the order by ID and include the related StavkeNarudzbe
            var narudzba = await _context.Narudzba
                .Include(n => n.StavkeNarudzbe)
                .FirstOrDefaultAsync(n => n.ID == narudzbaId);

            // If the order is not found, return a 404 response
            if (narudzba == null)
            {
                return NotFound($"Narudzba sa ID-om {narudzbaId} nije pronadjena.");
            }

            // Return the list of StavkeNarudzbe
            var stavkeNarudzbe = narudzba.StavkeNarudzbe;

            return Ok(stavkeNarudzbe);
        }

        [HttpDelete("DeleteStavka")]
        public async Task<IActionResult> DeleteStavka(int id)
        {
            var stavka = await _context.StavkeNarudzbe.FindAsync(id);

            if (stavka == null)
            {
                return NotFound($"StavkaNarudzbe sa ID-om {id} nije pronadjena.");
            }


            _context.StavkeNarudzbe.Remove(stavka);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

