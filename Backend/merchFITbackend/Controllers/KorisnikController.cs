using merchFITbackend.Data;
using merchFITbackend.Data.DataTransferObjects;
using merchFITbackend.Data.Models;
using merchFITbackend.Interfaces;
using merchFITbackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace merchFITbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class KorisnikController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Korisnik> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Korisnik> _signInManager;

        public KorisnikController(ApplicationDbContext context, UserManager<Korisnik> userManager, ITokenService tokenService, SignInManager<Korisnik> signInManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet("GetKorisnik")]

        public async Task<IActionResult> GetKorisnik(int id)
        {
            var user = await _context.Korisnik.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [Authorize]
        [HttpGet("GetAllKorisnici")]

        public async Task<IActionResult> GetAllKorisnici()
        {
            var users = await _context.Korisnik.ToListAsync();

            if (users == null || !users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }


        [HttpPost("RegistracijaKorisnik")]
        public async Task<IActionResult> Register([FromBody] RegistrujKorisnikaDTO registruj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var korisnik = new Korisnik
                {
                    Ime = registruj.Ime,
                    Prezime = registruj.Prezime,
                    PhoneNumber = registruj.PhoneNumber,
                    Grad = registruj.Grad,
                    Adresa = registruj.Adresa,
                    Drzava = registruj.Drzava,
                    PostanskiBroj = registruj.PostanskiBroj,
                    Email = registruj.Email,
                    DatumRegistracije = DateTime.Now,
                    UserName = registruj.Email
                    
                };

               
                var registrujKorisnika = await _userManager.CreateAsync(korisnik, registruj.Password);
                var message = $"Pozdrav {korisnik.Email}, hvala što ste se registrovali na naš merch store." +
                    $" Nadamo se da ćete pronaći odgovarajući komad za sebe!";
                var subject = "Uspješna registracija";

                var korpa = new Korpa
                {
                    KorisnikID = korisnik.Id
                };
                _context.Korpa.Add(korpa);

                var wishlist = new Wishlist
                { 
                    KorisnikID = korisnik.Id
                };
                _context.Wishlist.Add(wishlist);
                if (registrujKorisnika.Succeeded)
                {
                    
                   
                    if (korisnik.Id != null)
                    {
                        var userRole = new IdentityUserRole<int>
                        {
                            UserId = korisnik.Id,
                            RoleId = 9
                        };

                        

                        _context.UserRoles.Add(userRole);
                        await _context.SaveChangesAsync();
                    }
                    _emailSender.SendEmailyAsync(korisnik.Email, subject, message);
                    return Ok(
                        new NoviKorisnikDTO
                        {
                            ID = korisnik.Id,
                            Email = korisnik.Email,
                            Token = _tokenService.GenerateToken(korisnik)
                        });
                }
                else
                {
                    return BadRequest("Doslo je do greske tokom kreiranja korisnika");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn([FromBody] KorisnikLog korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userManager.Users.FirstOrDefault(x => x.Email.ToLower() == korisnik.Email.ToLower());

            if (user == null)
            {
                return Unauthorized("Email nije tacan!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, korisnik.Lozinka, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Pogrešni podaci za prijavu. Provjerite email i/ili šifru.");
            }

            return Ok(
                    new NoviKorisnikDTO
                    {
                        ID = user.Id,
                        Email = user.Email,
                        Token = _tokenService.GenerateToken(user)
                    }
                );
        }

        [HttpDelete("ObrisiKorisnika")]
        public async Task<IActionResult> DeleteKorisnik(int Id)
        {
            var korisnik = await _context.Korisnik.FindAsync(Id);

            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();

            return Ok(korisnik);
        }



        [HttpPut("UpdateKorisnickiPodaci")]
        public async Task<IActionResult> UpdateKorisnickiPodaci([FromBody] UpdateKorisnikDTO k)
        {

            if (k == null || k.ID <= 0)
            {
                return BadRequest("Netacni podaci o korisniku");
            }

            var korisnik = await _context.Korisnik.FindAsync(k.ID);

            if (korisnik == null)
            {
                return NotFound("Korisnik nije pronadjen");
            }

            korisnik.Ime = k.Ime;
            korisnik.Prezime = k.Prezime;
            korisnik.Email = k.Email;
            korisnik.PhoneNumber = k.PhoneNumber;
            korisnik.Adresa = k.Adresa;
            korisnik.Grad = k.Grad;
            korisnik.PostanskiBroj = k.PostanskiBroj;
            await _context.SaveChangesAsync();
            return Ok("Korisnik azuriran uspjesno");

        }
    }
}
