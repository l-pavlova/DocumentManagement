using JWT.Algorithms;
using JWT.Builder;

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
