using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //Şifreleme olan tüm sistemlerde herşeyi byte[] formatında veriyor ve oluşturuyor olmamız gerekiyor

        public static SecurityKey CreateSecurityKey(string securtyKey) //jw deki key
        {
            // simetrik bir securityKey
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securtyKey));
        }
    }
}
