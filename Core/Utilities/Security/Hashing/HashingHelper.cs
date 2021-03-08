using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Bir araç olduğu için çıplak kalabilir.
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //Hash ve Salt ı oluşturacak yapı. Out, dışarıya verilecek değer. Void olsa bile dönüş yapar.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //hcam - kriptolo sınıfında kullanılan class
            {
                passwordSalt = hmac.Key; //Hmac in tuzu. Her kullanıcı için bir key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //string in byte karşılığı için encoding!
            }
        }

        //PasswordHash i doğrulamak için hash ve salt ı biz gönderiyouz. Password - kullanıcının her girişte yazdığı parolası
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Burda hesaplanan hash bizim gönderdiğimiz salt ile yapılıyor. 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) //Byte ın içindeki tüm indexleri tek tek karşılaştırıyor.
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
