using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTTokenGenerator
{
    public interface ITokenProvider
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
