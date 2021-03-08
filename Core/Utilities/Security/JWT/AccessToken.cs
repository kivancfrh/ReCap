using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //Token ı biz veriyoruz.
        public DateTime Expiratoin { get; set; } //token ın bitiş zamanı
    }
}
