using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public static class AuthenticationManager
    {
        private const string SECRET_KEY = "36e7429bbf951a0af65558686f248d3e24f0014ce0cff4908c567070a9be93c6fef501d2b574e9b75a152b1367473d5ed3b610512c0d0dc4a3af2288a15e71af";
        public static string CreateUserToken(User user)
        {
            PropertyInfo[] propertyInfos = typeof(User).GetProperties();

            var currTime = DateTime.Now;
            var token = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(SECRET_KEY).ExpirationTime(currTime.AddHours(8));
            foreach (var prop in propertyInfos)
            {
                token.AddClaim(prop.Name, prop.GetValue(user));
            }
            return token.Encode();
        }
        public static User ParseUserToken(string token)
        {
            var userArray = new JwtBuilder().FormatToken(ref token, SECRET_KEY);

            var user = new User
            {
                Id = (userArray[1].Split(':').LastOrDefault()),
                FirstName = userArray[2].Split(':').LastOrDefault(),
                LastName = userArray[3].Split(':').LastOrDefault(),
                Email = userArray[4].Split(':').LastOrDefault(),
                Password = userArray[5].Split(':').LastOrDefault(),
            };
            return user;
        }

}
}
