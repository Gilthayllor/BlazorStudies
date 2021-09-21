using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.API.Contracts.Services
{
    public interface IUserservice
    {
        Task<string> GenerateJWT(IdentityUser user);
    }
}
