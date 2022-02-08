using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Mysql.API.Others
{
    public class TokenLifeTime
    {
        public static bool Validate(
             DateTime? notBefore,
             DateTime? expires,
             SecurityToken tokentoValidate,
             TokenValidationParameters @param)
        {
            return (expires != null && expires > DateTime.UtcNow);
        }


    }
}
