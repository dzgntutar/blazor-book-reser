using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Shared.Dtos.User
{
	public class UserLoginDto : BaseDto
	{
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
