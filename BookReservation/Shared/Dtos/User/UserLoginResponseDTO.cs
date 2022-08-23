using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Shared.Dtos.User
{
    public class UserLoginResponseDTO
    {
        public String ApiToken { get; set; }

        public UserGetAllResponseDto User { get; set; }
    }
}
