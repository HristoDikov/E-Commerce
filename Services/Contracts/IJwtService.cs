using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services.Contracts
{
    public interface IJwtService
    {
        string GenerateSecurityToken(string name);
    }
}
