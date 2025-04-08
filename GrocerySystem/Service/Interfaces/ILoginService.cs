using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILoginService
    {
        dynamic Authenticate(LoginDto item);
        string GenerateToken(dynamic user);
    }
}
