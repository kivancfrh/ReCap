using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //web api nin kullanabileceği Jwt servislerini oluşturabilmesi için elimizde olanlar.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //Anahtar,Şifreleme Algoritması
        }
    }
}
