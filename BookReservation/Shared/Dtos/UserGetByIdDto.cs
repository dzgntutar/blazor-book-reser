using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class UserGetByIdDto
    {
        public int Id { get; set; }
        public string FirstName  { get; set; }
        public string LastName  { get; set; }
    }
}