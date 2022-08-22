using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReservation.Shared.Dtos;

namespace BookReservation.Shared.Dtos.User
{
    public class UserSaveDto : BaseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}