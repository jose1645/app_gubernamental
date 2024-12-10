using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sombrero.GoogleServices
{
    public interface IGoogleAuthService
    {
        public Task<GoogleUserDTO> AuthenticateAsync();
        public Task<GoogleUserDTO> GetCurrentUserAsync();
        public Task LogoutAsync();


    }
}
