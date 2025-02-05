using merchFITbackend.Data.Models;

namespace merchFITbackend.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Korisnik korisnik);
    }
}
