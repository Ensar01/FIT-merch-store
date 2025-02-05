using AspNetCore.Reporting;
using merchFITbackend.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Tmp;

namespace merchFITbackend.Reports
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static List<KorisniciVM> getKorisnici(ApplicationDbContext con)
        {
            List<KorisniciVM> podaci = con.Korisnik.Select(k => new KorisniciVM
            {
                ID = k.Id,
                Ime = k.Ime,
                Prezime = k.Prezime,
                Email = k.Email,
                Telefon = k.PhoneNumber
            }).ToList();
            return podaci;
        }
        [HttpGet("PDF report")]
        public IActionResult Index()
        {
            LocalReport _localReport = new LocalReport("Reports/Report1.rdlc");
            List<KorisniciVM> podaci = getKorisnici(_context);
            DataSet ds = new DataSet();
            _localReport.AddDataSource("DataSet1", podaci);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
     

            ReportResult result = _localReport.Execute(RenderType.Pdf);
            return File(result.MainStream, "application/pdf");

        }
    }
}
