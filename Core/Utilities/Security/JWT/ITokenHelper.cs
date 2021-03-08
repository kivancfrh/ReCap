using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Genellikle jwt ile yaparız ama önlem olarak interface kullanıyoru. Özellikle testlerde ya da başka araçlarla üretirken yardımcı olacak
    public interface ITokenHelper
    {
        //Kullanıcı adı ve parola girdikten sonra bu öperasyon çalışacak. i
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
