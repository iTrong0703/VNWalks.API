using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtTokenGenerator
{
    public interface ITokenProvider
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
