using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public static class Extensions
    {
        public static string[] FormatToken(this JwtBuilder str, ref string token, string SECRET_KEY)
        {
            return str.WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(SECRET_KEY)
                .MustVerifySignature().Decode(token).Replace("\\", "").Replace("\"", "").Replace("}", "").Split(',');
        }
    }
}
