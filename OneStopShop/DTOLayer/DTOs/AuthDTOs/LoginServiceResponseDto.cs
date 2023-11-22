using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AuthDTOs
{
    public class LoginServiceResponseDto
    {
        public string NewToken { get; set; }
        public UserInfoResult UserInfo { get; set; }
    }
}
